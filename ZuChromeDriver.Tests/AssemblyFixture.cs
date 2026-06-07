using NUnit.Framework;
using Zu.ZuChromeDriver.Tests.Environment;

namespace Zu.ZuChromeDriver.Tests
{
    [SetUpFixture]
    public class AssemblyFixture
    {
        [OneTimeTearDown]
        public void RunAfterAllTests()
        {
            EnvironmentManager.Shutdown();
        }
    }
}
