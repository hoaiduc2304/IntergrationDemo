using System;
using System.Collections.Generic;
using System.Text;

namespace DNH.Core.Intergration
{
    public static class SDKClient
    {
        public static HttpClientService Create(string baseUrl, string token, string tokenType= "Bearer")
        {
            return new HttpClientService(baseUrl, token, tokenType);
        }
    }
}

