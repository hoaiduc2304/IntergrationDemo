using DNH.Core.Intergration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Module.Notification.Settings
{
    public class EndpointConfig
    {

        public string BaseUrl { get; set; }
        public IDClient EndPointServer { get; set; }
    }
}
