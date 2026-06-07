// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Port of chrome/test/chromedriver/key_converter.cc (ConvertKeysToKeyEvents).

namespace Zu.Chrome.DriverCore
{
    public static class KeyConverter
    {
        private const char WebDriverNullKey = '\uE000';
        private const char WebDriverShiftKey = '\uE008';
        private const char WebDriverControlKey = '\uE009';
        private const char WebDriverAltKey = '\uE00A';
        private const char WebDriverCommandKey = '\uE03D';
        private const char WebDriverRightShiftKey = '\uE050';
        private const char WebDriverRightControlKey = '\uE051';
        private const char WebDriverRightAltKey = '\uE052';
        private const char WebDriverRightCommandKey = '\uE053';

        // Mirrors chrome/test/chromedriver/key_converter.cc kSpecialWebDriverKeys (index = code point - 0xE000).
        // Stored as a dictionary so unassigned PUA slots are never mistaken for special keys.
        private static readonly Dictionary<char, int> SpecialWebDriverKeyCodes = BuildSpecialWebDriverKeyCodes();

        private static Dictionary<char, int> BuildSpecialWebDriverKeyCodes()
        {
            var table = new[]
            {
                0x00, 0x03, 0x00, 0x08, 0x09, 0x0C, 0x0D, 0x0D, 0x10, 0x11, 0x12, 0x13, 0x1B, 0x20,
                0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x2D, 0x2E, 0xBA, 0xBB,
                0x60, 0x61, 0x62, 0x63, 0x64, 0x65, 0x66, 0x67, 0x68, 0x69, 0x6A, 0x6B, 0xBC, 0x6D, 0x6E, 0x6F,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0x70, 0x71, 0x72, 0x73, 0x74, 0x75, 0x76, 0x77, 0x78, 0x79, 0x7A, 0x7B, 0x5B, 0x00, 0x00,
                0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
                0xA1, 0xA3, 0xA2, 0x5C, 0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x2D, 0x2E,
            };
            if (table.Length != 0x5E)
                throw new InvalidOperationException($"SpecialWebDriver key table length {table.Length}, expected {0x5E}");

            var map = new Dictionary<char, int>();
            for (var i = 0; i < table.Length; i++)
            {
                if (table[i] == 0)
                    continue;
                map[(char)(0xE000 + i)] = table[i];
            }

            if (!map.TryGetValue('\uE037', out var f7) || f7 != 0x76)
                throw new InvalidOperationException("WebDriver F7 (\\uE037) must map to VK 0x76");
            if (!map.TryGetValue('\uE038', out var f8) || f8 != 0x77)
                throw new InvalidOperationException("WebDriver F8 (\\uE038) must map to VK 0x77");

            return map;
        }

        private static readonly (int Mask, int KeyCode)[] ModifierKeys =
        {
            (KeyModifierMask.Shift, 0x10),
            (KeyModifierMask.Control, 0x11),
            (KeyModifierMask.Alt, 0x12),
            (KeyModifierMask.Meta, 0x5B),
        };

        public static IReadOnlyList<KeyEvent> ConvertKeysToKeyEvents(
            string keys,
            bool releaseModifiers,
            ref int stickyModifiers)
        {
            var keyEvents = new List<KeyEvent>();
            var sequence = keys;
            if (releaseModifiers)
                sequence += WebDriverNullKey;

            var sticky = stickyModifiers;
            for (var i = 0; i < sequence.Length; i++)
            {
                var key = sequence[i];
                if (key == WebDriverNullKey)
                {
                    ReleaseStickyModifiers(sticky, keyEvents);
                    sticky = 0;
                    continue;
                }

                if (IsModifierKey(key))
                {
                    ToggleModifierKey(key, ref sticky, keyEvents);
                    continue;
                }

                var keyCode = 0;
                var unmodifiedText = "";
                var modifiedText = "";
                var allModifiers = sticky;

                var skip = false;
                if (TryKeyCodeFromSpecialWebDriverKey(key, out keyCode) ||
                    TryKeyCodeFromShorthandKey(key, out keyCode, out skip))
                {
                    if (skip)
                        continue;
                    if (keyCode == 0)
                        throw new DriverCoreException($"unknown WebDriver key({(int)key}) at string index {i}", "invalid argument");

                    if (keyCode == 0x0D)
                    {
                        modifiedText = unmodifiedText = "\r";
                    }
                    else if (IsSpecialKeyPrintable(keyCode))
                    {
                        var webdriverModifiers = 0;
                        if (keyCode >= 0x60 && keyCode <= 0x69)
                            webdriverModifiers = KeyModifierMask.NumLock;
                        if (!KeyCodeTextConversion.ConvertKeyCodeToText(keyCode, webdriverModifiers, out unmodifiedText))
                            throw new DriverCoreException("failed to convert key code to text", "unknown error");
                        if (!KeyCodeTextConversion.ConvertKeyCodeToText(keyCode, allModifiers | webdriverModifiers, out modifiedText))
                            throw new DriverCoreException("failed to convert key code to text", "unknown error");
                        if (string.IsNullOrEmpty(unmodifiedText) || string.IsNullOrEmpty(modifiedText))
                        {
                            if (keyCode == 0x20)
                            {
                                unmodifiedText = modifiedText = " ";
                            }
                            else if (KeyCodeTextConversion.TrySpecialPrintableKeyCodeToText(
                                         keyCode, allModifiers | webdriverModifiers, out var specialText))
                            {
                                unmodifiedText = modifiedText = specialText;
                            }
                            else if (key < '\uE000')
                            {
                                unmodifiedText = key.ToString();
                                modifiedText = key.ToString();
                            }
                        }
                    }
                }
                else
                {
                    var necessaryModifiers = 0;
                    if (!KeyCodeTextConversion.ConvertCharToKeyCode(key, out keyCode, out necessaryModifiers))
                    {
                        unmodifiedText = key.ToString();
                        modifiedText = key.ToString();
                        keyCode = 0;
                    }
                    else
                    {
                        allModifiers |= necessaryModifiers;
                        if (keyCode != 0)
                        {
                            KeyCodeTextConversion.ConvertKeyCodeToText(keyCode, 0, out unmodifiedText);
                            KeyCodeTextConversion.ConvertKeyCodeToText(keyCode, allModifiers, out modifiedText);
                            if (string.IsNullOrEmpty(unmodifiedText) || string.IsNullOrEmpty(modifiedText))
                            {
                                var isModifierChord = (allModifiers & (KeyModifierMask.Control | KeyModifierMask.Alt | KeyModifierMask.Meta)) != 0;
                                if (isModifierChord)
                                {
                                    // key_converter.cc: no char event for Ctrl+X and similar chords.
                                    unmodifiedText = "";
                                    modifiedText = "";
                                }
                                else if (key < '\uE000')
                                {
                                    unmodifiedText = key.ToString();
                                    modifiedText = key.ToString();
                                }
                                else
                                {
                                    unmodifiedText = "";
                                    modifiedText = "";
                                }
                            }
                        }
                        else
                        {
                            unmodifiedText = key.ToString();
                            modifiedText = key.ToString();
                        }
                    }
                }

                var necessaryModifierPresses = new bool[ModifierKeys.Length];
                for (var j = 0; j < ModifierKeys.Length; j++)
                {
                    necessaryModifierPresses[j] = (allModifiers & ModifierKeys[j].Mask) != 0 &&
                                                  (sticky & ModifierKeys[j].Mask) == 0;
                    if (necessaryModifierPresses[j])
                    {
                        // Chromedriver: temporary modifier down uses sticky only (not sticky | mask).
                        keyEvents.Add(CreateModifierKeyEvent(
                            KeyEventType.RawKeyDown,
                            ModifierKeys[j].KeyCode,
                            sticky));
                    }
                }

                GenerateKeyStroke(keyEvents, keyCode, allModifiers, unmodifiedText, modifiedText, key, key);

                for (var j = ModifierKeys.Length - 1; j >= 0; j--)
                {
                    if (!necessaryModifierPresses[j])
                        continue;
                    // Chromedriver: modifier keyUp always uses modifiers 0 (key_converter_unittest).
                    keyEvents.Add(CreateModifierKeyEvent(
                        KeyEventType.KeyUp,
                        ModifierKeys[j].KeyCode,
                        0));
                }
            }

            stickyModifiers = sticky;
            return keyEvents;
        }

        private static void GenerateKeyStroke(
            List<KeyEvent> keyEvents,
            int keyCode,
            int modifiers,
            string unmodifiedText,
            string modifiedText,
            char sourceKey,
            char webDriverSourceKey)
        {
            // Chromedriver key_converter uses rawKeyDown for Enter; DOM keyDown with Text=\r plus char doubles newlines in textarea.
            var useDomKeyDown = false;
            keyEvents.Add(new KeyEvent
            {
                Type = useDomKeyDown ? KeyEventType.KeyDown : KeyEventType.RawKeyDown,
                KeyCode = keyCode,
                Modifiers = modifiers,
                ModifiedText = modifiedText,
                UnmodifiedText = unmodifiedText,
                Key = ResolveDomKey(keyCode, modifiers, modifiedText, sourceKey),
                Code = ResolveDomCode(keyCode, sourceKey),
                Location = GetKeyLocation(sourceKey),
                WebDriverSourceKey = webDriverSourceKey,
                UseDomKeyDown = useDomKeyDown,
            });

            if (!string.IsNullOrEmpty(modifiedText) || !string.IsNullOrEmpty(unmodifiedText))
            {
                keyEvents.Add(new KeyEvent
                {
                    Type = KeyEventType.Char,
                    KeyCode = keyCode,
                    Modifiers = modifiers,
                    ModifiedText = modifiedText,
                    UnmodifiedText = unmodifiedText,
                    Key = ResolveDomKey(keyCode, modifiers, modifiedText, sourceKey),
                    Code = ResolveDomCode(keyCode, sourceKey),
                    Location = GetKeyLocation(sourceKey),
                    WebDriverSourceKey = webDriverSourceKey,
                });
            }

            keyEvents.Add(new KeyEvent
            {
                Type = KeyEventType.KeyUp,
                KeyCode = keyCode,
                Modifiers = modifiers,
                ModifiedText = modifiedText,
                UnmodifiedText = unmodifiedText,
                Key = ResolveDomKey(keyCode, modifiers, modifiedText, sourceKey),
                Code = ResolveDomCode(keyCode, sourceKey),
                Location = GetKeyLocation(sourceKey),
                WebDriverSourceKey = webDriverSourceKey,
                UseDomKeyDown = useDomKeyDown,
            });
        }

        private static void ReleaseStickyModifiers(int sticky, List<KeyEvent> keyEvents)
        {
            if ((sticky & KeyModifierMask.Shift) != 0)
                keyEvents.Add(BuildModifierKeyUp(0x10));
            if ((sticky & KeyModifierMask.Control) != 0)
                keyEvents.Add(BuildModifierKeyUp(0x11));
            if ((sticky & KeyModifierMask.Alt) != 0)
                keyEvents.Add(BuildModifierKeyUp(0x12));
            if ((sticky & KeyModifierMask.Meta) != 0)
                keyEvents.Add(BuildModifierKeyUp(0x5B));
        }

        private static KeyEvent BuildModifierKeyUp(int keyCode) =>
            CreateModifierKeyEvent(KeyEventType.KeyUp, keyCode, 0);

        private static KeyEvent CreateModifierKeyEvent(KeyEventType type, int keyCode, int modifiers)
        {
            var sourceKey = keyCode switch
            {
                0x10 => WebDriverShiftKey,
                0x11 => WebDriverControlKey,
                0x12 => WebDriverAltKey,
                0x5B => WebDriverCommandKey,
                _ => '\0',
            };
            return new KeyEvent
            {
                Type = type,
                KeyCode = keyCode,
                Modifiers = modifiers,
                Code = ResolveDomCode(keyCode, sourceKey),
                Key = ResolveDomKey(keyCode, modifiers, "", sourceKey),
                WebDriverSourceKey = sourceKey,
            };
        }

        private static void ToggleModifierKey(char key, ref int sticky, List<KeyEvent> keyEvents)
        {
            var keyCode = 0;
            switch (key)
            {
                case WebDriverShiftKey:
                case WebDriverRightShiftKey:
                    sticky ^= KeyModifierMask.Shift;
                    keyCode = 0x10;
                    break;
                case WebDriverControlKey:
                case WebDriverRightControlKey:
                    sticky ^= KeyModifierMask.Control;
                    keyCode = 0x11;
                    break;
                case WebDriverAltKey:
                case WebDriverRightAltKey:
                    sticky ^= KeyModifierMask.Alt;
                    keyCode = 0x12;
                    break;
                case WebDriverCommandKey:
                case WebDriverRightCommandKey:
                    sticky ^= KeyModifierMask.Meta;
                    keyCode = 0x5B;
                    break;
                default:
                    throw new DriverCoreException("unknown modifier key", "invalid argument");
            }

            var modifierDown = (sticky & ModifierMaskForKeyCode(keyCode)) != 0;
            keyEvents.Add(CreateModifierKeyEvent(
                modifierDown ? KeyEventType.RawKeyDown : KeyEventType.KeyUp,
                keyCode,
                sticky));
        }

        private static int ModifierMaskForKeyCode(int keyCode) =>
            keyCode switch
            {
                0x10 => KeyModifierMask.Shift,
                0x11 => KeyModifierMask.Control,
                0x12 => KeyModifierMask.Alt,
                0x5B => KeyModifierMask.Meta,
                _ => 0,
            };

        private static bool IsModifierKey(char key) =>
            key is WebDriverShiftKey or WebDriverControlKey or WebDriverAltKey or WebDriverCommandKey
                or WebDriverRightShiftKey or WebDriverRightControlKey or WebDriverRightAltKey
                or WebDriverRightCommandKey;

        private static bool TryKeyCodeFromSpecialWebDriverKey(char key, out int keyCode) =>
            SpecialWebDriverKeyCodes.TryGetValue(key, out keyCode);

        private static bool TryKeyCodeFromShorthandKey(char key, out int keyCode, out bool skip)
        {
            skip = false;
            keyCode = 0;
            switch (key)
            {
                case '\n':
                    keyCode = 0x0D;
                    return true;
                case '\t':
                    keyCode = 0x09;
                    return true;
                case '\b':
                    keyCode = 0x08;
                    return true;
                case ' ':
                    keyCode = 0x20;
                    return true;
                case '\r':
                    skip = true;
                    return true;
                default:
                    return false;
            }
        }

        private static bool IsSpecialKeyPrintable(int keyCode) =>
            keyCode == 0x09 || keyCode == 0x20 || keyCode == 0xBA || keyCode == 0xBB ||
            (keyCode >= 0x60 && keyCode <= 0x6F) || keyCode == 0xBC;

        private static int GetKeyLocation(char key)
        {
            var codePoint = (int)key;
            if (codePoint >= 0xE007 && codePoint <= 0xE00A)
                return 1;
            if (codePoint >= 0xE01A && codePoint <= 0xE029)
                return 3;
            if (codePoint == 0xE03D)
                return 1;
            if (codePoint >= 0xE050 && codePoint <= 0xE053)
                return 2;
            if (codePoint >= 0xE054 && codePoint <= 0xE05D)
                return 3;
            return 0;
        }

        private static string ResolveDomCode(int keyCode, char sourceKey)
        {
            if (sourceKey >= 0xE000)
            {
                return sourceKey switch
                {
                    '\uE003' => "Backspace",
                    '\uE004' => "Tab",
                    '\uE006' or '\uE007' => "Enter",
                    '\uE008' => "ShiftLeft",
                    '\uE009' => "ControlLeft",
                    '\uE00A' => "AltLeft",
                    '\uE00C' => "Escape",
                    '\uE00D' => "Space",
                    '\uE00E' => "PageUp",
                    '\uE00F' => "PageDown",
                    '\uE010' => "End",
                    '\uE011' => "Home",
                    '\uE012' => "ArrowLeft",
                    '\uE013' => "ArrowUp",
                    '\uE014' => "ArrowRight",
                    '\uE015' => "ArrowDown",
                    '\uE016' => "Insert",
                    '\uE017' => "Delete",
                    '\uE018' => "Semicolon",
                    '\uE019' => "Equal",
                    '\uE01A' => "Numpad0",
                    '\uE01B' => "Numpad1",
                    '\uE01C' => "Numpad2",
                    '\uE01D' => "Numpad3",
                    '\uE01E' => "Numpad4",
                    '\uE01F' => "Numpad5",
                    '\uE020' => "Numpad6",
                    '\uE021' => "Numpad7",
                    '\uE022' => "Numpad8",
                    '\uE023' => "Numpad9",
                    '\uE024' => "NumpadMultiply",
                    '\uE025' => "NumpadAdd",
                    '\uE026' => "NumpadComma",
                    '\uE027' => "NumpadSubtract",
                    '\uE028' => "NumpadDecimal",
                    '\uE029' => "NumpadDivide",
                    '\uE031' => "F1",
                    '\uE032' => "F2",
                    '\uE033' => "F3",
                    '\uE034' => "F4",
                    '\uE035' => "F5",
                    '\uE036' => "F6",
                    '\uE037' => "F7",
                    '\uE038' => "F8",
                    '\uE039' => "F9",
                    '\uE03A' => "F10",
                    '\uE03B' => "F11",
                    '\uE03C' => "F12",
                    '\uE03D' => "MetaLeft",
                    '\uE050' => "ShiftRight",
                    '\uE051' => "ControlRight",
                    '\uE052' => "AltRight",
                    '\uE053' => "MetaRight",
                    _ => UsLayoutVirtualKeyToDomCode(keyCode),
                };
            }

            if (sourceKey >= 'a' && sourceKey <= 'z')
                return "Key" + char.ToUpperInvariant(sourceKey);
            if (sourceKey >= 'A' && sourceKey <= 'Z')
                return "Key" + sourceKey;
            if (sourceKey >= '0' && sourceKey <= '9')
                return "Digit" + sourceKey;

            return sourceKey switch
            {
                ' ' => "Space",
                _ => UsLayoutVirtualKeyToDomCode(keyCode),
            };
        }

        private static string ResolveDomKey(int keyCode, int modifiers, string modifiedText, char sourceKey)
        {
            if (!string.IsNullOrEmpty(modifiedText) && modifiedText.Length == 1)
                return modifiedText;
            if (sourceKey >= 0xE000 && sourceKey <= 0xE03D)
            {
                return sourceKey switch
                {
                    '\uE008' => "Shift",
                    '\uE009' => "Control",
                    '\uE00A' => "Alt",
                    '\uE03D' => "Meta",
                    '\uE00D' => " ",
                    '\uE006' or '\uE007' => "Enter",
                    _ => UsLayoutVirtualKeyToDomKey(keyCode, modifiers),
                };
            }

            return UsLayoutVirtualKeyToDomKey(keyCode, modifiers);
        }

        private static string UsLayoutVirtualKeyToDomCode(int keyCode) =>
            keyCode switch
            {
                0x08 => "Backspace",
                0x09 => "Tab",
                0x0D => "Enter",
                0x10 => "ShiftLeft",
                0x11 => "ControlLeft",
                0x12 => "AltLeft",
                0x13 => "Pause",
                0x1B => "Escape",
                0x20 => "Space",
                0x21 => "PageUp",
                0x22 => "PageDown",
                0x23 => "End",
                0x24 => "Home",
                0x25 => "ArrowLeft",
                0x26 => "ArrowUp",
                0x27 => "ArrowRight",
                0x28 => "ArrowDown",
                0x2D => "Insert",
                0x2E => "Delete",
                >= 0x30 and <= 0x39 => "Digit" + (char)keyCode,
                >= 0x41 and <= 0x5A => "Key" + (char)keyCode,
                0x5B => "MetaLeft",
                0xBA => "Semicolon",
                0xBB => "Equal",
                0xBC => "Comma",
                >= 0x60 and <= 0x69 => "Numpad" + (keyCode - 0x60),
                0x6A => "NumpadMultiply",
                0x6B => "NumpadAdd",
                0x6D => "NumpadSubtract",
                0x6E => "NumpadDecimal",
                0x6F => "NumpadDivide",
                >= 0x70 and <= 0x7B => "F" + (keyCode - 0x6F),
                0xA1 => "ShiftRight",
                0xA2 => "AltRight",
                0xA3 => "ControlRight",
                _ => "",
            };

        private static string UsLayoutVirtualKeyToDomKey(int keyCode, int modifiers)
        {
            if (keyCode >= 0x41 && keyCode <= 0x5A)
            {
                var c = (char)keyCode;
                return (modifiers & KeyModifierMask.Shift) != 0 ? c.ToString() : char.ToLowerInvariant(c).ToString();
            }

            return keyCode switch
            {
                0x10 => "Shift",
                0x11 => "Control",
                0x12 => "Alt",
                0x5B => "Meta",
                0x20 => " ",
                0x0D => "Enter",
                _ => "",
            };
        }
    }
}
