// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Zu.Chrome;
using Zu.ChromeDevTools.Page;
using Zu.WebDriver;
using Zu.WebDriver.AsyncInteractions;

namespace Zu.ChromeWebDriver
{
    /// <summary>
    /// Handles JavaScript dialogs via CDP <c>Page.handleJavaScriptDialog</c>, aligned with WebDriver alert commands.
    /// </summary>
    public class ChromeDriverAlert : IAlert
    {
        private readonly IChromeDriver _driver;
        private string _pendingPromptText;

        public ChromeDriverAlert(IChromeDriver ZuChromeDriver)
        {
            _driver = ZuChromeDriver ?? throw new ArgumentNullException(nameof(ZuChromeDriver));
        }

        public Task Accept(CancellationToken cancellationToken = default)
        {
            return HandleDialog(accept: true, cancellationToken);
        }

        public Task Dismiss(CancellationToken cancellationToken = default)
        {
            return HandleDialog(accept: false, cancellationToken);
        }

        public Task SendKeys(string keysToSend, CancellationToken cancellationToken = default)
        {
            if (keysToSend == null)
                throw new ArgumentNullException(nameof(keysToSend));
            EnsureDialogPresent();

            var dialogType = _driver.FrameTracker.BlockingDialogType;
            if (dialogType != DialogType.Prompt)
            {
                throw new ElementNotInteractableException(
                    "cannot enter text into an alert that does not support text entry");
            }

            _pendingPromptText = keysToSend;
            return Task.CompletedTask;
        }

        public Task SetAuthenticationCredentials(string userName, string password,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<string> Text(CancellationToken cancellationToken = default)
        {
            EnsureDialogPresent();
            _driver.FrameTracker.TryGetBlockingJavaScriptDialog(out var message);
            return Task.FromResult(message ?? string.Empty);
        }

        private async Task HandleDialog(bool accept, CancellationToken cancellationToken)
        {
            EnsureDialogPresent();
            var cmd = new HandleJavaScriptDialogCommand { Accept = accept };
            var dialogType = _driver.FrameTracker.BlockingDialogType;
            if (accept && dialogType == DialogType.Prompt)
                cmd.PromptText = _pendingPromptText ?? string.Empty;

            await _driver.WebView.DevTools.Page.HandleJavaScriptDialog(cmd, cancellationToken).ConfigureAwait(false);
            _pendingPromptText = null;
        }

        private void EnsureDialogPresent()
        {
            if (_driver?.FrameTracker == null
                || !_driver.FrameTracker.TryGetBlockingJavaScriptDialog(out _))
            {
                throw new NoAlertPresentException();
            }
        }
    }
}
