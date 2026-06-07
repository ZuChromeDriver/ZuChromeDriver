// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// This file is based on or incorporates material from the project Selenium, licensed under the Apache License, Version 2.0. More info in THIRD-PARTY-NOTICES file.

using Zu.WebDriver.BasicTypes;

namespace Zu.WebDriver.AsyncInteractions
{
    /// <summary>
    ///     Defines the interface used to take screen shot images of the screen.
    /// </summary>
    public interface ITakesScreenshot
    {
        /// <summary>
        ///     Gets a <see cref="Screenshot" /> object representing the image of the page on the screen.
        /// </summary>
        /// <returns>A <see cref="Screenshot" /> object containing the image.</returns>
        Task<Screenshot> GetScreenshot(CancellationToken cancellationToken = default);
    }
}