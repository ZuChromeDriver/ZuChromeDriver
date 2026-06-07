// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Zu.Chrome;
using Zu.WebDriver.AsyncInteractions;
using Zu.WebDriver.BasicTypes;

namespace Zu.ChromeWebDriver
{
    public class ChromeDriverCoordinates: ICoordinates
    {
        private IChromeDriver _ZuChromeDriver;

        public ChromeDriverCoordinates(IChromeDriver ZuChromeDriver)
        {
            _ZuChromeDriver = ZuChromeDriver;
        }

        public string AuxiliaryLocator => throw new System.NotImplementedException();

        public Task<WebPoint> LocationInDom(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<WebPoint> LocationInViewport(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<WebPoint> LocationOnScreen(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}