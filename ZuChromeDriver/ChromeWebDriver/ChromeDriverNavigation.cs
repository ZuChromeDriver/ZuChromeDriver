// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
using Zu.Chrome;
using Zu.WebDriver.AsyncInteractions;
using Zu.WebDriver.BasicTypes;

namespace Zu.ChromeWebDriver
{
    public class ChromeDriverNavigation : INavigation
    {
        private IChromeDriver _ZuChromeDriver;
        public ChromeDriverNavigation(IChromeDriver ZuChromeDriver)
        {
            _ZuChromeDriver = ZuChromeDriver;
        }

        public async Task Back(CancellationToken cancellationToken = default)
        {
            var res = await _ZuChromeDriver.WindowCommands.GoBack(cancellationToken).ConfigureAwait(false);
            _ZuChromeDriver.Session?.SwitchToTopFrame();
        }

        public async Task Forward(CancellationToken cancellationToken = default)
        {
            var res = await _ZuChromeDriver.WindowCommands.GoForward(cancellationToken).ConfigureAwait(false);
            _ZuChromeDriver.Session?.SwitchToTopFrame();
        }

        public Task<string> GetUrl(CancellationToken cancellationToken = default)
        {
            return _ZuChromeDriver.WindowCommands.GetCurrentUrl();
        }

        public Task GoToUrl(string url, CancellationToken cancellationToken = default)
        {
            return _ZuChromeDriver.WindowCommands.GoToUrl(url, null, cancellationToken);
        }

        public Task GoToUrl(Uri url, CancellationToken cancellationToken = default)
        {
            if (url == null)
                throw new WebBrowserException("URL cannot be null", "ArgumentNullException");
            return _ZuChromeDriver.WindowCommands.GoToUrl(url.ToString(), null, cancellationToken);
        }

        public async Task Refresh(CancellationToken cancellationToken = default)
        {
            await _ZuChromeDriver.WebView.Reload(cancellationToken).ConfigureAwait(false);
            var pageLoadTimeout = _ZuChromeDriver.Session?.PageLoadTimeout ?? default;
            var readyBudget = pageLoadTimeout > TimeSpan.Zero ? pageLoadTimeout : TimeSpan.FromSeconds(30);
            await _ZuChromeDriver.WebView.WaitForTopDocumentReadyAsync(readyBudget, cancellationToken).ConfigureAwait(false);
            await _ZuChromeDriver.WebView.WaitForSameOriginFramesReadyAsync(readyBudget, cancellationToken).ConfigureAwait(false);
            _ZuChromeDriver.Session?.SwitchToTopFrame();
        }
    }
}