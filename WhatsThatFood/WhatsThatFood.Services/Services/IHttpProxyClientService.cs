using System.Net.Http;
using System.Threading.Tasks;

namespace WhatsThatFood.Services.Services
{
    public interface IHttpProxyClientService
    {
        Task<HttpResponseMessage> SendRequest(string uri, HttpContent content);
    }
}
