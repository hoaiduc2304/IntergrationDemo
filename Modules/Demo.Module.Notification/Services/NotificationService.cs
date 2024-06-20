using DNH.Core.Intergration.Settings;
using DNH.Core.Intergration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Module.Notification.Models;
using Demo.Module.Notification.Enums;

namespace Demo.Module.Notification.Services
{
    public interface INotificationService
    {
        Task sendMessage(RequestModel request);
        Task<TemplateResponse> GetTemplate(string TemplateCode);
    }
    public class NotificationService : INotificationService
    {
        HttpClientService _proposalClient;
        public NotificationService(IRequestConfig requestConfig)
        {
            //Inital BaseUrl, Token, 
            _proposalClient = SDKClient.Create(requestConfig.BaseUrl, requestConfig.AccessToken, requestConfig.TokenType);
        }

        public async Task sendMessage(RequestModel request)
        {
            await _proposalClient.PostAsync<string>(NotificationCons.SendMessage, request);
        }
        public async Task<TemplateResponse> GetTemplate(string TemplateCode)
        {
            string uri = NotificationCons.getTemplate + "/" + TemplateCode;
            return await _proposalClient.GetAsync<TemplateResponse>(uri);
        }
    }
}
