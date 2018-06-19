using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Net.Http;
using WhatsThatFood.Domain.Dtos;

namespace WhatsThatFood.Services.Services
{
    public class WatsonVisualRecognitionService : IWatsonVisualRecognitionService
    {
        public IConfiguration Configuration { get; }
        private IHttpProxyClientService _httpProxyClientService;
        private readonly string _watsonUri;
        private readonly string _tokenUri;
        private string _accessToken;
        private string _refreshToken;

        public bool IsUserAuthenticated
        {
            get
            {
                if(string.IsNullOrWhiteSpace(Configuration["Watson:ApiKey"]))
                {
                    return false;
                }
                if (string.IsNullOrWhiteSpace(_accessToken))
                {
                    RequestToken();
                }
                if (!IsTokenValid)
                {
                    RefreshToken();
                }
                if(!string.IsNullOrEmpty(_accessToken)||!string.IsNullOrEmpty(_refreshToken))
                {
                    return false;
                }
                return true;
            }
        }

        private bool IsTokenValid
        {
            get
            {
                // TODO
                return true;
            }
        }

        private void RefreshToken()
        {
            // TODO
        }

        private void RequestToken()
        {
            // TODO
        }

        public WatsonVisualRecognitionService(IHttpProxyClientService httpProxyClientService, IConfiguration configuration)
        {
            _httpProxyClientService = httpProxyClientService;
            Configuration = configuration;
            _watsonUri = $"{Configuration["Watson:BaseUri"]}?{Configuration["Watson:Version"]}";
            _tokenUri = Configuration["Watson:TokenUri"];
        }

        public VisualRecognitionDto DetectFoodFromImage(string base64ImageString)
        {
            // Strip the beginning "data:image/xxx;base64,"
            var rawImageStringStartingIndex = base64ImageString.IndexOf("base64,") + "base64,".Length;
            var rawImageString = base64ImageString.Substring(rawImageStringStartingIndex);

            var bytes = Convert.FromBase64String(rawImageString);
            MultipartFormDataContent content = new MultipartFormDataContent
            {
                new StreamContent(new MemoryStream(bytes)),
                new StringContent(Configuration["Watson:ClassifierId"])
            };

            var response = _httpProxyClientService.SendRequest(_watsonUri, content).Result;
            var res = response.Content.ReadAsStringAsync().Result;
            return new VisualRecognitionDto();
        }
    }
}
