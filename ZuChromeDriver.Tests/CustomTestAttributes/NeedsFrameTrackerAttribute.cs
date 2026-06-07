using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Zu.ZuChromeDriver.Tests.Environment;

namespace Zu.ZuChromeDriver.Tests
{
    /// <summary>
    /// Creates a fresh driver with <see cref="Zu.Chrome.ChromeDriverConfig.EnableFrameTrackerOnConnect"/> for this test.
    /// </summary>
    public class NeedsFrameTrackerAttribute : TestActionAttribute
    {
        public bool IsCreatedBeforeTest { get; set; } = true;

        public bool IsCreatedAfterTest { get; set; } = false;

        public override void BeforeTest(ITest test)
        {
            if (test.Fixture is DriverTestFixture fixtureInstance && IsCreatedBeforeTest)
            {
                EnvironmentManager.Instance.CreateFreshDriver(enableFrameTracker: true);
                fixtureInstance.DriverInstance = EnvironmentManager.Instance.GetCurrentDriver();
            }

            base.BeforeTest(test);
        }

        public override void AfterTest(ITest test)
        {
            if (test.Fixture is DriverTestFixture fixtureInstance && IsCreatedAfterTest)
            {
                EnvironmentManager.Instance.CreateFreshDriver(enableFrameTracker: true);
                fixtureInstance.DriverInstance = EnvironmentManager.Instance.GetCurrentDriver();
            }
        }
    }
}
