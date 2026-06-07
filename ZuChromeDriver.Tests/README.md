# ZuChromeDriver.Tests

E2E-тесты WebDriver API против встроенного Chrome (ZuChromeDriver).

## Запуск

```powershell
dotnet test ZuChromeDriver.Tests\ZuChromeDriver.Tests.csproj --filter "FullyQualifiedName~AlertsTest"
```

`AlertsTest` помечен `[Explicit("NotImplemented")]` — для прогона уберите атрибут или запускайте явно из IDE.

## FrameTracker

**По умолчанию выключен** и в драйвере (`ChromeDriverConfig.EnableFrameTrackerOnConnect = false`), и в тестовой конфигурации (`EnvironmentManager.CreateTestChromeConfig()`).

FrameTracker нужен, когда требуется:

- `SwitchTo().Frame(...)` — execution context для iframe/frame;
- `SwitchTo().Alert()` — отслеживание JS-диалогов через CDP `Page.javascriptDialogOpening`;
- `UnhandledAlertException` на командах вроде `GetTitle()` при открытом alert.

### Как включить в тестах

**На всю фикстуру** — переопределить в классе, наследующем `DriverTestFixture`:

```csharp
public class AlertsTest : DriverTestFixture
{
    protected override bool RequiresFrameTracker => true;
}
```

**На один тест** — атрибут `[NeedsFrameTracker]` (создаёт свежий драйвер с FrameTracker перед тестом):

```csharp
[Test]
[NeedsFrameTracker]
public async Task GetCookiesInAFrame() { ... }
```

**Программно:**

```csharp
EnvironmentManager.Instance.CreateFreshDriver(enableFrameTracker: true);
// или
CreateFreshDriver(enableFrameTracker: true);
```

`[NeedsFreshDriver]` учитывает `UsesFrameTracker` фикстуры при пересоздании драйвера.

### Фикстуры с `RequiresFrameTracker => true`

`AlertsTest`, `FrameSwitchingTest`, `TargetLocatorTest`, `ClickTest`, `ClickScrollingTest`, `ExecutingAsyncJavascriptTest`, `WindowTest`, `WindowSwitchingTest`, `PositionAndSizeTest`, `ContentEditableTest`, `ElementFindingTest`, `UploadTest`, `ElementEqualityTest`, `UnexpectedAlertBehaviorTest`.

Отдельные тесты с `[NeedsFrameTracker]`: `FormHandlingTests.HandleFormWithJavascriptAction`, `ExecutingJavascriptTest.ShouldBeAbleToGrabTheBodyOfFrameOnceSwitchedTo`, два теста в `TypingTest`, `CookieImplementationTest.GetCookiesInAFrame`, `ElementAttributeTest.ShouldReturnValueOfClassAttributeOfAnElementAfterSwitchingIFrame`.

## JavaScript alert и Click

Клик по элементу с `onclick="alert(...)"` **нельзя** выполнять только через CLICK atom: `alert()` блокирует Evaluate до закрытия диалога → timeout ~30 s.

Реализация в `ElementCommands` (как в upstream ChromeDriver):

1. CDP `Input.dispatchMouseEvent` (move / press / release) с полем `buttons` (0 / 0 / 1);
2. move и press — fire-and-forget (`throwExceptionIfResponseNotReceived: false` в `ChromeSession`);
3. при необходимости — fallback на CLICK atom с `Runtime.TerminateExecution` при открытии диалога.

**Для alert-тестов обязателен включённый FrameTracker** — иначе `SwitchTo().Alert()` вернёт `NoAlertPresentException`.

## AlertsTest — статус (2026-06)

Прогон `FullyQualifiedName~AlertsTest`: **20 пройдено**, **6 не пройдено**, **1 пропущен** (`ShouldNotHandleAlertInAnotherWindow`, `[Ignore]`).

| Статус | Тесты |
|--------|--------|
| OK | `AlertShouldNotAllowAdditionalCommandsIfDismissed`, `ShouldAllowUsersToAcceptAnAlertManually`, `ShouldAllowUsersToDismissAnAlertManually`, prompt/alert text, `ShouldHandleAlertOnFormSubmit`, `ShouldHandleAlertOnPageBeforeUnload`, `ShouldHandleAlertOnPageLoad`, и др. |
| Fail | `ShouldAllowUsersToAcceptAnAlertInAFrame`, `ShouldAllowUsersToAcceptAnAlertInANestedFrame` (click в iframe), `ShouldHandleAlertOnPageLoadUsingGet` (alert на onload), `PromptShouldUseDefaultValueIfNoKeysSent`, `SwitchingToMissingAlertInAClosedWindowThrows` (popup), `HandlesTwoAlertsFromOneInteraction` (flaky в полном прогоне) |

Известные открытые темы: координаты клика в iframe, alert при `GoToUrl` с `onload`, prompt default без `SendKeys`, multi-window.
