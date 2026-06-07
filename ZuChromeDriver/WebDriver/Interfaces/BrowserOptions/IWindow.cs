// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// This file is based on or incorporates material from the project Selenium, licensed under the Apache License, Version 2.0. More info in THIRD-PARTY-NOTICES file.

using Zu.WebDriver.BasicTypes;

namespace Zu.WebDriver.BrowserOptions
{
    /// <summary>
    ///     Provides methods for getting and setting the size and position of the browser window.
    /// </summary>
    public interface IWindow
    {
        /// <summary>
        ///     Gets the position of the browser window relative to the upper-left corner of the screen.
        /// </summary>
        /// <remarks>When setting this property, it should act as the JavaScript window.moveTo() method.</remarks>
        Task<WebPoint> GetPosition(CancellationToken cancellationToken = default);

        /// <summary>
        ///     Sets the position of the browser window relative to the upper-left corner of the screen.
        /// </summary>
        /// <remarks>When setting this property, it should act as the JavaScript window.moveTo() method.</remarks>
        Task SetPosition(WebPoint pos, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Gets or sets the size of the outer browser window, including title bars and window borders.
        /// </summary>
        /// <remarks>When setting this property, it should act as the JavaScript window.resizeTo() method.</remarks>
        Task<WebSize> GetSize(CancellationToken cancellationToken = default);
      
        /// <summary>
        ///     Sets the size of the outer browser window, including title bars and window borders.
        /// </summary>
        /// <remarks>When setting this property, it should act as the JavaScript window.resizeTo() method.</remarks>
        Task SetSize(WebSize size, CancellationToken cancellationToken = default);

        /// <summary>
        ///     Maximizes the current window if it is not already maximized.
        /// </summary>
        Task Maximize(CancellationToken cancellationToken = default);
    }
}