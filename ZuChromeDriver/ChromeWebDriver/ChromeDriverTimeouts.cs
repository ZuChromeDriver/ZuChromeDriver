// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Zu.Chrome;
using Zu.WebDriver.BrowserOptions;

namespace Zu.ChromeWebDriver
{
    public class ChromeDriverTimeouts: ITimeouts
    {
        private IChromeDriver _ZuChromeDriver;

        public ChromeDriverTimeouts(IChromeDriver ZuChromeDriver)
        {
            _ZuChromeDriver = ZuChromeDriver;
        }

        public TimeSpan AsynchronousJavaScript
        {
            get => _ZuChromeDriver.Session.ScriptTimeout;
            set => _ZuChromeDriver.Session.ScriptTimeout = value;
        }

        public TimeSpan ImplicitWait
        {
            get => _ZuChromeDriver.Session.ImplicitWait;
            set => _ZuChromeDriver.Session.ImplicitWait = value;
        }

        public TimeSpan PageLoad
        {
            get => _ZuChromeDriver.Session.PageLoadTimeout;
            set => _ZuChromeDriver.Session.PageLoadTimeout = value;
        }

        public Task<TimeSpan> GetAsynchronousJavaScript(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(AsynchronousJavaScript);
        }

        public Task<TimeSpan> GetImplicitWait(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(ImplicitWait);
        }

        public Task<TimeSpan> GetPageLoad(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(PageLoad);
        }

        public Task SetAsynchronousJavaScript(TimeSpan time, CancellationToken cancellationToken = default)
        {
            AsynchronousJavaScript = time;
            return Task.CompletedTask;
        }

        public Task SetImplicitWait(TimeSpan implicitWait, CancellationToken cancellationToken = default)
        {
            ImplicitWait = implicitWait;
            return Task.CompletedTask;
        }

        public Task SetPageLoad(TimeSpan time, CancellationToken cancellationToken = default)
        {
            PageLoad = time;
            return Task.CompletedTask;
        }
    }
}
