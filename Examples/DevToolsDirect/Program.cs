using Zu.Chrome;
using Zu.ChromeDevTools.Page;

var chrome = new ZuChromeDriver();
await chrome.Connect();

try
{
    await chrome.DevTools.Page.Enable();
    await chrome.DevTools.Page.Navigate(new NavigateCommand
    {
        Url = "https://www.google.com/"
    });
    Console.WriteLine("Navigated to https://www.google.com/");
    var screenshot = await chrome.DevTools.Page.CaptureScreenshot();
    var path = Path.Combine(Environment.CurrentDirectory, "page.png");
    await File.WriteAllBytesAsync(path, Convert.FromBase64String(screenshot.Data));
    Console.WriteLine($"Screenshot before navigate: {path}");

}
finally
{
    await Task.Delay(2000);
    await chrome.Close();
}
