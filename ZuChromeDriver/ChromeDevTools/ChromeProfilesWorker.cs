// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Diagnostics;
using System.Runtime.InteropServices;
using Zu.WebDriver.BasicTypes;

namespace Zu.Chrome
{
    public static class ChromeProfilesWorker
    {
        static ChromeProfilesWorker()
        {
            ChromeBinaryFileName = GetDefaultChromeBinaryFileName();
        }


        public static string ChromeBinaryFileName { get; set; }

        private static string GetDefaultChromeBinaryFileName()
        {
            var platformName = GetPlatformString();
            if (platformName == "windows") {
                return FindExistingFile(
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"Google\Chrome\Application\chrome.exe"),
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), @"Google\Chrome\Application\chrome.exe"),
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), @"Google\Chrome\Application\chrome.exe"),
                    "chrome.exe");
            } else if (platformName == "linux") {
                return FindExistingFile(
                    "/usr/bin/google-chrome",
                    "/usr/bin/google-chrome-stable",
                    "/usr/bin/chromium-browser",
                    "/usr/bin/chromium",
                    "/snap/bin/chromium",
                    "google-chrome");
            } else if (platformName == "mac") {
                return FindExistingFile(
                    "/Applications/Google Chrome.app/Contents/MacOS/Google Chrome",
                    Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Applications/Google Chrome.app/Contents/MacOS/Google Chrome"),
                    "/Applications/Google Chrome for Testing.app/Contents/MacOS/Google Chrome for Testing",
                    "Google Chrome");
            }

            return "chrome";
        }

        private static string FindExistingFile(params string[] fileNames)
        {
            foreach (var fileName in fileNames) {
                if (File.Exists(fileName))
                    return fileName;
            }

            return fileNames[fileNames.Length - 1];
        }

        public static ChromeProcessInfo OpenChromeProfile(string userDir, int port = 5999, bool isHeadless = false, WebSize windowSize = null)
        {
            return OpenChromeProfile(new ChromeDriverConfig { UserDir = userDir, Port = port, Headless = isHeadless, WindowSize = windowSize });
        }

        public static ChromeProcessInfo OpenChromeProfile(ChromeDriverConfig config)
        {
            //if (string.IsNullOrWhiteSpace(userDir)) throw new ArgumentNullException(nameof(userDir));
            if (config.Port < 1 || config.Port > 65000) throw new ArgumentOutOfRangeException(nameof(config.Port));
            bool firstRun = false;
            if (!string.IsNullOrWhiteSpace(config.UserDir) && !Directory.Exists(config.UserDir)) {
                firstRun = true;
                Directory.CreateDirectory(config.UserDir);
            }

            var args = "--remote-debugging-port=" + config.Port
                + (string.IsNullOrWhiteSpace(config.UserDir) ? "" : " --user-data-dir=\"" + config.UserDir + "\"")
                + (firstRun ? " --bwsi --no-first-run" : "")
                + (config.DisablePopupBlocking ? " --disable-popup-blocking" : "")
                + (config.Headless ? " --headless --disable-gpu" : "")
                + (config.WindowSize != null ? $" --window-size={config.WindowSize.Width},{config.WindowSize.Height}" : "")
                + (string.IsNullOrWhiteSpace(config.CommandLineArguments) ? "" : " " + config.CommandLineArguments);


            if (config.Headless || GetPlatformString() == "windows") {
                var processWithJob = new ProcessWithJobObject();
                var proc = processWithJob.StartProc(ChromeBinaryFileName, args);
                Thread.Sleep(1000);
                return new ChromeProcessInfo
                {
                    Proc = proc,
                    ProcWithJobObject = processWithJob,
                    UserDir = config.UserDir,
                    Port = config.Port,
                };
            }

            var process = new Process();
            process.StartInfo.FileName = ChromeBinaryFileName;
            process.StartInfo.Arguments = args;
            process.StartInfo.UseShellExecute = false;
            process.Start();
            Thread.Sleep(1000);
            return new ChromeProcessInfo { Proc = process, UserDir = config.UserDir, Port = config.Port };

        }


        public static string GetPlatformString()
        {
            string platformName = "unknown";
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
                platformName = "windows";
            } else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) {
                platformName = "linux";
            } else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) {
                platformName = "mac";
            }
            return platformName;
        }
    }
}
