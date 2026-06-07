// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.ObjectModel;
using Zu.Chrome;
using Zu.WebDriver.BasicTypes;
using Zu.WebDriver.BrowserOptions;

namespace Zu.ChromeWebDriver
{
    public class ChromeDriverLogs : ILogs
    {
        private static readonly ReadOnlyCollection<LogEntry> EmptyLogEntries = new(Array.Empty<LogEntry>());

        private readonly IChromeDriver _ZuChromeDriver;

        public ChromeDriverLogs(IChromeDriver ZuChromeDriver)
        {
            _ZuChromeDriver = ZuChromeDriver ?? throw new ArgumentNullException(nameof(ZuChromeDriver));
        }

        public async Task<ReadOnlyCollection<string>> AvailableLogTypes(CancellationToken cancellationToken = default)
        {
            await _ZuChromeDriver.CheckConnected(cancellationToken).ConfigureAwait(false);
            var types = new List<string> { LogType.Browser, LogType.Driver };
            return new ReadOnlyCollection<string>(types);
        }

        public async Task<ReadOnlyCollection<LogEntry>> GetLog(string logKind,
            CancellationToken cancellationToken = default)
        {
            await _ZuChromeDriver.CheckConnected(cancellationToken).ConfigureAwait(false);

            if (_ZuChromeDriver is ZuChromeDriver chromeDriver)
                await chromeDriver.EnsureBrowserLogCaptureEnabledAsync(cancellationToken).ConfigureAwait(false);

            if (string.Equals(logKind, LogType.Browser, StringComparison.OrdinalIgnoreCase))
            {
                if (_ZuChromeDriver is ZuChromeDriver ch)
                    return ch.ConsumeBrowserLogEntries();
                return EmptyLogEntries;
            }

            if (string.Equals(logKind, LogType.Driver, StringComparison.OrdinalIgnoreCase))
                return EmptyLogEntries;

            throw new WebBrowserException($"Unsupported log type '{logKind}'.");
        }
    }
}
