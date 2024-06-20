using System;
using System.Collections.Generic;
using System.Text;

namespace DNH.Core.Intergration.Models
{
    public class RequestSetting
    {
        public bool isAuth { get; set; }
        public string Token { get; set; }
        public string BaseUrl { get; set; }
        public string TokenType { get; set; }
    }
}
