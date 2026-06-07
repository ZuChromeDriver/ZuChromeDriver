// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Diagnostics.CodeAnalysis;
using Zu.Chrome.DriverCore;
using Zu.WebDriver.BasicTypes;

namespace Zu.WebDriver
{
    internal static class DriverCoreExceptionMapper
    {
        internal static Exception MapException(Exception ex)
        {
            if (ex is not DriverCoreException dce)
                return ex;
            if (string.Equals(dce.Error, "unexpected alert open", StringComparison.OrdinalIgnoreCase))
                return new UnhandledAlertException(dce.Message, dce.AlertText ?? string.Empty);
            return new WebBrowserException(dce.Message)
            {
                Error = dce.Error,
                Json = dce.Json
            };
        }

        [DoesNotReturn]
        internal static void RethrowMapped(Exception ex)
        {
            throw MapException(ex);
        }
    }
}
