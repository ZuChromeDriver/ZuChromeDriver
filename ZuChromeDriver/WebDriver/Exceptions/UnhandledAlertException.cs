// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// This file is based on or incorporates material from the project Selenium, licensed under the Apache License, Version 2.0. More info in THIRD-PARTY-NOTICES file.

namespace Zu.WebDriver
{
    /// <summary>
    /// The exception that is thrown when an unhandled alert is present.
    /// </summary>
    public class UnhandledAlertException : WebDriverException
    {
        private string alertText;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnhandledAlertException"/> class.
        /// </summary>
        public UnhandledAlertException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnhandledAlertException"/> class with
        /// a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public UnhandledAlertException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnhandledAlertException"/> class with
        /// a specified error message and alert text.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="alertText">The text of the unhandled alert.</param>
        public UnhandledAlertException(string message, string alertText)
            : base(message)
        {
            this.alertText = alertText;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnhandledAlertException"/> class with
        /// a specified error message and a reference to the inner exception that is the
        /// cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception,
        /// or <see langword="null"/> if no inner exception is specified.</param>
        public UnhandledAlertException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Gets the text of the unhandled alert.
        /// </summary>
        public string AlertText
        {
            get { return this.alertText; }
        }
    }
}
