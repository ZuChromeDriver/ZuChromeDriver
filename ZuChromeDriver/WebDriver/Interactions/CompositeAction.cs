// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// This file is based on or incorporates material from the project Selenium, licensed under the Apache License, Version 2.0. More info in THIRD-PARTY-NOTICES file.
using Zu.WebDriver.AsyncInteractions;

namespace Zu.WebDriver.Interactions
{
    /// <summary>
    ///     Defines an action that consists of a list of other actions to be performed in the browser.
    /// </summary>
    public class CompositeAction : IAction
    {
        private readonly List<IAction> actionsList = [];
        /// <summary>
        ///     Performs the actions defined in this list of actions.
        /// </summary>
        public async Task Perform(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var action in actionsList)
                await action.Perform(cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        ///     Adds an action to the list of actions to be performed.
        /// </summary>
        /// <param name = "action">
        ///     An <see cref = "IAction"/> to be appended to the
        ///     list of actions to be performed.
        /// </param>
        /// <returns>A self reference.</returns>
        public CompositeAction AddAction(IAction action)
        {
            actionsList.Add(action);
            return this;
        }
    }
}