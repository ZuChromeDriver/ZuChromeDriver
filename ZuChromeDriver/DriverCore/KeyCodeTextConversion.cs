// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Port of chrome/test/chromedriver/keycode_text_conversion_win.cc (US keyboard layout).

using System.Runtime.InteropServices;

namespace Zu.Chrome.DriverCore
{
    internal static class KeyCodeTextConversion
    {
        private static readonly object UsLayoutLock = new();
        private static bool usLayoutActivated;

        static KeyCodeTextConversion()
        {
            if (OperatingSystem.IsWindows())
                TryActivateUsKeyboardLayout();
        }

        /// <summary>Matches chromedriver <c>SwitchToUSKeyboardLayout</c> for stable SendKeys text.</summary>
        private static void TryActivateUsKeyboardLayout()
        {
            lock (UsLayoutLock)
            {
                if (usLayoutActivated)
                    return;
                var hkl = LoadKeyboardLayoutW("00000409", KLF_ACTIVATE | KLF_SETFOR_PROCESS);
                usLayoutActivated = hkl != IntPtr.Zero && (unchecked((uint)(long)hkl) & 0xFFFF) == 0x0409;
            }
        }

        public static bool ConvertKeyCodeToText(int keyCode, int modifiers, out string text)
        {
            text = "";
            if (keyCode == 0x20)
            {
                text = " ";
                return true;
            }

            if (!OperatingSystem.IsWindows())
                return ConvertKeyCodeToTextFallback(keyCode, modifiers, out text);

            var scanCode = MapVirtualKeyW((uint)keyCode, 0);
            var keyboardState = new byte[256];
            if ((modifiers & KeyModifierMask.Shift) != 0)
                keyboardState[0x10] = 0x80;
            if ((modifiers & KeyModifierMask.Control) != 0)
                keyboardState[0x11] = 0x80;
            if ((modifiers & KeyModifierMask.Alt) != 0)
                keyboardState[0x12] = 0x80;

            var chars = new char[5];
            var code = ToUnicode((uint)keyCode, scanCode, keyboardState, chars, chars.Length, 0);
            if (code <= 0)
                return true;
            if (code == 1 && chars[0] <= 0xFF && char.IsControl(chars[0]))
                return true;

            text = new string(chars, 0, code);
            return true;
        }

        public static bool ConvertCharToKeyCode(char key, out int keyCode, out int necessaryModifiers)
        {
            keyCode = 0;
            necessaryModifiers = 0;
            if (!OperatingSystem.IsWindows())
                return ConvertCharToKeyCodeFallback(key, out keyCode, out necessaryModifiers);

            var vkeyAndModifiers = VkKeyScanW(key);
            if (vkeyAndModifiers == -1)
                return false;

            var vk = vkeyAndModifiers & 0xFF;
            if (vk == 0xFF)
                return false;

            keyCode = vk;
            var winModifiers = (vkeyAndModifiers >> 8) & 0xFF;
            if ((winModifiers & 0x01) != 0)
                necessaryModifiers |= KeyModifierMask.Shift;
            if ((winModifiers & 0x02) != 0)
                necessaryModifiers |= KeyModifierMask.Control;
            if ((winModifiers & 0x04) != 0)
                necessaryModifiers |= KeyModifierMask.Alt;
            return true;
        }

        private static bool ConvertKeyCodeToTextFallback(int keyCode, int modifiers, out string text)
        {
            text = "";
            if (keyCode >= 0x41 && keyCode <= 0x5A)
            {
                var c = (char)keyCode;
                if ((modifiers & KeyModifierMask.Shift) == 0)
                    c = char.ToLowerInvariant(c);
                text = c.ToString();
                return true;
            }

            if (keyCode >= 0x30 && keyCode <= 0x39)
            {
                text = ((char)keyCode).ToString();
                return true;
            }

            if (keyCode == 0x20)
            {
                text = " ";
                return true;
            }

            if (TryOemVirtualKeyToText(keyCode, modifiers, out text))
                return true;

            return true;
        }

        /// <summary>US-layout text for WebDriver special keys when <see cref="ToUnicode"/> returns nothing.</summary>
        public static bool TrySpecialPrintableKeyCodeToText(int keyCode, int modifiers, out string text)
        {
            if (keyCode >= 0x60 && keyCode <= 0x69)
            {
                text = ((char)('0' + (keyCode - 0x60))).ToString();
                return true;
            }

            text = keyCode switch
            {
                0x6A => "*",
                0x6B => "+",
                0x6D => "-",
                0x6E => ".",
                0x6F => "/",
                0xBA => ";",
                0xBB => "=",
                0xBC => ",",
                _ => null,
            };
            if (text == null)
                return false;
            if ((modifiers & KeyModifierMask.Shift) != 0)
            {
                text = keyCode switch
                {
                    0xBA => ":",
                    0xBB => "+",
                    0xBC => "<",
                    _ => text,
                };
            }

            return true;
        }

        private static bool TryOemVirtualKeyToText(int keyCode, int modifiers, out string text)
        {
            text = keyCode switch
            {
                0xBA => ";",
                0xBB => "=",
                0xBC => ",",
                0xBD => "-",
                0xBE => ".",
                0xBF => "/",
                0xC0 => "`",
                0xDB => "[",
                0xDC => "\\",
                0xDD => "]",
                0xDE => "'",
                _ => null,
            };
            if (text == null)
                return false;
            if ((modifiers & KeyModifierMask.Shift) != 0)
            {
                text = keyCode switch
                {
                    0xBA => ":",
                    0xBB => "+",
                    0xBC => "<",
                    0xBD => "_",
                    0xBE => ">",
                    0xBF => "?",
                    0xC0 => "~",
                    0xDB => "{",
                    0xDC => "|",
                    0xDD => "}",
                    0xDE => "\"",
                    _ => text,
                };
            }

            return true;
        }

        private static bool ConvertCharToKeyCodeFallback(char key, out int keyCode, out int necessaryModifiers)
        {
            necessaryModifiers = 0;
            if (key >= 'a' && key <= 'z')
            {
                keyCode = char.ToUpperInvariant(key);
                return true;
            }

            if (key >= 'A' && key <= 'Z')
            {
                keyCode = key;
                necessaryModifiers = KeyModifierMask.Shift;
                return true;
            }

            if (key >= '0' && key <= '9')
            {
                keyCode = key;
                return true;
            }

            if (key == ' ')
            {
                keyCode = 0x20;
                return true;
            }

            keyCode = 0;
            return false;
        }

        [DllImport("user32.dll")]
        private static extern short VkKeyScanW(char ch);

        [DllImport("user32.dll")]
        private static extern uint MapVirtualKeyW(uint uCode, uint uMapType);

        [DllImport("user32.dll")]
        private static extern int ToUnicode(
            uint wVirtKey,
            uint wScanCode,
            byte[] lpKeyState,
            char[] pwszBuff,
            int cchBuff,
            uint wFlags);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr LoadKeyboardLayoutW(string pwszKLID, uint flags);

        private const uint KLF_ACTIVATE = 0x00000001;
        private const uint KLF_SETFOR_PROCESS = 0x00000100;
    }
}
