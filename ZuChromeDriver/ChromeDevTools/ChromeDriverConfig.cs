// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Zu.WebDriver.BasicTypes;

namespace Zu.Chrome
{
    public class ChromeDriverConfig : DriverConfig
    {
        /// <summary>
        /// When true, Chrome is launched with <c>--disable-popup-blocking</c> so <c>window.open</c> is not blocked (multi-window automation/tests).
        /// </summary>
        public bool DisablePopupBlocking { get; set; }
        /// <summary>
        /// When true, <see cref="FrameTracker"/> is enabled during <see cref="ZuChromeDriver.Connect"/>.
        /// Default is false; enable for iframe switching and JavaScript dialog tracking.
        /// </summary>
        public bool EnableFrameTrackerOnConnect { get; set; }

        /// <summary>
        /// When true, <see cref="DomTracker"/> is enabled during <see cref="ZuChromeDriver.Connect"/>.
        /// </summary>
        public bool EnableDomTrackerOnConnect { get; set; }

        /// <summary>
        /// When true, browser log capture is enabled during <see cref="ZuChromeDriver.Connect"/>.
        /// </summary>
        public bool EnableBrowserLogCaptureOnConnect { get; set; }

        /// <summary>
        /// Optional log-type → level preferences (WebDriver-style). Empty means default capture for browser logs.
        /// </summary>
        public Dictionary<string, LogLevel> LoggingPreferences { get; } =
            new Dictionary<string, LogLevel>(StringComparer.OrdinalIgnoreCase);

        public ChromeDriverConfig()
            : base()
        {

        }

        public ChromeDriverConfig(DriverConfig config)
            : this()
        {
            UserDir = config.UserDir;
            CommandLineArguments = config.CommandLineArguments;
            IsTempProfile = config.IsTempProfile;
            IsDefaultProfile = config.IsDefaultProfile;
            TempDirCreateDelay = config.TempDirCreateDelay;
            Port = config.Port;
            Headless = config.Headless;
            WindowSize = config.WindowSize;
            DoNotOpenChromeProfile = config.DoNotOpenChromeProfile;
            DoOpenBrowserDevTools = config.DoOpenBrowserDevTools;
            if(config is ChromeDriverConfig chromeConfig)
            {
                DisablePopupBlocking = chromeConfig.DisablePopupBlocking;
                EnableFrameTrackerOnConnect = chromeConfig.EnableFrameTrackerOnConnect;
                EnableDomTrackerOnConnect = chromeConfig.EnableDomTrackerOnConnect;
                EnableBrowserLogCaptureOnConnect = chromeConfig.EnableBrowserLogCaptureOnConnect;
                foreach (KeyValuePair<string, LogLevel> kv in chromeConfig.LoggingPreferences)
                    LoggingPreferences[kv.Key] = kv.Value;
            }
        }

    }
    public static class ChromeDriverConfigFluent
    {
        public static T SetDisablePopupBlocking<T>(this T dc, bool disablePopupBlocking = true) where T : ChromeDriverConfig
        {
            dc.DisablePopupBlocking = disablePopupBlocking;
            return dc;
        }

        public static T SetLoggingPreference<T>(this T dc, string logType, LogLevel level) where T : ChromeDriverConfig
        {
            if (string.IsNullOrEmpty(logType))
                throw new ArgumentNullException(nameof(logType));
            dc.LoggingPreferences[logType] = level;
            return dc;
        }

        public static T SetEnableFrameTrackerOnConnect<T>(this T dc, bool enable = true) where T : ChromeDriverConfig
        {
            dc.EnableFrameTrackerOnConnect = enable;
            return dc;
        }

        public static T SetEnableDomTrackerOnConnect<T>(this T dc, bool enable = true) where T : ChromeDriverConfig
        {
            dc.EnableDomTrackerOnConnect = enable;
            return dc;
        }

        public static T SetEnableBrowserLogCaptureOnConnect<T>(this T dc, bool enable = true) where T : ChromeDriverConfig
        {
            dc.EnableBrowserLogCaptureOnConnect = enable;
            return dc;
        }

    }
}