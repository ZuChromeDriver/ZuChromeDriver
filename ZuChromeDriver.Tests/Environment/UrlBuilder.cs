using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Zu.ZuChromeDriver.Tests.Environment
{
    public class UrlBuilder
    {
        static readonly HttpClient _httpClient = new();

        string _protocol;
        string _port;
        string _securePort;

        public string AlternateHostName { get; }

        public string HostName { get; }

        public string Path { get; }

        public UrlBuilder()
        {
            _protocol = "http";
            HostName = "localhost";
            _port = "2310";
            _securePort = "2410";
            Path = "HtmlForTests";
            //Use the first IPv4 address that we find
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
            foreach (IPAddress ip in Dns.GetHostEntry(HostName).AddressList) {
                if (ip.AddressFamily == AddressFamily.InterNetwork) {
                    ipAddress = ip;
                    break;
                }
            }
            AlternateHostName = ipAddress.ToString();
        }

        public string LocalWhereIs(string page) => $"{_protocol}://localhost:{_port}/{Path}/{page}";

        public string WhereIs(string page) => $"{_protocol}://{HostName}:{_port}/{Path}/{page}";

        public string WhereElseIs(string page) => $"{_protocol}://{AlternateHostName}:{_port}/{Path}/{page}";

        public string WhereIsSecure(string page) => $"https://{HostName}:{_securePort}/{Path}/{page}";

        public string CreateInlinePage(InlinePage page)
        {
            Uri createPageUri = new(new Uri(WhereIs(string.Empty)), "CreatePage.aspx");
            Dictionary<string, object> payloadDictionary = new()
            {
                ["content"] = page.ToString()
            };
            DirectoryInfo info = new(EnvironmentManager.Instance.CurrentDirectory);
            while (info != info.Root && string.Compare(info.Name, "ZuChromeDriver", StringComparison.OrdinalIgnoreCase) != 0) {
                info = info.Parent;
            }

            payloadDictionary["dir"] = System.IO.Path.Combine(info.FullName, "HtmlForTests", "temp");
            string commandPayload = JsonSerializer.Serialize(payloadDictionary);
            byte[] data = Encoding.UTF8.GetBytes(commandPayload);
            using var requestMessage = new HttpRequestMessage(HttpMethod.Post, createPageUri);
            requestMessage.Content = new ByteArrayContent(data);
            requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json") { CharSet = "utf8" };

            using HttpResponseMessage response = _httpClient.Send(requestMessage);
            response.EnsureSuccessStatusCode();

            using Stream responseStream = response.Content.ReadAsStream();
            using StreamReader responseReader = new(responseStream, Encoding.UTF8);
            string responseString = responseReader.ReadToEnd();

            return new Uri(new Uri(WhereIs(string.Empty)), "temp/" + responseString.Split('\n').First()).ToString();
        }
    }
}
