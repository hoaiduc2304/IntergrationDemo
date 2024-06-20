using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DNH.Core.Intergration.Models;

namespace DNH.Core.Intergration.Util
{
    public class AuthHelper
    {
        public static async Task<DAToken> GetAuthen(IDClient setting)
        {
            var form = new Dictionary<string, string>
                {
                    {"grant_type","client_credentials"},
                    {"client_id", setting.ClientId},
                    {"client_secret",  setting.ClientSecret},

                };
            HttpClient client = new HttpClient();

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // List all Names.
            HttpResponseMessage response = await client.PostAsync(setting.IdentityServerUrl+ "/connect/token", new FormUrlEncodedContent(form));  // Blocking call!
            var jsonContent = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<DAToken>(jsonContent);
            return data;
        }
    }
}
