using DNH.Core.Intergration.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Module.Notification.Settings
{
    public class NotificationClientSetting : BaseRequestConfig, IRequestConfig
    {
        public NotificationClientSetting() { }

        public NotificationClientSetting(string baseUrl, string accessToken, string tokenType = "Bearer") : base(baseUrl, accessToken, tokenType)
        {

        }
    }
}
