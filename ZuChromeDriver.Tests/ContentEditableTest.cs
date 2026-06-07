using NUnit.Framework;
using Zu.ZuChromeDriver.Tests.Environment;
using System.Threading.Tasks;
using Zu.WebDriver;
using Zu.WebDriver.BasicTypes;

namespace Zu.ZuChromeDriver.Tests
{
    [TestFixture]
    public class ContentEditableTest : DriverTestFixture
    {
        protected override bool RequiresFrameTracker => true;

        [TearDown]
        public async Task SwitchToDefaultContent()
        {
            await driver.SwitchTo().DefaultContent();
        }

        [Test]
        public async Task TypingIntoAnIFrameWithContentEditableOrDesignModeSet()
        {
           await driver.GoToUrl(richTextPage);

            await driver.SwitchTo().Frame("editFrame");
            IWebElement element = await driver.SwitchTo().ActiveElement();
            await element.SendKeys("Fishy");

            await driver.SwitchTo().DefaultContent();
            IWebElement trusted = await driver.FindElement(By.Id("istrusted"));
            IWebElement id = await driver.FindElement(By.Id("tagId"));

            // Chrome does not set a trusted flag.
            Assert.That(await trusted.Text(), Is.AnyOf("[true]", "[n/a]", "[]"));
            Assert.That(await id.Text(), Is.AnyOf("[frameHtml]", "[theBody]"));
        }

        [Test]
        public async Task NonPrintableCharactersShouldWorkWithContentEditableOrDesignModeSet()
        {
           await driver.GoToUrl(richTextPage);

            await driver.SwitchTo().Frame("editFrame");
            IWebElement element = await driver.SwitchTo().ActiveElement();
            await element.SendKeys("Dishy" + Keys.Backspace + Keys.Left + Keys.Left);
            await element.SendKeys(Keys.Left + Keys.Left + "F" + Keys.Delete + Keys.End + "ee!");

            Assert.AreEqual("Fishee!", await element.Text());
        }

        [Test]
        public async Task ShouldBeAbleToTypeIntoEmptyContentEditableElement()
        {
           await driver.GoToUrl(readOnlyPage);
            IWebElement editable = await driver.FindElement(By.Id("content-editable-blank"));

            await editable.SendKeys("cheese");

            Assert.That(await editable.Text(), Is.EqualTo("cheese"));
        }

        [Test]
        public async Task ShouldBeAbleToTypeIntoContentEditableElementWithExistingValue()
        {
            await driver.GoToUrl(readOnlyPage);
            IWebElement editable = await driver.FindElement(By.Id("content-editable"));

            string initialText = await editable.Text();
            await editable.SendKeys(", edited");

            Assert.That(await editable.Text(), Is.EqualTo(initialText + ", edited"));
        }

        [Test]
        public async Task ShouldBeAbleToTypeIntoTinyMCE()
        {
           await driver.GoToUrl(EnvironmentManager.Instance.UrlBuilder.WhereIs("tinymce.html"));
            await driver.SwitchTo().Frame("mce_0_ifr");

            IWebElement editable = await driver.FindElement(By.Id("tinymce"));

            await editable.Clear();
            await editable.SendKeys("cheese"); // requires focus on OS X

            Assert.That(await editable.Text(), Is.EqualTo("cheese"));
        }

        [Test]
        public async Task ShouldAppendToTinyMCE()
        {
           await driver.GoToUrl(EnvironmentManager.Instance.UrlBuilder.WhereIs("tinymce.html"));
            await driver.SwitchTo().Frame("mce_0_ifr");

            IWebElement editable = await driver.FindElement(By.Id("tinymce"));

            await editable.SendKeys(" and cheese"); // requires focus on OS X
            await WaitFor(async () => await editable.Text() != "Initial content", "Text remained the original text");

            Assert.That(await editable.Text(), Is.EqualTo("Initial content and cheese"));
        }

        [Test]
        public async Task AppendsTextToEndOfContentEditableWithMultipleTextNodes()
        {
            await driver.GoToUrl(EnvironmentManager.Instance.UrlBuilder.WhereIs("content-editable.html"));
            IWebElement input = await driver.FindElement(By.Id("editable"));

            await input.SendKeys(", world!");
            await WaitFor(async () => await input.Text() != "Why hello", "Text remained the original text");

            Assert.That(await input.Text(), Is.EqualTo("Why hello, world!"));
        }

    }
}
