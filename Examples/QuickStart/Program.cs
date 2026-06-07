using Zu.Chrome;
using Zu.WebDriver;

var chrome = new ZuChromeDriver();
try
{
    var driver = new ZuWebDriver(chrome);
    await driver.GoToUrl("https://www.google.com/");
}
finally
{
    await Task.Delay(5000);
    await chrome.Close();
}
