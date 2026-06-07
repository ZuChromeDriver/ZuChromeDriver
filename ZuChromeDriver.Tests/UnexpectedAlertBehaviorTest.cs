using NUnit.Framework;

namespace Zu.ZuChromeDriver.Tests
{
    [TestFixture]
    [Ignore("Needs UnhandledPromptBehavior in Zu")]
    public class UnexpectedAlertBehaviorTest : DriverTestFixture
    {
        protected override bool RequiresFrameTracker => true;

        [Test]
        public void CanAcceptUnhandledAlert()
        {
        }

        [Test]
        public void CanSilentlyAcceptUnhandledAlert()
        {
        }

        [Test]
        public void CanDismissUnhandledAlert()
        {
        }

        [Test]
        public void CanSilentlyDismissUnhandledAlert()
        {
        }

        [Test]
        public void CanDismissUnhandledAlertsByDefault()
        {
        }

        [Test]
        public void CanDismissUnhandledAlertsViaPerType()
        {
        }

        [Test]
        public void CanDismissUnhandledAlertsViaDefaultPerType()
        {
        }

        [Test]
        public void CanIgnoreUnhandledAlert()
        {
        }
    }
}
