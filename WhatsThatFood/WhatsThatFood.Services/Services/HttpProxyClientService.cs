using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace WhatsThatFood.Services.Services
{
    public class HttpProxyClientService : IHttpProxyClientService
    {
        public IConfiguration Configuration { get; }
        private static HttpClient httpClient;

        public bool ProxyEnabled
        {
            get
            {
                return bool.TryParse(Configuration["Proxy:Enabled"], out bool proxyEnabled);
            }
        }

        public HttpClient HttpClient {
            get
            {
                if (httpClient == null)
                {
                    if (ProxyEnabled)
                    {
                        var host = Configuration["Proxy:Host"];
                        var port = Configuration["Proxy:Port"];
                        var proxy = new WebProxy()
                        {
                            Address = new Uri($"{host}:{port}"),
                            UseDefaultCredentials = true
                        };
                        var httpClientHandler = new HttpClientHandler()
                        {
                            Proxy = proxy,
                        };
                        httpClient = new HttpClient(handler: httpClientHandler, disposeHandler: true);
                    }
                    else
                    {
                        httpClient = new HttpClient();
                    }
                }
                return httpClient;
            }
        }

        public HttpProxyClientService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Task<HttpResponseMessage> SendRequest(string uri, HttpContent content)
        {
            try
            {
                return HttpClient.PostAsync(uri, content);
            }
            catch(Exception)
            {
                return Task.FromResult(
                    new HttpResponseMessage(HttpStatusCode.InternalServerError)
                    );
            }
        }

    }
}
