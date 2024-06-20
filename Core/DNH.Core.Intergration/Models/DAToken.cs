using System;
using System.Collections.Generic;
using System.Text;

namespace DNH.Core.Intergration.Models
{
    public class DAToken
    {
        public string access_token { get; set; }

        public string token_type { get; set; }
        public string scope { get; set; }
    }
}
