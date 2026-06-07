// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Drawing;
using Zu.Chrome;
using Zu.Chrome.DriverCore;
using Zu.ChromeDevTools.Input;
using Zu.WebDriver.AsyncInteractions;
using Zu.WebDriver.BasicTypes;

namespace Zu.ChromeWebDriver
{
    /// <summary>
    /// Touch input via CDP <c>Input.dispatchTouchEvent</c>, aligned with
    /// <c>WebViewImpl::DispatchTouchEvent</c> / <c>DispatchTouchEventsForMouseEvents</c> in Chromium Chromedriver.
    /// </summary>
    public class ChromeDriverTouchScreen : ITouchScreen
    {
        /// <summary>Matches <c>kFlickTouchEventsPerSecond</c> in Chromedriver <c>element_commands.cc</c>.</summary>
        private const int FlickTouchEventsPerSecond = 30;

        private WebView _webView;
        private Session _session;

        public ChromeDriverTouchScreen(IChromeDriver ZuChromeDriver)
        {
            if (ZuChromeDriver == null)
                throw new ArgumentNullException(nameof(ZuChromeDriver));
            _webView = ZuChromeDriver.WebView;
            _session = ZuChromeDriver.Session;
        }

        public async Task DoubleTap(ICoordinates where, CancellationToken cancellationToken = default)
        {
            await SingleTap(where, cancellationToken).ConfigureAwait(false);
            await Task.Delay(50, cancellationToken).ConfigureAwait(false);
            await SingleTap(where, cancellationToken).ConfigureAwait(false);
        }

        public async Task Down(int locationX, int locationY, CancellationToken cancellationToken = default)
        {
            var p = new WebPoint(locationX, locationY);
            await DispatchTouchAsync(ChromeDriverMouse.TouchStart, p, cancellationToken).ConfigureAwait(false);
            _session.MousePosition = new Point(p.X, p.Y);
        }

        public Task Flick(int speedX, int speedY, CancellationToken cancellationToken = default)
        {
            if (speedX == 0 && speedY == 0)
                return Task.CompletedTask;
            var start = new WebPoint(_session.MousePosition.X, _session.MousePosition.Y);
            var speedScalar = (int)Math.Ceiling(Math.Sqrt(speedX * (long)speedX + speedY * (long)speedY));
            if (speedScalar < 1)
                speedScalar = 1;
            return FlickFromPointAsync(start, speedX, speedY, speedScalar, cancellationToken);
        }

        public async Task Flick(ICoordinates where, int offsetX, int offsetY, int speed,
            CancellationToken cancellationToken = default)
        {
            if (where == null)
                throw new ArgumentNullException(nameof(where));
            if (speed < 1)
                throw new ArgumentOutOfRangeException(nameof(speed), speed, "Speed must be a positive integer (Chromedriver touch flick).");
            var start = await where.LocationInViewport(cancellationToken).ConfigureAwait(false);
            await FlickFromPointAsync(start, offsetX, offsetY, speed, cancellationToken).ConfigureAwait(false);
        }

        public async Task LongPress(ICoordinates where, CancellationToken cancellationToken = default)
        {
            var loc = await where.LocationInViewport(cancellationToken).ConfigureAwait(false);
            await Down(loc.X, loc.Y, cancellationToken).ConfigureAwait(false);
            await Task.Delay(1000, cancellationToken).ConfigureAwait(false);
            await Up(loc.X, loc.Y, cancellationToken).ConfigureAwait(false);
        }

        public async Task Move(int locationX, int locationY, CancellationToken cancellationToken = default)
        {
            var p = new WebPoint(locationX, locationY);
            await DispatchTouchAsync(ChromeDriverMouse.TouchMove, p, cancellationToken).ConfigureAwait(false);
            _session.MousePosition = new Point(p.X, p.Y);
        }

        public async Task Scroll(ICoordinates where, int offsetX, int offsetY,
            CancellationToken cancellationToken = default)
        {
            var start = await where.LocationInViewport(cancellationToken).ConfigureAwait(false);
            await Down(start.X, start.Y, cancellationToken).ConfigureAwait(false);
            await Move(start.X + offsetX, start.Y + offsetY, cancellationToken).ConfigureAwait(false);
            await Up(start.X + offsetX, start.Y + offsetY, cancellationToken).ConfigureAwait(false);
        }

        public async Task Scroll(int offsetX, int offsetY, CancellationToken cancellationToken = default)
        {
            var p = _session.MousePosition;
            await Down(p.X, p.Y, cancellationToken).ConfigureAwait(false);
            await Move(p.X + offsetX, p.Y + offsetY, cancellationToken).ConfigureAwait(false);
            await Up(p.X + offsetX, p.Y + offsetY, cancellationToken).ConfigureAwait(false);
        }

        public async Task SingleTap(ICoordinates where, CancellationToken cancellationToken = default)
        {
            var loc = await where.LocationInViewport(cancellationToken).ConfigureAwait(false);
            await Down(loc.X, loc.Y, cancellationToken).ConfigureAwait(false);
            await Up(loc.X, loc.Y, cancellationToken).ConfigureAwait(false);
        }

        public async Task Up(int locationX, int locationY, CancellationToken cancellationToken = default)
        {
            await DispatchTouchEndAsync(cancellationToken).ConfigureAwait(false);
            _session.MousePosition = new Point(locationX, locationY);
        }

        private Task DispatchTouchEndAsync(CancellationToken cancellationToken)
        {
            return DispatchTouchAsync(ChromeDriverMouse.TouchEnd, cancellationToken);
        }

        private async Task DispatchTouchAsync(string type, CancellationToken cancellationToken)
        {
            var cmd = new DispatchTouchEventCommand
            {
                Type = type,
                TouchPoints = Array.Empty<TouchPoint>()
            };
            if (_session.StickyModifiers != 0)
                cmd.Modifiers = _session.StickyModifiers;

            await _webView.DevTools.Input.DispatchTouchEvent(cmd, cancellationToken).ConfigureAwait(false);
        }

        private async Task DispatchTouchAsync(string type, WebPoint point, CancellationToken cancellationToken)
        {
            var cmd = new DispatchTouchEventCommand
            {
                Type = type,
                TouchPoints = new[]
                {
                    new TouchPoint { X = point.X, Y = point.Y }
                }
            };
            if (_session.StickyModifiers != 0)
                cmd.Modifiers = _session.StickyModifiers;

            await _webView.DevTools.Input.DispatchTouchEvent(cmd, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Port of <c>ExecuteFlick</c> (<c>chrome/test/chromedriver/element_commands.cc</c>): touch start, move steps at
        /// <see cref="FlickTouchEventsPerSecond"/>, touch end at <paramref name="start"/> + (<paramref name="offsetX"/>, <paramref name="offsetY"/>).
        /// </summary>
        private async Task FlickFromPointAsync(WebPoint start, int offsetX, int offsetY, int speed,
            CancellationToken cancellationToken)
        {
            await DispatchTouchAsync(ChromeDriverMouse.TouchStart, start, cancellationToken).ConfigureAwait(false);
            _session.MousePosition = new Point(start.X, start.Y);

            var offsetLen = Math.Sqrt(offsetX * (long)offsetX + offsetY * (long)offsetY);
            if (offsetLen > 0)
            {
                var xPer = (speed * offsetX) / (FlickTouchEventsPerSecond * offsetLen);
                var yPer = (speed * offsetY) / (FlickTouchEventsPerSecond * offsetLen);
                var totalEvents = (int)((offsetLen * FlickTouchEventsPerSecond) / speed);
                var delayMs = 1000 / FlickTouchEventsPerSecond;

                for (var i = 0; i < totalEvents; i++)
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    var p = new WebPoint(
                        (int)Math.Round(start.X + xPer * i),
                        (int)Math.Round(start.Y + yPer * i));
                    await DispatchTouchAsync(ChromeDriverMouse.TouchMove, p, cancellationToken).ConfigureAwait(false);
                    _session.MousePosition = new Point(p.X, p.Y);
                    await Task.Delay(delayMs, cancellationToken).ConfigureAwait(false);
                }
            }

            var end = new WebPoint(start.X + offsetX, start.Y + offsetY);
            await DispatchTouchEndAsync(cancellationToken).ConfigureAwait(false);
            _session.MousePosition = new Point(end.X, end.Y);
        }
    }
}
