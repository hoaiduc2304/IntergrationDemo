using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DNH.Core.Intergration.Models;
namespace DNH.Core.Intergration
{
    public class HttpClientService
    {
        private readonly HttpClient _client;
        private readonly string _baseUrl;
        private readonly string _token;
        private readonly string _tokenType;
        public HttpClientService()
        {
        }
        public HttpClientService(string baseUrl, string token, string tokenType= "Bearer")
        {
            _baseUrl = baseUrl;
            _token = token;
            _tokenType = tokenType;
            _client = new HttpClient
            {
                BaseAddress = new Uri(_baseUrl)
            };
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_tokenType, _token);
        }

        public async Task<T> SendRequestAsync<T>(string uri, HttpMethod method, object data)
        {
            var request = new HttpRequestMessage(method, uri)
            {
                Content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json")
            };

            var response = await _client.SendAsync(request);
            return await CreateHttpResultContent<T>(response);
        }

        public async Task<T> GetAsync<T>(string uri)
        {
            var response = await _client.GetAsync(uri);
            return await CreateHttpResultContent<T>(response);
        }


        public async Task<T> PostAsync<T>(string uri, object data)
        {
            var jsonData = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(uri, content);
            return await CreateHttpResultContent<T>(response);
        }

        public async Task<T> PutAsync<T>(string uri, object data)
        {
            var jsonData = JsonSerializer.Serialize(data);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync(uri, content);
            return await CreateHttpResultContent<T>(response);
        }

        public async Task<HttpResult<string>> DeleteAsync(string uri)
        {
            var response = await _client.DeleteAsync(uri);
            return await CreateHttpStringResult(response);
        }
        private async Task<HttpResponseMessage> SendRequestStringAsync(string uri, HttpMethod method, string data)
        {
            var request = new HttpRequestMessage(method, uri)
            {
                Content = new StringContent(data, Encoding.UTF8, "application/json")
            };

            return await _client.SendAsync(request);
        }

        private async Task<T> CreateHttpResultContent<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(responseBody);
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException($"Request failed with status code {response.StatusCode}: {errorMessage}");
            }
        }
      
        private async Task<HttpResult<string>> CreateHttpStringResult(HttpResponseMessage response)
        {
            var result = new HttpResult<string>
            {
                IsSuccess = response.IsSuccessStatusCode,
                StatusCode = (int)response.StatusCode,
                Content = response.IsSuccessStatusCode ? await response.Content.ReadAsStringAsync() : null,
                ErrorMessage = !response.IsSuccessStatusCode ? response.ReasonPhrase : null
            };
            return result;
        }

    }
}