// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
using Zu.Chrome;
using Zu.WebDriver.AsyncInteractions;
using Zu.WebDriver.BasicTypes;

namespace Zu.ChromeWebDriver
{
    public class ChromeDriverScreenshot : ITakesScreenshot
    {
        private IChromeDriver _ZuChromeDriver;
        public ChromeDriverScreenshot(IChromeDriver ZuChromeDriver)
        {
            _ZuChromeDriver = ZuChromeDriver;
        }

        public async Task<Screenshot> GetScreenshot(CancellationToken cancellationToken = default)
        {
            if (_ZuChromeDriver?.DevTools?.Session == null)
                return null;
            var screenshot = await _ZuChromeDriver.DevTools.Page.CaptureScreenshot().ConfigureAwait(false);
            return new Screenshot(screenshot?.Data);
        }
    }
}