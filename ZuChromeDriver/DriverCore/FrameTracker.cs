// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// This file is based on or incorporates material from the Chromium Projects, licensed under the BSD-style license. More info in THIRD-PARTY-NOTICES file.
using System.Collections.Concurrent;
using System.Text.Json.Nodes;
using Zu.ChromeDevTools.Page;
using Zu.ChromeDevTools.Runtime;
using Zu.Common;

namespace Zu.Chrome.DriverCore
{
    public class FrameTracker
    {
        private ChromeDevToolsConnection _devTools;
        private Session _session;
        private ConcurrentDictionary<string, long> _frameToContext = new();
        private bool _enabled;
        private int _openJavaScriptDialogCount;
        private string _javascriptDialogMessage;
        private DialogType? _javascriptDialogType;

        public FrameTracker(ChromeDevToolsConnection devTools, Session session)
        {
            _devTools = devTools;
            _session = session;
        }

        /// <summary>
        /// True when a JavaScript dialog was reported via CDP and not yet closed. Used to surface
        /// <see cref="DriverCoreException"/> with error <c>unexpected alert open</c> on commands like <c>getTitle</c>.
        /// </summary>
        public bool TryGetBlockingJavaScriptDialog(out string message)
        {
            if (Volatile.Read(ref _openJavaScriptDialogCount) > 0)
            {
                message = _javascriptDialogMessage;
                return true;
            }

            message = null;
            return false;
        }

        /// <summary>
        /// Type of the currently open JavaScript dialog (when <see cref="TryGetBlockingJavaScriptDialog"/> is true).
        /// </summary>
        public DialogType? BlockingDialogType
        {
            get { return Volatile.Read(ref _openJavaScriptDialogCount) > 0 ? _javascriptDialogType : null; }
        }

        public async Task Enable()
        {
            if (_enabled)
                return;
            _enabled = true;
            _devTools.Runtime.SubscribeToExecutionContextCreatedEvent(OnContextCreatedEvent);
            _devTools.Runtime.SubscribeToExecutionContextDestroyedEvent(OnContextDestroyedEvent);
            _devTools.Runtime.SubscribeToExecutionContextsClearedEvent(OnContextsClearedEvent);
            _devTools.Page.SubscribeToFrameNavigatedEvent(OnFrameNavigatedEvent);
            _devTools.Page.SubscribeToJavascriptDialogOpeningEvent(OnJavascriptDialogOpening);
            _devTools.Page.SubscribeToJavascriptDialogClosedEvent(OnJavascriptDialogClosed);
            await _devTools.Runtime.Enable().ConfigureAwait(false);
            await _devTools.Page.Enable().ConfigureAwait(false);
        }

        private void OnJavascriptDialogOpening(JavascriptDialogOpeningEvent e)
        {
            Interlocked.Increment(ref _openJavaScriptDialogCount);
            _javascriptDialogMessage = e.Message;
            _javascriptDialogType = e.Type;
        }

        private void OnJavascriptDialogClosed(JavascriptDialogClosedEvent e)
        {
            var v = Interlocked.Decrement(ref _openJavaScriptDialogCount);
            if (v < 0)
            {
                Interlocked.Exchange(ref _openJavaScriptDialogCount, 0);
            }

            if (Volatile.Read(ref _openJavaScriptDialogCount) <= 0)
            {
                _javascriptDialogMessage = null;
                _javascriptDialogType = null;
            }
        }

        public long ? GetContextIdForFrame(string frame)
        {
            if (_frameToContext.TryGetValue(frame, out long res))
                return res;
            //throw new KeyNotFoundException(frame);
            return null;
        }

        /// <summary>
        /// Drop cached execution contexts after a top-level navigation so subsequent frame commands
        /// do not reuse contexts from a destroyed document (e.g. after another test used <c>switchTo().frame()</c>).
        /// </summary>
        public void ResetFrameContexts()
        {
            _frameToContext.Clear();
        }

        private void OnContextCreatedEvent(ExecutionContextCreatedEvent ev)
        {
            var auxData = JsonValueHelper.AsJsonObject(ev.Context.AuxData);
            if (auxData != null)
            {
                var isDefault = (auxData["isDefault"] as JsonValue)?.GetValue<bool>();
                var frameId = (auxData["frameId"] as JsonValue)?.GetValue<string>();
                if (isDefault == true && !string.IsNullOrWhiteSpace(frameId))
                    _frameToContext[frameId] = ev.Context.Id;
            }
        }

        private void OnContextDestroyedEvent(ExecutionContextDestroyedEvent ev)
        {
            var itemsToRemove = _frameToContext.Where(v => v.Value == ev.ExecutionContextId).ToList();
            foreach (var item in itemsToRemove)
                _frameToContext.TryRemove(item.Key, out long context);
        }

        private void OnContextsClearedEvent(ExecutionContextsClearedEvent ev)
        {
            _frameToContext.Clear();
        }

        private void OnFrameNavigatedEvent(FrameNavigatedEvent obj)
        {
            if (string.IsNullOrWhiteSpace(obj.Frame.ParentId))
            {
                // Context map is cleared by executionContextsCleared when contexts are destroyed.
                // Clearing here races with child iframe executionContextCreated events that can fire
                // before this top-level frameNavigated notification.
                _session?.SwitchToTopFrame();
            }
        }
    }
}