using System.Collections.Generic;
using NUnit.Framework;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Zu.WebDriver;
using Zu.WebDriver.BasicTypes;
using Zu.ZuChromeDriver.Tests.Environment;

namespace Zu.ZuChromeDriver.Tests
{
    [TestFixture]
    public class GetLogsTest : DriverTestFixture
    {
        private IWebDriver localDriver;

        [TearDown]
        public void QuitDriver()
        {
            if (localDriver != null) {
                localDriver.CloseSync();
                localDriver = null;
            }
        }

        [Test]
        public async Task LogBufferShouldBeResetAfterEachGetLogCall()
        {

            ReadOnlyCollection<string> logTypes = await driver.Options().Logs.AvailableLogTypes();
            foreach (string logType in logTypes) {
                await driver.GoToUrl(simpleTestPage);
                ReadOnlyCollection<LogEntry> firstEntries = await driver.Options().Logs.GetLog(logType);
                if (firstEntries.Count > 0) {
                    ReadOnlyCollection<LogEntry> secondEntries = await driver.Options().Logs.GetLog(logType);
                    Assert.That(HasOverlappingLogEntries(firstEntries, secondEntries), Is.False,
                        $"There should be no overlapping log entries in consecutive get log calls for {logType} logs");
                }
            }
        }

        [Test]
        public async Task DifferentLogsShouldNotContainTheSameLogEntries()
        {
            await driver.GoToUrl(simpleTestPage);
            Dictionary<string, ReadOnlyCollection<LogEntry>> logTypeToEntriesDictionary = [];
            ReadOnlyCollection<string> logTypes = await driver.Options().Logs.AvailableLogTypes();
            foreach (string logType in logTypes) {
                logTypeToEntriesDictionary.Add(logType, await driver.Options().Logs.GetLog(logType));
            }

            foreach (string firstLogType in logTypeToEntriesDictionary.Keys) {
                foreach (string secondLogType in logTypeToEntriesDictionary.Keys) {
                    if (firstLogType != secondLogType) {
                        Assert.That(HasOverlappingLogEntries(logTypeToEntriesDictionary[firstLogType], logTypeToEntriesDictionary[secondLogType]), Is.False,
                            $"Two different log types ({firstLogType}, {secondLogType}) should not contain the same log entries");
                    }
                }
            }
        }

        [Test]
        public async Task TurningOffLogShouldMeanNoLogMessages()
        {
            ReadOnlyCollection<string> logTypes = await driver.Options().Logs.AvailableLogTypes();
            foreach (string logType in logTypes) {
                await CreateWebDriverWithLogging(logType, LogLevel.Off);
                ReadOnlyCollection<LogEntry> entries = await localDriver.Options().Logs.GetLog(logType);
                Assert.AreEqual(0, entries.Count,
                    $"There should be no log entries for log type {logType} when logging is turned off.");
                QuitDriver();
            }
        }

        private async Task CreateWebDriverWithLogging(string logType, LogLevel logLevel)
        {
            var chromeConfig = EnvironmentManager.CreateTestChromeConfig();
            chromeConfig.LoggingPreferences[logType] = logLevel;
            var chrome = new Zu.Chrome.ZuChromeDriver(chromeConfig);
            localDriver = new ZuWebDriver(chrome);
            await localDriver.GoToUrl(simpleTestPage);
        }

        private bool HasOverlappingLogEntries(ReadOnlyCollection<LogEntry> firstLog, ReadOnlyCollection<LogEntry> secondLog)
        {
            foreach (LogEntry firstEntry in firstLog) {
                foreach (LogEntry secondEntry in secondLog) {
                    if (firstEntry.Level == secondEntry.Level && firstEntry.Message == secondEntry.Message && firstEntry.Timestamp == secondEntry.Timestamp) {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
