using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Module.Notification.Models
{
    public class TemplateResponse
    {
        public string TemplateCode { get; set; }
        public string status { get; set; }
        public int code { get; set; }
        public string errorCode { get; set; }
        public GenerateTemplateContent data { get; set; }
    }
    public class GenerateTemplateContent
    {
        public string content { get; set; }
    }

}
