using NUnit.Framework;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Zu.WebDriver;
using Zu.Chrome;
using Zu.WebDriver.BasicTypes;
using Zu.ZuChromeDriver.Tests.Environment;

namespace Zu.ZuChromeDriver.Tests
{
    [TestFixture]
    public class AvailableLogsTest : DriverTestFixture
    {
        private IWebDriver _localDriver;

        [TearDown]
        public void QuitDriver()
        {
            if (_localDriver != null) {
                _localDriver.CloseSync();
                _localDriver = null;
            }
        }

        [Test]
        public async Task BrowserLogShouldBeEnabledByDefault()
        {
            ReadOnlyCollection<string> logTypes = await driver.Options().Logs.AvailableLogTypes();
            Assert.That(logTypes, Contains.Item(LogType.Browser));
        }

        [Test]
        [Ignore("Client log doesn't exist yet in .NET bindings")]
        [NeedsFreshDriver(IsCreatedBeforeTest = true)]
        public async Task ClientLogShouldBeEnabledByDefault()
        {

            // Do one action to have *something* in the client logs.
            await driver.GoToUrl(formsPage);
            ReadOnlyCollection<string> logTypes = await driver.Options().Logs.AvailableLogTypes();
            Assert.That(logTypes, Contains.Item(LogType.Client));
            bool foundExecutingStatement = false;
            bool foundExecutedStatement = false;
            foreach (LogEntry logEntry in await driver.Options().Logs.GetLog(LogType.Client)) {
                foundExecutingStatement |= logEntry.ToString().Contains("Executing: ");
                foundExecutedStatement |= logEntry.ToString().Contains("Executed: ");
            }

            Assert.That(foundExecutingStatement, Is.True);
            Assert.That(foundExecutedStatement, Is.True);
        }

        [Test]
        public async Task DriverLogShouldBeEnabledByDefault()
        {
            ReadOnlyCollection<string> logTypes = await driver.Options().Logs.AvailableLogTypes();
            Assert.That(logTypes, Contains.Item(LogType.Driver), "Remote driver logs should be enabled by default");
        }

        [Test]
        public async Task ProfilerLogShouldBeDisabledByDefault()
        {
            ReadOnlyCollection<string> logTypes = await driver.Options().Logs.AvailableLogTypes();
            Assert.That(logTypes, Has.No.Member(LogType.Profiler), "Profiler logs should not be enabled by default");
        }

        [Test]
        [Ignore("No way to determine remote only")]
        public async Task ServerLogShouldBeEnabledByDefaultOnRemote()
        {
            //assumeTrue(Boolean.getBoolean("selenium.browser.remote"));

            ReadOnlyCollection<string> logTypes = await _localDriver.Options().Logs.AvailableLogTypes();
            Assert.That(logTypes, Contains.Item(LogType.Server), "Server logs should be enabled by default");
        }

        private void CreateWebDriverWithProfiling()
        {

            ChromeDriverConfig options = EnvironmentManager.CreateTestChromeConfig();
            //options.AddAdditionalCapability(CapabilityType.EnableProfiling, true, true);
            _localDriver = new ZuWebDriver(new Chrome.ZuChromeDriver(options));
            //ICapabilities c = ((IHasCapabilities)localDriver).Capabilities;
        }
    }
}
