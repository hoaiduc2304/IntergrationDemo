using DNH.Core.Intergration.Models;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace DNH.Core.Intergration.Settings
{
    public interface IRequestConfig
    {
        public string BaseUrl { get; }
        public string AccessToken { get; }
        public string TokenType { get; }
        public IDClient EndPointServer { get;  }
        void setEndPoint(IDClient endpoint);
    }

    public class BaseRequestConfig: IRequestConfig
    {
        private string _baseUrl = "";
        private string _accessToken = "";
        private string _tokenType = "";
        private IDClient _endPointServer;
        public BaseRequestConfig()
        {

        }
        public BaseRequestConfig(string baseUrl, string accessToken, string tokenType)
        {
            _baseUrl= baseUrl;
            _accessToken= accessToken;
            _tokenType= tokenType;
        }
        public BaseRequestConfig(string baseUrl, string accessToken, string tokenType, IDClient client)
        {
            _baseUrl = baseUrl;
            _accessToken = accessToken;
            _tokenType = tokenType;
            _endPointServer = client;
        }
        public void setEndPoint(IDClient endpoint)
        {
            _endPointServer = endpoint;
        }

        public string BaseUrl => _baseUrl;

        public string AccessToken => _accessToken;

        public string TokenType => _tokenType;

        public IDClient EndPointServer => _endPointServer;
    }
}
