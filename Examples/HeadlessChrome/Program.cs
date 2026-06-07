using Zu.Chrome;
using Zu.WebDriver;
using Zu.WebDriver.BasicTypes;

var config = new ChromeDriverConfig()
    .SetHeadless()
    .SetWindowSize(1280, 720);

var chrome = new ZuChromeDriver(config);
await chrome.Connect();

try
{
    var driver = new ZuWebDriver(chrome);
    await driver.GoToUrl("https://www.google.com/");

    var screenshot = await driver.GetScreenshot();
    var path = Path.Combine(Environment.CurrentDirectory, "google-headless.png");
    await File.WriteAllBytesAsync(path, screenshot.AsByteArray);
    Console.WriteLine($"Screenshot saved: {path} ({screenshot.AsByteArray.Length} bytes)");
}
finally
{
    await chrome.Close();
}
