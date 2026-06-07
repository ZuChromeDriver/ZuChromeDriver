using System.Threading.Tasks;
using NUnit.Framework;
using Zu.WebDriver;

namespace Zu.ZuChromeDriver.Tests
{
    [TestFixture]
    public class ElementPropertyTest : DriverTestFixture
    {
        [Test]
        public async Task ShouldReturnNullWhenGettingTheValueOfAPropertyThatIsNotListed()
        {
            await driver.GoToUrl(simpleTestPage);
            IWebElement head = await driver.FindElement(By.XPath("/html"));
            string property = await head.GetProperty("cheese");
            Assert.That(property, Is.Null);
        }

        [Test]
        public async Task CanRetrieveTheCurrentValueOfAProperty()
        {
            await driver.GoToUrl(formsPage);
            IWebElement element = await driver.FindElement(By.Id("working"));

            Assert.That(string.IsNullOrEmpty(await element.GetProperty("value")));
            await element.SendKeys("hello world");
            Assert.That(await element.GetProperty("value"), Is.EqualTo("hello world"));
        }
    }
}
