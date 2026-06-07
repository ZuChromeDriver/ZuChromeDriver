namespace Zu.ChromeDevTools.Page
{
    using System.Threading.Tasks;

    /// <summary>
    /// Represents an adapter for the Page domain to simplify the command interface.
    /// </summary>
    public partial class PageAdapter
    {
        public Task<CaptureScreenshotCommandResponse> CaptureScreenshot()
            => CaptureScreenshot(new CaptureScreenshotCommand());

        public Task Enable() => Enable(new EnableCommand());
    }
}