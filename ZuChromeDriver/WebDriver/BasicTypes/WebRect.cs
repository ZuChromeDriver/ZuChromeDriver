// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Zu.WebDriver.BasicTypes
{
    public class WebRect
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public WebRect(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
        public WebRect(WebPoint point, WebSize size)
        {
            X = point.X;
            Y = point.Y;
            Width = size.Width;
            Height = size.Height;
        }
        public WebPoint Offset(int x, int y) => new(X + x, Y + y);

        public override string ToString()
        {
            return $"WebRect: {X}, {Y}, {Width}, {Height}";
        }

        public WebSize Size() => new(Width, Height);
        public WebPoint Point() => new(X, Y);
    }
}
