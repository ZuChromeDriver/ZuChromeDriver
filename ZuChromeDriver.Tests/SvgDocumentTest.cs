using System.Threading.Tasks;
using NUnit.Framework;
using Zu.WebDriver;
using Zu.WebDriver.AsyncInteractions;

namespace Zu.ZuChromeDriver.Tests
{
    [TestFixture]
    public class SvgDocumentTest : DriverTestFixture
    {
        [Test]
        public async Task ClickOnSvgElement()
        {
            await driver.GoToUrl(svgTestPage);
            IWebElement rect = await driver.FindElement(By.Id("rect"));

            Assert.AreEqual("blue", await rect.GetAttribute("fill"));
            await rect.Click();
            Assert.AreEqual("green", await rect.GetAttribute("fill"));
        }

        [Test]
        public async Task ExecuteScriptInSvgDocument()
        {

            await driver.GoToUrl(svgTestPage);
            IWebElement rect = await driver.FindElement(By.Id("rect"));

            Assert.AreEqual("blue", await rect.GetAttribute("fill"));
            await ((IJavaScriptExecutor)driver).ExecuteScript("document.getElementById('rect').setAttribute('fill', 'yellow');");
            Assert.AreEqual("yellow", await rect.GetAttribute("fill"));
        }
    }
}
