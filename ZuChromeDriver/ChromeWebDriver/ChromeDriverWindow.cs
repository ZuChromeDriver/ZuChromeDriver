// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Zu.Chrome;
using Zu.ChromeDevTools.Browser;
using Zu.WebDriver.BasicTypes;
using Zu.WebDriver.BrowserOptions;

namespace Zu.ChromeWebDriver
{
    public class ChromeDriverWindow: IWindow
    {
        private IChromeDriver _ZuChromeDriver;

        public ChromeDriverWindow(IChromeDriver ZuChromeDriver)
        {
            _ZuChromeDriver = ZuChromeDriver;
        }

        private async Task<(long windowId, Bounds bounds)> GetWindowForTargetAsync(CancellationToken cancellationToken)
        {
            if (_ZuChromeDriver == null)
                throw new System.InvalidOperationException("Chrome DevTools session is not available.");
            await _ZuChromeDriver.CheckConnected(cancellationToken).ConfigureAwait(false);
            var devTools = _ZuChromeDriver.DevTools;
            var resp = await devTools.Browser.GetWindowForTarget(new GetWindowForTargetCommand(), cancellationToken).ConfigureAwait(false);
            return (resp.WindowId, resp.Bounds);
        }

        public async Task<WebPoint> GetPosition(CancellationToken cancellationToken = default)
        {
            var (_, bounds) = await GetWindowForTargetAsync(cancellationToken).ConfigureAwait(false);
            int x = (int)(bounds?.Left ?? 0);
            int y = (int)(bounds?.Top ?? 0);
            return new WebPoint(x, y);
        }

        public async Task<WebSize> GetSize(CancellationToken cancellationToken = default)
        {
            var (_, bounds) = await GetWindowForTargetAsync(cancellationToken).ConfigureAwait(false);
            int w = (int)(bounds?.Width ?? 0);
            int h = (int)(bounds?.Height ?? 0);
            return new WebSize(w, h);
        }

        public async Task Maximize(CancellationToken cancellationToken = default)
        {
            var (windowId, bounds) = await GetWindowForTargetAsync(cancellationToken).ConfigureAwait(false);
            if (bounds?.WindowState == WindowState.Maximized)
            {
                return;
            }

            var devTools = _ZuChromeDriver.DevTools;
            await devTools.Browser.SetWindowBounds(new SetWindowBoundsCommand
            {
                WindowId = windowId,
                Bounds = new Bounds { WindowState = WindowState.Maximized }
            }, cancellationToken).ConfigureAwait(false);
        }

        public async Task SetPosition(WebPoint pos, CancellationToken cancellationToken = default)
        {
            var (windowId, bounds) = await GetWindowForTargetAsync(cancellationToken).ConfigureAwait(false);
            var devTools = _ZuChromeDriver.DevTools;
            await devTools.Browser.SetWindowBounds(new SetWindowBoundsCommand
            {
                WindowId = windowId,
                Bounds = CreateBoundsForRect(bounds, left: pos.X, top: pos.Y)
            }, cancellationToken).ConfigureAwait(false);
        }

        public async Task SetSize(WebSize size, CancellationToken cancellationToken = default)
        {
            var (windowId, bounds) = await GetWindowForTargetAsync(cancellationToken).ConfigureAwait(false);
            var devTools = _ZuChromeDriver.DevTools;
            await devTools.Browser.SetWindowBounds(new SetWindowBoundsCommand
            {
                WindowId = windowId,
                Bounds = CreateBoundsForRect(bounds, width: size.Width, height: size.Height)
            }, cancellationToken).ConfigureAwait(false);
        }

        private static Bounds CreateBoundsForRect(Bounds current, int? left = null, int? top = null, int? width = null, int? height = null)
        {
            var state = current?.WindowState;
            if (state == WindowState.Maximized || state == WindowState.Fullscreen || state == WindowState.Minimized)
            {
                state = WindowState.Normal;
            }

            return new Bounds
            {
                Left = left,
                Top = top,
                Width = width,
                Height = height,
                WindowState = state
            };
        }
    }
}