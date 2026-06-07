using System.Threading.Tasks;
using NUnit.Framework;
using Zu.ZuChromeDriver.Tests.Environment;
using Zu.WebDriver;
using Zu.WebDriver.BasicTypes;
using Cookie = Zu.WebDriver.BasicTypes.Cookie;

namespace Zu.ZuChromeDriver.Tests
{
    [TestFixture]
    public class TextPagesTest: DriverTestFixture
    {
        private string textPage = EnvironmentManager.Instance.UrlBuilder.WhereIs("plain.txt");

        [Test]
        public async Task ShouldBeAbleToLoadASimplePageOfText()
        {
           await driver.GoToUrl(textPage);
            string source =  await driver.PageSource();
            Assert.That(source, Does.Contain("Test"));
        }

        [Test]
        [Ignore("Chrome/CDP allows SetCookie on non-HTML documents; Selenium IgnoreBrowser(Chrome) and other browsers")]
        public async Task ShouldThrowExceptionWhenAddingCookieToAPageThatIsNotHtml()
        {
            await driver.GoToUrl(textPage);
            var cookie = new Cookie("hello", "goodbye");
            await AssertEx.ThrowsAsync<WebDriverException>(async () => await driver.Options().Cookies.AddCookie(cookie));
        }

        //------------------------------------------------------------------
        // Tests below here are not included in the Java test suite
        //------------------------------------------------------------------
        [Test]
        public async Task FindingAnElementOnAPlainTextPageWillNeverWork()
        {
           await driver.GoToUrl(textPage);
            //Assert.That(async () => await driver.FindElement(By.Id("foo")), Throws.InstanceOf<NoSuchElementException>());
            await AssertEx.ThrowsAsync<WebBrowserException>(async () => await driver.FindElement(By.Id("foo")),
                exception => Assert.AreEqual("no such element", exception.Error));
        }
    }
}
