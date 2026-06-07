using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Zu.ZuChromeDriver.Tests.Environment;

namespace Zu.ZuChromeDriver.Tests
{
    public class NeedsFreshDriverAttribute : TestActionAttribute
    {
        public bool IsCreatedBeforeTest { get; set; } = false;

        public bool IsCreatedAfterTest { get; set; } = false;

        public override void BeforeTest(ITest test)
        {
            if (test.Fixture is DriverTestFixture fixtureInstance && IsCreatedBeforeTest)
            {
                EnvironmentManager.Instance.CreateFreshDriver(fixtureInstance.UsesFrameTracker);
                fixtureInstance.DriverInstance = EnvironmentManager.Instance.GetCurrentDriver();
            }
            base.BeforeTest(test);
        }

        public override void AfterTest(ITest test)
        {
            if (test.Fixture is DriverTestFixture fixtureInstance && IsCreatedAfterTest)
            {
                EnvironmentManager.Instance.CreateFreshDriver(fixtureInstance.UsesFrameTracker);
                fixtureInstance.DriverInstance = EnvironmentManager.Instance.GetCurrentDriver();
            }
        }
    }
}
