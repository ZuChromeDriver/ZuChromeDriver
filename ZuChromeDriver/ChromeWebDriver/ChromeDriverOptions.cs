// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Zu.Chrome;
using Zu.WebDriver.BrowserOptions;

namespace Zu.ChromeWebDriver
{
    public class ChromeDriverOptions: IOptions
    {
        private IChromeDriver _ZuChromeDriver;
        private ChromeDriverTimeouts _timeouts;
        private ChromeDriverCookieJar _cookies;
        private ChromeDriverLogs _logs;
        private ChromeDriverWindow _window;

        public ChromeDriverOptions(IChromeDriver ZuChromeDriver)
        {
            _ZuChromeDriver = ZuChromeDriver;
        }

        public ICookieJar Cookies { get { _cookies ??= new ChromeDriverCookieJar(_ZuChromeDriver); return _cookies; } }

        public IWindow Window { get { _window ??= new ChromeDriverWindow(_ZuChromeDriver); return _window; } }

        public ILogs Logs { get { _logs ??= new ChromeDriverLogs(_ZuChromeDriver); return _logs; } }

        public ITimeouts Timeouts { get { _timeouts ??= new ChromeDriverTimeouts(_ZuChromeDriver); return _timeouts; } }

        public bool HasLocationContext => throw new System.NotImplementedException();

        public ILocationContext LocationContext => throw new System.NotImplementedException();

        public bool HasApplicationCache => throw new System.NotImplementedException();

        public IApplicationCache ApplicationCache => throw new System.NotImplementedException();

        public ILocalStorage LocalStorage => throw new System.NotImplementedException();

        public ISessionStorage SessionStorage => throw new System.NotImplementedException();
    }
}