// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Key event model aligned with chrome/test/chromedriver/chrome/ui_events.h.

namespace Zu.Chrome.DriverCore
{
    public enum KeyEventType
    {
        KeyDown,
        KeyUp,
        RawKeyDown,
        Char,
    }

    public sealed class KeyEvent
    {
        public KeyEventType Type { get; set; }
        public int Modifiers { get; set; }
        public string ModifiedText { get; set; } = "";
        public string UnmodifiedText { get; set; } = "";
        public string Key { get; set; } = "";
        public int KeyCode { get; set; }
        public int Location { get; set; }
        public string Code { get; set; } = "";
        /// <summary>Original WebDriver key code point when the stroke came from the PUA range.</summary>
        public char WebDriverSourceKey { get; set; }
        /// <summary>Use DOM <c>keyDown</c> instead of <c>rawKeyDown</c> (Enter / form submit parity).</summary>
        public bool UseDomKeyDown { get; set; }
    }
}
