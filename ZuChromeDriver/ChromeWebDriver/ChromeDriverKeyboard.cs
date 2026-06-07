// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
using Zu.Chrome;
using Zu.Chrome.DriverCore;
using Zu.WebDriver.AsyncInteractions;
using Zu.WebDriver.BasicTypes;

namespace Zu.ChromeWebDriver
{
    public class ChromeDriverKeyboard : IKeyboard
    {
        private WebView _webView;
        private IChromeDriver _ZuChromeDriver;
        public ChromeDriverKeyboard(IChromeDriver ZuChromeDriver)
        {
            _ZuChromeDriver = ZuChromeDriver;
            _webView = ZuChromeDriver.WebView;
        }

        public Task PressKey(string keyToPress, CancellationToken cancellationToken = default)
        {
            if (keyToPress.Length != 1)
                throw new ArgumentOutOfRangeException(nameof(keyToPress));
            return _webView.DispatchKeyEvents(keyToPress, cancellationToken, releaseModifiers: false);
        }

        public Task ReleaseKey(string keyToRelease, CancellationToken cancellationToken = default)
        {
            if (keyToRelease.Length != 1)
                throw new ArgumentOutOfRangeException(nameof(keyToRelease));
            return _webView.DispatchKeyEvents(keyToRelease + Keys.Null, cancellationToken, releaseModifiers: false);
        }

        public Task SendKeys(string keySequence, CancellationToken cancellationToken = default) =>
            _webView.DispatchKeyEvents(keySequence, cancellationToken, releaseModifiers: true);
    }
}