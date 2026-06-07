// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
using System.Collections.ObjectModel;
using System.Text.Json.Nodes;
using Zu.Chrome.DriverCore;
using Zu.WebDriver.BasicTypes;
using Zu.WebDriver.AsyncInteractions;
using Zu.ChromeDevTools.Target;
using Zu.WebDriver.BrowserOptions;
using Zu.ChromeWebDriver;
using Zu.WebDriver;
using Zu.Chrome.DevTools;

namespace Zu.Chrome
{
    public class ZuChromeDriver : IChromeDriver
    {
        #region IWebDriver
        public IMouse Mouse => _mouse ??= new ChromeDriverMouse(this);

        public IKeyboard Keyboard => _keyboard ??= new ChromeDriverKeyboard(this);

        public IOptions Options => _options ??= new ChromeDriverOptions(this);

        public IAlert Alert => _alert ??= new ChromeDriverAlert(this);

        public ICoordinates Coordinates => _coordinates ??= new ChromeDriverCoordinates(this);

        public ITakesScreenshot Screenshot => _screenshot ??= new ChromeDriverScreenshot(this);

        public ITouchScreen TouchScreen => _touchScreen ??= new ChromeDriverTouchScreen(this);

        public INavigation Navigation => _navigation ??= new ChromeDriverNavigation(this);

        public IJavaScriptExecutor JavaScriptExecutor => _javaScriptExecutor ??= new ChromeDriverJavaScriptExecutor(this);

        public ITargetLocator TargetLocator => _targetLocator ??= new ChromeDriverTargetLocator(this);

        public IElements Elements => _elements ??= new ChromeDriverElements(this);

        public IActionExecutor ActionExecutor => _actionExecutor ??= new ChromeDriverActionExecutor(this);

        private ChromeDriverNavigation _navigation;
        private ChromeDriverTouchScreen _touchScreen;
        private ChromeDriverScreenshot _screenshot;
        private ChromeDriverCoordinates _coordinates;
        private ChromeDriverAlert _alert;
        private ChromeDriverOptions _options;
        private ChromeDriverKeyboard _keyboard;
        private ChromeDriverMouse _mouse;
        private ChromeDriverJavaScriptExecutor _javaScriptExecutor;
        private ChromeDriverTargetLocator _targetLocator;
        private ChromeDriverElements _elements;
        private ChromeDriverActionExecutor _actionExecutor;
        #endregion

        public bool IsConnected = false;
        public ChromeDevToolsConnection DevTools
        {
            get;
            set;
        }

        public FrameTracker FrameTracker
        {
            get;
            private set;
        }

        public DomTracker DomTracker
        {
            get;
            private set;
        }

        public Session Session
        {
            get;
            private set;
        }

        public WebView WebView
        {
            get;
            private set;
        }

        public ElementCommands ElementCommands
        {
            get;
            private set;
        }

        public ElementUtils ElementUtils
        {
            get;
            private set;
        }

        public WindowCommands WindowCommands
        {
            get;
            private set;
        }

        /// <summary>Most recent top-level URL passed to <see cref="WindowCommands.GoToUrl"/> (fallback for cookie commands).</summary>
        public string LastNavigatedUrl { get; internal set; }

        public ChromeDriverConfig Config
        {
            get;
            set;
        }

        public int Port
        {
            get => Config.Port;
            set => Config.Port = value;
        }

        public string UserDir
        {
            get => Config.UserDir;
            set => Config.SetUserDir(value);
        }

        public bool IsTempProfile
        {
            get => Config.IsTempProfile;
            set => Config.IsTempProfile = value;
        }

        public bool DoConnectWhenCheckConnected
        {
            get;
            set;
        } = true;

        static int _sessionId = 0;
        public ChromeProcessInfo ChromeProcess;
        private bool _isClosed = false;
        public delegate void DevToolsEventHandler(object sender, string methodName, JsonNode eventData);
        public event DevToolsEventHandler DevToolsEvent;
        public ZuChromeDriver BrowserDevTools
        {
            get;
            set;
        }

        public ChromeDriverConfig BrowserDevToolsConfig
        {
            get;
            set;
        }

        static Random _rnd = new();
        private readonly object _browserLogLock = new();
        private readonly List<LogEntry> _browserLogBuffer = new();
        private string _browserLogCaptureEndpoint;
        private bool _browserLogHandlersRegistered;

        public ZuChromeDriver(bool openInTempDir = true) : this(11000 + _rnd.Next(2000))
        {
            Config.SetIsTempProfile(openInTempDir);
        }

        public ZuChromeDriver(string profileDir, int port) : this(port)
        {
            UserDir = profileDir;
        }

        public ZuChromeDriver(string profileDir) : this(11000 + _rnd.Next(2000))
        {
            UserDir = profileDir;
        }

        public ZuChromeDriver(DriverConfig config) : this(config as ChromeDriverConfig ?? new ChromeDriverConfig(config))
        {
        }

        public ZuChromeDriver(ChromeDriverConfig config)
        {
            Config = config;
            if (Config.Port == 0)
                Config.Port = 11000 + _rnd.Next(2000);
            DevTools = new ChromeDevToolsConnection(Port);
            CreateDriverCore();
        }

        public ZuChromeDriver(int port)
        {
            Config = new ChromeDriverConfig();
            Port = port;
            DevTools = new ChromeDevToolsConnection(Port);
            CreateDriverCore();
        }

        public void CreateDriverCore()
        {
            Session = new Session(_sessionId++);
            FrameTracker = new FrameTracker(DevTools, Session);
            DomTracker = new DomTracker(DevTools);
            WebView = new WebView(DevTools, FrameTracker, this);
            //Mouse = new ChromeDriverMouse(WebView, Session);
            //Keyboard = new ChromeDriverKeyboard(WebView);
            //Options = new BrowserOptions();
            ElementUtils = new ElementUtils(WebView, Session);
            ElementCommands = new ElementCommands(this);
            WindowCommands = new WindowCommands(this);
        }

        public virtual async Task<string> Connect(CancellationToken cancellationToken = default)
        {
            IsConnected = true;
            UnsubscribeDevToolsSessionEvent();
            DoConnectWhenCheckConnected = false;
            if (!Config.DoNotOpenChromeProfile)
            {
                ChromeProcess = await OpenChromeProfile(Config).ConfigureAwait(false);
                if (Config.IsTempProfile)
                    await Task.Delay(Config.TempDirCreateDelay, cancellationToken).ConfigureAwait(false);
            }

            int connectionAttempts = 0;
            int maxAttempts = 5;
            if (ChromeProfilesWorker.GetPlatformString() != "windows")
            {
                maxAttempts = 50;
            }
            while (true)
            {
                connectionAttempts++;
                try
                {
                    await DevTools.Connect().ConfigureAwait(false);
                    break;
                }
                catch
                {
                    //LiveLogger.WriteLine("Connection attempt {0} failed with: {1}", connection_attempts, ex);
                    if (_isClosed || connectionAttempts >= maxAttempts)
                    {
                        throw;
                    }
                    else
                    {
                        await Task.Delay(200, cancellationToken).ConfigureAwait(false);
                    }
                }
            }

            SubscribeToDevToolsSessionEvent();
            await EnableConfiguredSessionFeaturesAsync(cancellationToken).ConfigureAwait(false);
            if (BrowserDevToolsConfig?.DoOpenBrowserDevTools == true)
                await OpenBrowserDevTools().ConfigureAwait(false);
            return $"Connected to Chrome port {Port}";
        }

        /// <summary>
        /// Attach DevTools to another page target (tab/window). Resets frame stack and CDP subscriptions needed after reconnect.
        /// </summary>
        public async Task SwitchDevToolsToTarget(string targetId, CancellationToken cancellationToken = default)
        {
            await DevTools.ReconnectToTarget(targetId, cancellationToken).ConfigureAwait(false);
            Session.SwitchToTopFrame();
            await EnableConfiguredSessionFeaturesAsync(cancellationToken).ConfigureAwait(false);
        }

        async Task EnableConfiguredSessionFeaturesAsync(CancellationToken cancellationToken)
        {
            if (Config.EnableFrameTrackerOnConnect)
                await FrameTracker.Enable().ConfigureAwait(false);
            if (Config.EnableDomTrackerOnConnect)
                await DomTracker.Enable().ConfigureAwait(false);
            if (Config.EnableBrowserLogCaptureOnConnect)
                await EnsureBrowserLogCaptureEnabledAsync(cancellationToken).ConfigureAwait(false);
        }

        internal ReadOnlyCollection<LogEntry> ConsumeBrowserLogEntries()
        {
            lock (_browserLogLock)
            {
                if (_browserLogBuffer.Count == 0)
                    return new ReadOnlyCollection<LogEntry>(Array.Empty<LogEntry>());
                LogEntry[] copy = _browserLogBuffer.ToArray();
                _browserLogBuffer.Clear();
                return new ReadOnlyCollection<LogEntry>(copy);
            }
        }

        internal async Task EnsureBrowserLogCaptureEnabledAsync(CancellationToken cancellationToken = default)
        {
            if (!IsConnected || DevTools?.Session == null)
                return;

            string endpoint = DevTools.Session.EndpointAddress;
            if (!string.Equals(_browserLogCaptureEndpoint, endpoint, StringComparison.Ordinal))
            {
                _browserLogCaptureEndpoint = endpoint;
                _browserLogHandlersRegistered = false;
                lock (_browserLogLock)
                    _browserLogBuffer.Clear();
            }

            if (Config.LoggingPreferences.TryGetValue(LogType.Browser, out LogLevel browserPref) && browserPref == LogLevel.Off)
            {
                try
                {
                    await DevTools.Log.Disable(null, cancellationToken).ConfigureAwait(false);
                }
                catch
                {
                    // ignore
                }

                return;
            }

            try
            {
                await DevTools.Log.Enable(null, cancellationToken).ConfigureAwait(false);
            }
            catch
            {
                // duplicate enable / transient errors
            }

            if (!_browserLogHandlersRegistered)
            {
                DevTools.Log.SubscribeToEntryAddedEvent(OnBrowserLogEntryAdded);
                _browserLogHandlersRegistered = true;
            }
        }

        private void OnBrowserLogEntryAdded(Zu.ChromeDevTools.Log.EntryAddedEvent evt)
        {
            if (evt?.Entry == null)
                return;

            LogLevel minimum = LogLevel.All;
            if (Config.LoggingPreferences.TryGetValue(LogType.Browser, out LogLevel pref))
                minimum = pref;
            if (minimum == LogLevel.Off)
                return;
            if (minimum != LogLevel.All && !BrowserLogLevelPassesFilter(evt.Entry.Level, minimum))
                return;

            LogEntry mapped = LogEntry.FromChromeDevTools(evt.Entry);
            lock (_browserLogLock)
                _browserLogBuffer.Add(mapped);
        }

        static bool BrowserLogLevelPassesFilter(string cdpLevel, LogLevel minimum)
        {
            int rank = CdpLevelRank(cdpLevel);
            int minRank = MinimumPreferenceRank(minimum);
            return rank >= minRank;
        }

        static int CdpLevelRank(string level)
        {
            return level?.ToLowerInvariant() switch
            {
                "verbose" => 0,
                "info" => 1,
                "warning" => 2,
                "error" => 3,
                _ => 1,
            };
        }

        static int MinimumPreferenceRank(LogLevel minimum)
        {
            return minimum switch
            {
                LogLevel.Debug => 0,
                LogLevel.Info => 1,
                LogLevel.Warning => 2,
                LogLevel.Severe => 3,
                _ => 0,
            };
        }

        public string GetBrowserDevToolsUrl()
        {
            var endpoint = DevTools?.Session?.EndpointAddress;
            if (!string.IsNullOrEmpty(endpoint) && Uri.TryCreate(endpoint, UriKind.Absolute, out var wsUri))
            {
                var wsParam = wsUri.Host + ":" + wsUri.Port + wsUri.PathAndQuery;
                return "http://127.0.0.1:" + Port + "/devtools/inspector.html?ws=" + wsParam;
            }

            return "http://127.0.0.1:" + Port + "/devtools/inspector.html";
        }

        public virtual async Task OpenBrowserDevTools()
        {
            BrowserDevToolsConfig ??= new ChromeDriverConfig();
            var childConfig = new ChromeDriverConfig(BrowserDevToolsConfig);
            childConfig.DoOpenBrowserDevTools = false;
            BrowserDevTools = new ZuChromeDriver(childConfig);
            await BrowserDevTools.Navigation.GoToUrl(GetBrowserDevToolsUrl()).ConfigureAwait(false);
        }

        public async Task CheckConnected(CancellationToken cancellationToken = default)
        {
            if (!DoConnectWhenCheckConnected)
                return;
            DoConnectWhenCheckConnected = false;
            if (!IsConnected)
            {
                await Connect(cancellationToken).ConfigureAwait(false);
            }
        }

        public async Task<ChromeProcessInfo> OpenChromeProfile(ChromeDriverConfig config)
        {
            ChromeProcessInfo res = null;
            await Task.Run(() => res = ChromeProfilesWorker.OpenChromeProfile(config)).ConfigureAwait(false); // userDir, Port, isHeadless));
            return res;
        }

        public void CloseSync()
        {
            BrowserDevTools?.CloseSync();
            if (IsConnected)
            {
                try
                {
                    DevTools.Browser.Close().GetAwaiter().GetResult();
                }
                catch
                {
                    // ignored
                }

                DevTools.Disconnect();
                IsConnected = false;
            }

            if (ChromeProcess?.Proc != null && !ChromeProcess.Proc.HasExited)
            {
                try
                {
                    ChromeProcess.Proc.CloseMainWindow();
                    ChromeProcess.Proc.Close();
                }
                catch
                {
                    try
                    {
                        ChromeProcess.Proc.Kill();
                    }
                    catch
                    {
                        // ignored
                    }
                }

                try
                {
                    while (!ChromeProcess.Proc.HasExited)
                    {
                        Thread.Sleep(250);
                    }
                }
                catch
                {
                    // ignored
                }
            }

            ChromeProcess?.Proc?.Dispose();
            ChromeProcess?.ProcWithJobObject?.TerminateProc();

            ChromeProcess = null;
            Thread.Sleep(1000);
            if (IsTempProfile && !string.IsNullOrWhiteSpace(UserDir))
            {
                try
                {
                    if (Directory.Exists(UserDir))
                        Directory.Delete(UserDir, true);
                }
                catch
                {
                    Thread.Sleep(3000);
                    try
                    {
                        if (Directory.Exists(UserDir))
                            Directory.Delete(UserDir, true);
                    }
                    catch
                    {
                        // ignored
                    }
                }
            }
        }

        public async Task<string> Close(CancellationToken cancellationToken = default)
        {
            try
            {
                if (DevTools != null && IsConnected)
                {
                    var sessions = await DevTools.GetSessions(Port).ConfigureAwait(false);
                    var pages = sessions?
                        .Where(s => string.Equals(s.Type, "page", StringComparison.OrdinalIgnoreCase))
                        .ToList();
                    if (pages != null && pages.Count > 1)
                    {
                        var currentId = DevTools.ConnectedTargetId;
                        var other = pages.FirstOrDefault(p => !string.Equals(p.Id, currentId, StringComparison.Ordinal));
                        if (other != null && !string.IsNullOrEmpty(currentId))
                        {
                            await SwitchDevToolsToTarget(other.Id, cancellationToken).ConfigureAwait(false);
                            await DevTools.Target.CloseTarget(new CloseTargetCommand { TargetId = currentId }, cancellationToken).ConfigureAwait(false);
                            return "ok";
                        }
                    }
                }
            }
            catch
            {
                // Fall through: tear down the browser like closing the last window.
            }

            try
            {
                if (BrowserDevTools != null)
                    await BrowserDevTools.Close(cancellationToken).ConfigureAwait(false);
            }
            catch
            {
                // ignored
            }

            if (IsConnected)
                await Disconnect(cancellationToken).ConfigureAwait(false);
            if (ChromeProcess?.Proc != null && !ChromeProcess.Proc.HasExited)
            {
                try
                {
                    ChromeProcess.Proc.CloseMainWindow();
                    ChromeProcess.Proc.Close();
                }
                catch
                {
                    try
                    {
                        ChromeProcess.Proc.Kill();
                    }
                    catch
                    {
                        // ignored
                    }
                }

                try
                {
                    while (!ChromeProcess.Proc.HasExited)
                    {
                        await Task.Delay(250, cancellationToken).ConfigureAwait(false);
                    }
                }
                catch
                {
                    //
                }
            }

            ChromeProcess?.Proc?.Dispose();
            if (ChromeProcess?.ProcWithJobObject != null)
            {
                ChromeProcess.ProcWithJobObject.TerminateProc();
            }

            ChromeProcess = null;
            await Task.Delay(1000, cancellationToken).ConfigureAwait(false);
            if (IsTempProfile && !string.IsNullOrWhiteSpace(UserDir))
            {
                try
                {
                    if (Directory.Exists(UserDir))
                        Directory.Delete(UserDir, true);
                }
                catch
                {
                    await Task.Delay(3000, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        if (Directory.Exists(UserDir))
                            Directory.Delete(UserDir, true);
                    }
                    catch
                    {
                        // ignored
                    }
                }
            }

            return "ok";
        }

        public async Task<string> GetPageSource(CancellationToken cancellationToken = default)
        {
            var res = await WindowCommands.GetPageSource(null, cancellationToken).ConfigureAwait(false);
            return res;
        }

        public async Task<string> GetTitle(CancellationToken cancellationToken = default)
        {
            var res = await WindowCommands.GetTitle(null, cancellationToken).ConfigureAwait(false);
            return res;
        }

        protected void SubscribeToDevToolsSessionEvent()
        {
            DevTools.Session.DevToolsEvent += DevToolsSessionEvent;
        }

        protected void UnsubscribeDevToolsSessionEvent()
        {
            DevTools.Session?.DevToolsEvent -= DevToolsSessionEvent;
        }

        private void DevToolsSessionEvent(object sender, string methodName, JsonNode eventData)
        {
            DevToolsEvent?.Invoke(sender, methodName, eventData);
        }

        public async Task Disconnect(CancellationToken cancellationToken = default)
        {
            await Task.Run(() => DevTools.Disconnect(), cancellationToken).ConfigureAwait(false);
            IsConnected = false;
            //DoConnectWhenCheckConnected = true;
        }

        public async Task<DevToolsCommandResult> SendDevToolsCommand(DevToolsCommandData commandData, CancellationToken cancellationToken = default)
        {
            try
            {
                var res = await DevTools.Session.SendCommand(commandData.CommandName, commandData.Params, cancellationToken, commandData.MillisecondsTimeout).ConfigureAwait(false);
                return new DevToolsCommandResult { Id = commandData.Id, Result = res };
            }
            catch (Exception ex)
            {
                return new DevToolsCommandResult { Id = commandData.Id, Error = ex.ToString() };
            }
        }
    }
}