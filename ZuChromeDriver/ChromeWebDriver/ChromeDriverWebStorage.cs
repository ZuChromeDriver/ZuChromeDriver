// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Zu.Chrome;
using Zu.WebDriver.BrowserOptions;

namespace Zu.ChromeWebDriver
{
    public class ChromeDriverWebStorage: IWebStorage
    {
        private IChromeDriver _ZuChromeDriver;

        public ChromeDriverWebStorage(IChromeDriver ZuChromeDriver)
        {
            _ZuChromeDriver = ZuChromeDriver;
        }

        public ILocalStorage LocalStorage => throw new System.NotImplementedException();

        public ISessionStorage SessionStorage => throw new System.NotImplementedException();
    }
}