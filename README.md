# ZuChromeDriver

Async .NET Chrome WebDriver and Chrome DevTools in one library. Connects directly to **Chrome DevTools Protocol (CDP)** over WebSocket — no separate `chromedriver` binary required.

ZuChromeDriver provides a **Selenium-like WebDriver API** (`ZuWebDriver`, `By`, `WebElement`) with an **async-first** contract (`Task<T>`). It also exposes full CDP access through the `DevTools` property.

Successor to **AsyncChromeDriver** with the same core idea: in-process CDP, chromedriver atom parity, and logic aligned with the reference Chromium Chromedriver implementation.

## Solution layout

```
ZuChromeDriver.slnx
├── ZuChromeDriver/              # Main library (net10.0)
├── ChromeDevToolsClient/        # CDP transport (NuGet: Zu.ChromeDevToolsClient)
├── ChromeDevToolsClientGenerator/
├── HtmlForTests/                # Kestrel host for test pages
└── ZuChromeDriver.Tests/        # NUnit E2E against Chrome + HtmlForTests
```

## Requirements

- .NET 10 SDK
- Google Chrome installed

## Build

```powershell
dotnet build ZuChromeDriver.slnx
```

## Quick start

```csharp
using Zu.Chrome;
using Zu.WebDriver;

var chrome = new ZuChromeDriver();
var driver = new ZuWebDriver(chrome);
await driver.GoToUrl("https://www.google.com/");
```

## Headless Chrome

```csharp
using Zu.Chrome;
using Zu.WebDriver;
using Zu.WebDriver.BasicTypes;

var config = new ChromeDriverConfig()
    .SetHeadless()
    .SetWindowSize(1280, 720);

var chrome = new ZuChromeDriver(config);
await chrome.Connect();
var driver = new ZuWebDriver(chrome);
await driver.GoToUrl("https://www.google.com/");
var screenshot = await driver.GetScreenshot();
var path = Path.Combine(Environment.CurrentDirectory, "google-headless.png");
await File.WriteAllBytesAsync(path, screenshot.AsByteArray);
```

## Using DevTools directly

```csharp
using Zu.Chrome;
using Zu.ChromeDevTools.Page;

var chrome = new ZuChromeDriver();
await chrome.Connect();
await chrome.DevTools.Page.Enable();
await chrome.DevTools.Page.Navigate(new NavigateCommand
{
    Url = "https://www.google.com/"
});
```

Domain adapters (`Page`, `Runtime`, `DOM`, `Network`, `Input`, …) are generated from the CDP schema in **ChromeDevToolsClient**.

## FrameTracker

`EnableFrameTrackerOnConnect` defaults to **false**. Enable it when you need:

- `SwitchTo().Frame(...)` — execution context for iframes
- `SwitchTo().Alert()` — JavaScript dialog tracking via CDP

```csharp
var config = new ChromeDriverConfig().SetEnableFrameTrackerOnConnect();
```

See [ZuChromeDriver.Tests/README.md](ZuChromeDriver.Tests/README.md) for test fixture patterns (`RequiresFrameTracker`, `[NeedsFrameTracker]`).

## Running tests

Tests start **HtmlForTests** automatically on port **2310** and run E2E against a real Chrome instance.

```powershell
dotnet test ZuChromeDriver.Tests\ZuChromeDriver.Tests.csproj
```

Filter a single fixture:

```powershell
dotnet test ZuChromeDriver.Tests\ZuChromeDriver.Tests.csproj --filter "FullyQualifiedName~CookieImplementationTest"
```

## Implementation status

| Area | Status |
|------|--------|
| Navigation, elements, mouse, keyboard, clicks | Implemented |
| Screenshots, cookies, window switching | Implemented |
| Frame switching, alerts (with FrameTracker) | Implemented |
| `execute_script` / `execute_async_script` | Implemented |
| W3C Actions, touch screen | Implemented |
| Browser logs via CDP | Implemented |
| Selenium Grid / remote wire protocol | Not supported (direct CDP only) |
| Shadow DOM, RelativeBy, BiDi | Not implemented |

Tests are ported from the Selenium .NET WebDriver test suite and run against **HtmlForTests**.

## Documentation

| Document | Description |
|----------|-------------|
| [docs/README.md](docs/README.md) | Architecture overview and index |
| [docs/ARCHITECTURE-ZuChromeDriver-ChromeDevToolsClient.md](docs/ARCHITECTURE-ZuChromeDriver-ChromeDevToolsClient.md) | CDP stack and connection lifecycle |
| [docs/ARCHITECTURE-DriverCore.md](docs/ARCHITECTURE-DriverCore.md) | Session, frames, DOM, atoms, WebView |
| [docs/ARCHITECTURE-WebDriver-Layer.md](docs/ARCHITECTURE-WebDriver-Layer.md) | ZuWebDriver and ChromeWebDriver facades |
| [docs/ARCHITECTURE-HtmlForTests-ZuChromeDriver.Tests.md](docs/ARCHITECTURE-HtmlForTests-ZuChromeDriver.Tests.md) | Test server and E2E harness |
| [docs/COMPARISON-WebDriver-Selenium-DotNet.md](docs/COMPARISON-WebDriver-Selenium-DotNet.md) | Comparison with Selenium .NET |

## Key types

| Type | Role |
|------|------|
| `ZuChromeDriver` | Chrome engine; implements `IAsyncWebBrowserClient` and `IChromeDriver` |
| `ZuWebDriver` | Selenium-like entry point; implements `IWebDriver` |
| `WebElement` | Async DOM element (`Task<T>` methods, not sync properties) |
| `Session` (`DriverCore`) | WebDriver state: frame stack, timeouts, element keys |
| `ChromeSession` (`ChromeDevTools`) | CDP WebSocket session |

## License

Copyright (c) Oleg Zudov. Licensed under the Apache License, Version 2.0. See [License.txt](License.txt).

Portions are based on Selenium (Apache 2.0) and Chromium Chromedriver (BSD). See [THIRD-PARTY-NOTICES.txt](THIRD-PARTY-NOTICES.txt).
