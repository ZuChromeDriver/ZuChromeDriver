// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// This file is based on or incorporates material from the project Selenium, licensed under the Apache License, Version 2.0. More info in THIRD-PARTY-NOTICES file.

namespace Zu.WebDriver
{
    /// <summary>
    /// The exception that is thrown when a reference to an element is no longer valid.
    /// </summary>
    public class InvalidElementStateException : WebDriverException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidElementStateException"/> class.
        /// </summary>
        public InvalidElementStateException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidElementStateException"/> class with
        /// a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public InvalidElementStateException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidElementStateException"/> class with
        /// a specified error message and a reference to the inner exception that is the
        /// cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception,
        /// or <see langword="null"/> if no inner exception is specified.</param>
        public InvalidElementStateException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
