using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;
using Xunit;

namespace WebApi.Tests.Shared
{
    public class ApiServer : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        private WebApplicationFactory<Startup> Factory => ConfigureWebHost is null
            ? _factory
            : _factory.WithWebHostBuilder(ConfigureWebHost);

        public Action<IWebHostBuilder>? ConfigureWebHost { get; set; } = null;

        public HttpClient Client => Factory.CreateClient();

        public ApiServer(WebApplicationFactory<Startup> factory) => _factory = factory;
    }
}