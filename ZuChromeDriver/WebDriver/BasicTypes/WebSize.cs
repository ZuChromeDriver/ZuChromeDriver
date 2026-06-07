// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Zu.WebDriver.BasicTypes
{
    public class WebSize
    {
        public WebSize(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Width { get; set; } = 0;
        public int Height { get; set; } = 0;

        public override bool Equals(object obj)
        {
            return obj is WebSize other && other.Width == Width && other.Height == Height;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return Width * 397 ^ Height;
            }
        }

        public override string ToString()
        {
            return $"WebSize: {Width}, {Height}";
        }
    }
}
