using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Module.Notification.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    //[EnableCors(MainConfig.CorsPublic)]
    //[Authorize]
    public class BaseApiController: ControllerBase
    {
    }
}
