// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Modifier masks aligned with chrome/test/chromedriver/chrome/ui_events.h and CDP Input.dispatchKeyEvent.

namespace Zu.Chrome.DriverCore
{
    public static class KeyModifierMask
    {
        public const int Alt = 1 << 0;
        public const int Control = 1 << 1;
        public const int Meta = 1 << 2;
        public const int Shift = 1 << 3;
        /// <summary>Used for numpad keys (CDP isKeypad), not sent as a modifier bit.</summary>
        public const int NumLock = 1 << 4;
    }
}
