// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// This file is based on or incorporates material from the Chromium Projects, licensed under the BSD-style license. More info in THIRD-PARTY-NOTICES file.

using System.Drawing;

namespace Zu.Chrome.DriverCore
{
    public class Session
    {
        public Stack<FrameInfo> Frames = new();

        public int Id { get; set; }

        public bool W3CCompliant = false;
        public bool Quit = false;
        public bool Detach = false;
        public bool ForceDevtoolsScreenshot = false;
        public int StickyModifiers = 0;
        public Point MousePosition;
        public bool AutoReportingEnabled = false;

        public TimeSpan PageLoadTimeout { get; set; }
        public TimeSpan ImplicitWait { get; set; }
        public TimeSpan ScriptTimeout { get; set; }

        public Session(int id)
        {
            Id = id;
        }

        public void SwitchToTopFrame()
        {
            Frames.Clear();
        }

        public void SwitchToParentFrame()
        {
            if (Frames.Any())
                Frames.Pop();
        }

        public void SwitchToSubFrame(string frameId, string cromeFrameId)
        {
            string parentFrameId = "";
            if (Frames.Any())
                parentFrameId = Frames.Peek().FrameId;
            Frames.Push(new FrameInfo(frameId, parentFrameId, cromeFrameId));
        }

        public string GetCurrentFrameId()
        {
            if (!Frames.Any())
                return "";
            return Frames.Peek().FrameId;
        }

        public string GetElementKey()
        {
            if (W3CCompliant == true)
                return ElementKeys.ElementKeyW3C;
            else
                return ElementKeys.ElementKey;
        }

        public string GetElementJsonString(string elementId) => $"{{\"{GetElementKey()}\":\"{elementId}\"}}";

    }
}
