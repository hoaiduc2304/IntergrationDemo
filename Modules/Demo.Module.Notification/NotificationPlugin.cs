using Demo.Module.Notification.Services;
using Demo.Module.Notification.Settings;
using DNH.Core.Intergration.Settings;
using DNH.Core.Intergration.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using Plugin.Abstraction.Plugins;
using Plugin.Abstraction.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Module.Notification
{
    internal class NotificationPlugin : IPlugin
    {
        public string Id => "";
        private string _tokenType = "Bearer";
        public void RegisterDI(IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton(provider =>
            {
                var settingService = provider.CreateScope().ServiceProvider.GetRequiredService<ISettingService>();
                return settingService.Bind<EndpointConfig>("IntergrationAPI:ProjectEndPoint");
            });
            services.AddScoped<IRequestConfig>(provider =>
            {
                var settingService = provider.GetService<EndpointConfig>();
                var dx = provider.GetService<IHttpContextAccessor>();
                string _accessToken = null;

                if (dx?.HttpContext?.Request?.Headers?.TryGetValue("Authorization", out var accessTokenHeader) == true)
                {
                    _accessToken = accessTokenHeader.ToString();

                    if (!string.IsNullOrEmpty(_accessToken) && _accessToken.StartsWith("Bearer "))
                    {
                        _accessToken = _accessToken.Substring("Bearer ".Length).Trim();
                    }
                }

                if (string.IsNullOrEmpty(_accessToken))
                {
                    var token = AuthHelper.GetAuthen(settingService.EndPointServer).Result;
                    if (token != null)
                    {
                        _accessToken = token.access_token;
                    }
                }

                return new NotificationClientSetting(settingService.BaseUrl, _accessToken, _tokenType);
            });
            services.AddScoped<INotificationService, NotificationService>();
        }
    }
}
