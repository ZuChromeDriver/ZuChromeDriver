using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;

namespace Zu.ZuChromeDriver.Tests.Environment
{
    public class TestWebServer
    {
        static readonly HttpClient _httpClient = new();

        private Process webserverProcess;
        private readonly StringBuilder _webServerOutput = new();

        //private string standaloneTestJar = @"buck-out/gen/java/client/test/org/openqa/selenium/environment/webserver.jar";
        //private string webserverClassName = "org.openqa.selenium.environment.webserver.JettyAppServer";
        public static int Port = 2310;
        private string _projectRootPath;
        //private SimpleHTTPServer _simpleHttpServer;

        public TestWebServer(string projectRoot)
        {
            _projectRootPath = projectRoot;
        }

        public void Start()
        {
            //if (webserverProcess == null || webserverProcess.HasExited)
            //{
            //    standaloneTestJar = standaloneTestJar.Replace('/', Path.DirectorySeparatorChar);
            //    if (!File.Exists(Path.Combine(projectRootPath, standaloneTestJar)))
            //    {
            //        throw new FileNotFoundException(
            //            string.Format(
            //                "Test webserver jar at {0} didn't exist - please build it using something like {1}",
            //                standaloneTestJar,
            //                "go //java/client/test/org/openqa/selenium/environment:webserver"));
            //    }

            //    string javaExecutableName = "java";
            //    if (System.Environment.OSVersion.Platform == PlatformID.Win32NT || System.Environment.OSVersion.Platform == PlatformID.Win32Windows)
            //    {
            //        javaExecutableName = javaExecutableName + ".exe";
            //    }

            //    webserverProcess = new Process();
            //    webserverProcess.StartInfo.FileName = javaExecutableName;
            //    webserverProcess.StartInfo.Arguments = "-cp " + standaloneTestJar + " " + webserverClassName;
            //    webserverProcess.StartInfo.WorkingDirectory = projectRootPath;
            //    webserverProcess.Start();
//#if DEBUG
            bool ProbeServersReady()
            {
                try
                {
                    using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(2));
                    using var simple = _httpClient.Send(
                        new HttpRequestMessage(HttpMethod.Get, $"http://localhost:{Port}/HtmlForTests/simpleTest.html"),
                        cts.Token);
                    if (simple.StatusCode != HttpStatusCode.OK)
                    {
                        return false;
                    }

                    using var cts2 = new CancellationTokenSource(TimeSpan.FromSeconds(2));
                    using var encoding = _httpClient.Send(
                        new HttpRequestMessage(HttpMethod.Get, $"http://localhost:{Port}/HtmlForTests/encoding"),
                        cts2.Token);
                    return encoding.StatusCode == HttpStatusCode.OK;
                }
                catch (HttpRequestException)
                {
                    return false;
                }
                catch (OperationCanceledException)
                {
                    return false;
                }
            }

            void LaunchWebServerProcess()
            {
                string webserverProjectPath = Path.Combine(_projectRootPath, "HtmlForTests", "HtmlForTests.csproj");
                webserverProcess = new Process();
                webserverProcess.StartInfo.FileName = "dotnet";
                webserverProcess.StartInfo.Arguments = $"run --project \"{webserverProjectPath}\" --urls http://localhost:{Port}";
                webserverProcess.StartInfo.WorkingDirectory = _projectRootPath;
                webserverProcess.StartInfo.UseShellExecute = false;
                webserverProcess.StartInfo.RedirectStandardOutput = true;
                webserverProcess.StartInfo.RedirectStandardError = true;
                webserverProcess.StartInfo.CreateNoWindow = true;
                webserverProcess.OutputDataReceived += (_, e) => AppendWebServerOutput(e.Data);
                webserverProcess.ErrorDataReceived += (_, e) => AppendWebServerOutput(e.Data);
                webserverProcess.Start();
                webserverProcess.BeginOutputReadLine();
                webserverProcess.BeginErrorReadLine();
            }

            // Two attempts: if an old HtmlForTests is still on the port (no /encoding), probe fails — kill and restart.
            for (var outerAttempt = 0; outerAttempt < 2; outerAttempt++)
            {
                if (webserverProcess == null || webserverProcess.HasExited)
                {
                    LaunchWebServerProcess();
                }

                DateTime deadline = DateTime.Now.Add(TimeSpan.FromSeconds(30));
                while (DateTime.Now < deadline)
                {
                    if (ProbeServersReady())
                    {
                        return;
                    }

                    Thread.Sleep(200);
                }

                Stop();
            }

            throw new TimeoutException($"Could not start the test web server in 30 seconds (need simpleTest.html and /encoding).{System.Environment.NewLine}{_webServerOutput}");
//#else
//            //Console.WriteLine("Mode=Release");
//            simpleHTTPServer = new SimpleHTTPServer(projectRootPath, Port);
//#endif
            //}
        }

        public void Stop()
        {
            //HttpWebRequest request = WebRequest.Create(EnvironmentManager.Instance.UrlBuilder.LocalWhereIs("quitquitquit")) as HttpWebRequest;
            //try
            //{
            //    request.GetResponse();
            //}
            //catch (WebException)
            //{
            //}
//#if DEBUG

            if (webserverProcess != null)
            {
                try
                {
                    if (!webserverProcess.HasExited)
                    {
                        webserverProcess.Kill(true);
                        webserverProcess.WaitForExit(10000);
                    }
                }
                catch (Exception)
                {
                }
                finally
                {
                    webserverProcess.Dispose();
                    webserverProcess = null;
                }
            }
//#else
//            simpleHTTPServer.Stop();
//#endif
        }

        private void AppendWebServerOutput(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return;
            }

            lock (_webServerOutput)
            {
                _webServerOutput.AppendLine(data);
            }
        }

    }
}
