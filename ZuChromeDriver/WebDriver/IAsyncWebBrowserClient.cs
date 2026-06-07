// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Zu.WebDriver.AsyncInteractions;
using Zu.WebDriver.BrowserOptions;

namespace Zu.WebBrowser
{

    public interface IAsyncWebBrowserClient
    {
        INavigation Navigation { get; }
        IMouse Mouse { get; }
        IKeyboard Keyboard { get; }
        IJavaScriptExecutor JavaScriptExecutor { get; }
        IOptions Options { get; }
        ITargetLocator TargetLocator { get; }
        IElements Elements { get; }

        IAlert Alert { get; }
        ICoordinates Coordinates { get; }
        ITakesScreenshot Screenshot { get; }
        ITouchScreen TouchScreen { get; }
        IActionExecutor ActionExecutor { get; }

        Task<string> Connect(CancellationToken cancellationToken = default);
        Task CheckConnected(CancellationToken cancellationToken = default);
        Task Disconnect(CancellationToken cancellationToken = default);
        Task<string> Close(CancellationToken cancellationToken = default);
        void CloseSync();

        Task<string> GetPageSource(CancellationToken cancellationToken = default);

        Task<string> GetTitle(CancellationToken cancellationToken = default);
    }
}