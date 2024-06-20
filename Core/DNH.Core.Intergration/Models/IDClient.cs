using System;
using System.Collections.Generic;
using System.Text;

namespace DNH.Core.Intergration.Models
{
    public class IDClient
    {
        public string IdentityServerUrl { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
