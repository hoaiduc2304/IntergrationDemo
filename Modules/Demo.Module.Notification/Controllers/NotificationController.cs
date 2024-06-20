using Demo.Module.Notification.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Module.Notification.Controllers
{
    public class NotificationController : BaseApiController
    {
        INotificationService _notificationService;
        public NotificationController(INotificationService notificationService) {
            _notificationService = notificationService;
        }

        [HttpGet("template/{templateCode}")]
        public  async Task<IActionResult> GetTemplate(string templateCode)
        {
           var result = await  _notificationService.GetTemplate(templateCode);
            return Ok(result);
        }

        [HttpPost("send-message")]
        public async Task<IActionResult> SendMessage(string templateCode, List<string> receivers)
        {
            await _notificationService.sendMessage(new Models.RequestModel()
            {
                 provider = new Models.Provider
                 {
                     name = "DNHProvider",
                     receiver = receivers,
                     type = Enums.ChatTypeEnum.email
                 },
                 template = new Models.Template()
                 {
                     code = templateCode,
                     Pramas = new List<string>()
                        {
                            "param1",
                            "param2",
                            "param3"
                        }
                 }

             });


            return Ok("OK");
        }
    }
}
