// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Mirrors OpenQA.Selenium.ElementCoordinates (LocationInDom = element.Location; LocationInViewport = LocationOnScreenOnceScrolledIntoView).

using Zu.WebDriver.AsyncInteractions;
using Zu.WebDriver.BasicTypes;

namespace Zu.WebDriver
{
    internal sealed class WebElementCoordinates : ICoordinates
    {
        private readonly WebElement _element;

        public WebElementCoordinates(WebElement element)
        {
            _element = element ?? throw new ArgumentNullException(nameof(element));
        }

        /// <inheritdoc />
        public string AuxiliaryLocator => throw new NotImplementedException();

        /// <inheritdoc />
        public Task<WebPoint> LocationInDom(CancellationToken cancellationToken = default) =>
            _element.Location(cancellationToken);

        /// <inheritdoc />
        public Task<WebPoint> LocationInViewport(CancellationToken cancellationToken = default) =>
            _element.LocationOnScreenOnceScrolledIntoView(cancellationToken);

        /// <inheritdoc />
        public Task<WebPoint> LocationOnScreen(CancellationToken cancellationToken = default) =>
            throw new NotImplementedException();
    }
}
