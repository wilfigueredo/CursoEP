using System.IO;
using System.Net.Http;
using Eventos.IO.Services.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace Eventos.IO.Tests.API.Integration_Tests
{
    public class Environment
    {
        public static TestServer Server { get; set; }
        public static HttpClient Client { get; set; }

        public static void CriarServidor()
        {
            Server = new TestServer(
                new WebHostBuilder()
                    .UseKestrel()
                    .UseEnvironment("Testing")
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseUrls("http://localhost:8285")
                    .UseStartup<StartupTests>());

            Client = Server.CreateClient();
        }
    }
}