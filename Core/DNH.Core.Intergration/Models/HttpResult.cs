using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNH.Core.Intergration.Models
{
    public class HttpResult<T>
    {
        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }
        public T Content { get; set; }
        public string ErrorMessage { get; set; }
    }
}
