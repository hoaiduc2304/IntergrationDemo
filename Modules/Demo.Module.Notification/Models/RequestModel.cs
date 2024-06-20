using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Module.Notification.Models
{
    public class RequestModel
    {
        public Template template { get; set; }
        public Provider provider { get; set; }
    }
    public class Template
    {
        public string code { get; set; }
        public object Pramas { get; set; }
    }
}

