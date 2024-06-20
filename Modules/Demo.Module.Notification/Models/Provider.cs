using Demo.Module.Notification.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Module.Notification.Models
{
    public class Provider
    {
        public string name { get; set; }
        public string sender { get; set; }
        public List<string> receiver { get; set; }
        public string deviceToken { get; set; } // Only for Firebase provider
        public ChatTypeEnum type { get; set; }
    }


}
