// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.ObjectModel;
using Zu.Chrome;
using Zu.ChromeDevTools;
using Zu.ChromeDevTools.Network;
using Zu.WebDriver.BasicTypes;
using Zu.WebDriver.BrowserOptions;
using Cookie = Zu.WebDriver.BasicTypes.Cookie;

namespace Zu.ChromeWebDriver
{
    public class ChromeDriverCookieJar : ICookieJar
    {
        private readonly IChromeDriver _ZuChromeDriver;
        private int _networkEnabled;

        public ChromeDriverCookieJar(IChromeDriver ZuChromeDriver)
        {
            _ZuChromeDriver = ZuChromeDriver ?? throw new ArgumentNullException(nameof(ZuChromeDriver));
        }

        private async Task EnsureNetworkEnabledAsync(CancellationToken cancellationToken)
        {
            if (Volatile.Read(ref _networkEnabled) != 0)
            {
                return;
            }

            await _ZuChromeDriver.DevTools.Network.Enable(new EnableCommand(), cancellationToken).ConfigureAwait(false);
            Interlocked.Exchange(ref _networkEnabled, 1);
        }

        private async Task<string> ResolveCookieUrlAsync(CancellationToken cancellationToken)
        {
            var frameId = _ZuChromeDriver.Session?.GetCurrentFrameId();
            var frameArg = string.IsNullOrEmpty(frameId) ? null : frameId;

            string jsUrl = null;
            try
            {
                jsUrl = await _ZuChromeDriver.WindowCommands.GetCurrentUrl(frameArg).ConfigureAwait(false);
                if (IsAbsoluteHttpUrl(jsUrl))
                {
                    return jsUrl;
                }
            }
            catch (WebBrowserException)
            {
            }

            try
            {
                var u = await _ZuChromeDriver.WebView.GetUrl(cancellationToken).ConfigureAwait(false);
                if (IsAbsoluteHttpUrl(u))
                {
                    return u;
                }
            }
            catch (CommandResponseException)
            {
                // e.g. Page.getNavigationHistory: Not attached to an active page
            }

            var last = _ZuChromeDriver.LastNavigatedUrl;
            if (IsAbsoluteHttpUrl(last))
            {
                return last;
            }

            return !string.IsNullOrEmpty(jsUrl) ? jsUrl : last ?? string.Empty;
        }

        private static bool IsAbsoluteHttpUrl(string u)
        {
            return !string.IsNullOrEmpty(u)
                   && (u.StartsWith("http://", StringComparison.OrdinalIgnoreCase)
                       || u.StartsWith("https://", StringComparison.OrdinalIgnoreCase));
        }

        public async Task AddCookie(Cookie cookie, CancellationToken cancellationToken = default)
        {
            if (cookie == null)
            {
                throw new ArgumentNullException(nameof(cookie));
            }

            await EnsureNetworkEnabledAsync(cancellationToken).ConfigureAwait(false);
            var currentUrl = await ResolveCookieUrlAsync(cancellationToken).ConfigureAwait(false);
            var cmd = new SetCookieCommand
            {
                Name = cookie.Name,
                Value = cookie.Value,
                Url = currentUrl,
            };
            if (!string.IsNullOrEmpty(cookie.Domain))
            {
                cmd.Domain = cookie.Domain;
            }

            if (!string.IsNullOrEmpty(cookie.Path))
            {
                cmd.Path = cookie.Path;
            }

            if (cookie is ReturnedCookie rc)
            {
                cmd.Secure = rc.Secure;
                cmd.HttpOnly = rc.IsHttpOnly;
            }
            else
            {
                if (cookie.Secure)
                {
                    cmd.Secure = true;
                }

                if (cookie.IsHttpOnly)
                {
                    cmd.HttpOnly = true;
                }
            }

            if (!string.IsNullOrEmpty(cookie.SameSite))
            {
                cmd.SameSite = ParseSameSite(cookie.SameSite);
            }

            if (cookie.Expiry != null)
            {
                var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                cmd.Expires = (cookie.Expiry.Value.ToUniversalTime() - epoch).TotalSeconds;
            }

            try
            {
                var response = await _ZuChromeDriver.DevTools.Network.SetCookie(cmd, cancellationToken).ConfigureAwait(false);
                if (response is { Success: false })
                {
                    throw new WebBrowserException("Network.setCookie returned success: false", "UnableToSetCookieException");
                }
            }
            catch (CommandResponseException ex)
            {
                throw MapCookieFailure(ex);
            }
        }

        public async Task<ReadOnlyCollection<Cookie>> AllCookies(CancellationToken cancellationToken = default)
        {
            await EnsureNetworkEnabledAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                var cmd = new GetCookiesCommand();
                var cookieUrl = await ResolveCookieUrlAsync(cancellationToken).ConfigureAwait(false);
                if (IsAbsoluteHttpUrl(cookieUrl))
                {
                    cmd.Urls = new[] { cookieUrl };
                }

                var response = await _ZuChromeDriver.DevTools.Network.GetCookies(cmd, cancellationToken).ConfigureAwait(false);
                if (response?.Cookies == null || response.Cookies.Length == 0)
                {
                    return new ReadOnlyCollection<Cookie>(Array.Empty<Cookie>());
                }

                var list = response.Cookies.Select(FromCdpCookie).ToList();
                return new ReadOnlyCollection<Cookie>(list);
            }
            catch (CommandResponseException ex)
            {
                throw new WebBrowserException(ex.Message);
            }
        }

        public async Task DeleteAllCookies(CancellationToken cancellationToken = default)
        {
            await EnsureNetworkEnabledAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                await _ZuChromeDriver.DevTools.Network.ClearBrowserCookies(new ClearBrowserCookiesCommand(), cancellationToken).ConfigureAwait(false);
            }
            catch (CommandResponseException ex)
            {
                throw new WebBrowserException(ex.Message);
            }
        }

        public async Task DeleteCookie(Cookie cookie, CancellationToken cancellationToken = default)
        {
            if (cookie == null)
            {
                throw new ArgumentNullException(nameof(cookie));
            }

            await EnsureNetworkEnabledAsync(cancellationToken).ConfigureAwait(false);
            var currentUrl = await ResolveCookieUrlAsync(cancellationToken).ConfigureAwait(false);
            var cmd = new DeleteCookiesCommand
            {
                Name = cookie.Name,
            };
            if (!string.IsNullOrEmpty(cookie.Domain))
            {
                cmd.Domain = cookie.Domain;
            }

            if (!string.IsNullOrEmpty(cookie.Path))
            {
                cmd.Path = cookie.Path;
            }

            if (string.IsNullOrEmpty(cookie.Domain) || string.IsNullOrEmpty(cookie.Path))
            {
                cmd.Url = currentUrl;
            }

            try
            {
                await _ZuChromeDriver.DevTools.Network.DeleteCookies(cmd, cancellationToken).ConfigureAwait(false);
            }
            catch (CommandResponseException ex)
            {
                throw new WebBrowserException(ex.Message);
            }
        }

        public async Task DeleteCookieNamed(string name, CancellationToken cancellationToken = default)
        {
            ValidateCookieNameArgument(name, nameof(name));
            await EnsureNetworkEnabledAsync(cancellationToken).ConfigureAwait(false);
            var currentUrl = await ResolveCookieUrlAsync(cancellationToken).ConfigureAwait(false);
            try
            {
                await _ZuChromeDriver.DevTools.Network.DeleteCookies(
                    new DeleteCookiesCommand { Name = name, Url = currentUrl },
                    cancellationToken).ConfigureAwait(false);
            }
            catch (CommandResponseException ex)
            {
                throw new WebBrowserException(ex.Message);
            }
        }

        public async Task<Cookie> GetCookieNamed(string name, CancellationToken cancellationToken = default)
        {
            ValidateCookieNameArgument(name, nameof(name));
            var all = await AllCookies(cancellationToken).ConfigureAwait(false);
            return all.FirstOrDefault(c => c.Name == name);
        }

        private static void ValidateCookieNameArgument(string name, string paramName)
        {
            if (name == null || string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Cookie name cannot be null or empty", paramName);
            }
        }

        private static Cookie FromCdpCookie(ChromeDevTools.Network.Cookie c)
        {
            DateTime? expiry = null;
            if (!c.Session && c.Expires > 0)
            {
                try
                {
                    expiry = DateTimeOffset.FromUnixTimeSeconds((long)c.Expires).LocalDateTime;
                }
                catch (ArgumentOutOfRangeException)
                {
                    expiry = DateTime.MaxValue.ToLocalTime();
                }
            }

            string sameSiteStr = null;
            if (c.SameSite.HasValue)
            {
                sameSiteStr = c.SameSite.Value switch
                {
                    Zu.ChromeDevTools.Network.CookieSameSite.Strict => "Strict",
                    Zu.ChromeDevTools.Network.CookieSameSite.Lax => "Lax",
                    Zu.ChromeDevTools.Network.CookieSameSite.None => "None",
                    _ => null,
                };
            }

            if (sameSiteStr != null)
            {
                return new ReturnedCookie(c.Name, c.Value, c.Domain, c.Path, expiry, c.Secure, c.HttpOnly, sameSiteStr);
            }

            return new ReturnedCookie(c.Name, c.Value, c.Domain, c.Path, expiry, c.Secure, c.HttpOnly);
        }

        private static CookieSameSite? ParseSameSite(string sameSite)
        {
            if (string.IsNullOrEmpty(sameSite))
            {
                return null;
            }

            return sameSite switch
            {
                "Strict" => CookieSameSite.Strict,
                "Lax" => CookieSameSite.Lax,
                "None" => CookieSameSite.None,
                _ => throw new ArgumentException("Invalid SameSite: " + sameSite, nameof(sameSite)),
            };
        }

        private static WebBrowserException MapCookieFailure(CommandResponseException ex)
        {
            var msg = ex.Message ?? string.Empty;
            if (msg.IndexOf("invalid cookie domain", StringComparison.OrdinalIgnoreCase) >= 0 ||
                msg.IndexOf("Invalid cookie domain", StringComparison.OrdinalIgnoreCase) >= 0 ||
                (msg.IndexOf("invalid URL", StringComparison.OrdinalIgnoreCase) >= 0 &&
                 msg.IndexOf("cookie", StringComparison.OrdinalIgnoreCase) >= 0))
            {
                return new WebBrowserException(msg, "InvalidCookieDomainException");
            }

            if (msg.IndexOf("cookie", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return new WebBrowserException(msg, "UnableToSetCookieException");
            }

            return new WebBrowserException(msg, "UnableToSetCookieException");
        }
    }
}
