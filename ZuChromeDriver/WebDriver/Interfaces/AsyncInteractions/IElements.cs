// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// This file is based on or incorporates material from the project Selenium, licensed under the Apache License, Version 2.0. More info in THIRD-PARTY-NOTICES file.

using System.Text.Json.Nodes;
using Zu.WebDriver.BasicTypes;
//using Zu.WebDriver.Interactions.Internal;

namespace Zu.WebDriver.AsyncInteractions
{
    /// <summary>
    ///     Provides methods representing basic mouse actions.
    /// </summary>
    public interface IElements
    {
        /// <summary>
        ///     Clicks at a set of coordinates using the primary mouse button.
        /// </summary>
        /// <param name="elementId">An elementId describing where to click.</param>
        Task Click(string elementId, CancellationToken cancellationToken = default);

        Task<JsonNode> FindElement(string strategy, string expr, CancellationToken cancellationToken = default);

        Task<JsonNode> FindElement(string strategy, string expr, TimeSpan timeout, CancellationToken cancellationToken = default);

        Task<JsonNode> FindElement(string strategy, string expr, int timeoutMs, CancellationToken cancellationToken = default);

        Task<JsonNode> FindElement(string strategy, string expr, string startNode, CancellationToken cancellationToken = default);

        Task<JsonNode> FindElement(string strategy, string expr, string startNode, TimeSpan timeout, CancellationToken cancellationToken = default);

        Task<JsonNode> FindElement(string strategy, string expr, string startNode, int timeoutMs, CancellationToken cancellationToken = default);

        Task<JsonNode> FindElement(string strategy, string expr, string startNode, string notElementId, CancellationToken cancellationToken = default);

        Task<JsonNode> FindElement(string strategy, string expr, string startNode, string notElementId, TimeSpan timeout, CancellationToken cancellationToken = default);

        Task<JsonNode> FindElement(string strategy, string expr, string startNode, string notElementId, int timeoutMs, CancellationToken cancellationToken = default);

        Task<JsonNode> FindElements(string strategy, string expr, CancellationToken cancellationToken = default);

        Task<JsonNode> FindElements(string strategy, string expr, TimeSpan timeout, CancellationToken cancellationToken = default);

        Task<JsonNode> FindElements(string strategy, string expr, int timeoutMs, CancellationToken cancellationToken = default);

        Task<JsonNode> FindElements(string strategy, string expr, string startNode, CancellationToken cancellationToken = default);

        Task<JsonNode> FindElements(string strategy, string expr, string startNode, TimeSpan timeout, CancellationToken cancellationToken = default);

        Task<JsonNode> FindElements(string strategy, string expr, string startNode, int timeoutMs, CancellationToken cancellationToken = default);

        Task<JsonNode> FindElements(string strategy, string expr, string startNode, string notElementId, CancellationToken cancellationToken = default);

        Task<JsonNode> FindElements(string strategy, string expr, string startNode, string notElementId, TimeSpan timeout, CancellationToken cancellationToken = default);

        Task<JsonNode> FindElements(string strategy, string expr, string startNode, string notElementId, int timeoutMs, CancellationToken cancellationToken = default);

        Task<string> GetActiveElement(CancellationToken cancellationToken = default);

        Task<string> GetElementAttribute(string elementId, string attrName, CancellationToken cancellationToken = default);

        Task<string> GetElementProperty(string elementId, string propertyName, CancellationToken cancellationToken = default);

        Task<string> GetElementValueOfCssProperty(string elementId, string propertyName, CancellationToken cancellationToken = default);

        Task<string> GetElementTagName(string elementId, CancellationToken cancellationToken = default);

        Task<string> GetElementText(string elementId, CancellationToken cancellationToken = default);

        Task<WebRect> GetElementRect(string elementId, CancellationToken cancellationToken = default);

        Task<bool> IsElementDisplayed(string elementId, CancellationToken cancellationToken = default);

        Task<bool> IsElementEnabled(string elementId, CancellationToken cancellationToken = default);

        Task<bool> IsElementSelected(string elementId, CancellationToken cancellationToken = default);

        Task<string> SendKeysToElement(string elementId, string value, CancellationToken cancellationToken = default);

        Task<WebPoint> GetElementLocation(string elementId, CancellationToken cancellationToken = default);

        Task<WebSize> GetElementSize(string elementId, CancellationToken cancellationToken = default);

        Task<string> SubmitElement(string elementId, CancellationToken cancellationToken = default);

        Task<string> ClearElement(string elementId, CancellationToken cancellationToken = default);
    }
}