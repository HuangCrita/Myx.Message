using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;
using Myx.Message.Api.Models;

namespace Myx.Message.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly ICapPublisher _capBus;

        public MessageController(ICapPublisher capBus)
        {
            _capBus = capBus;
        }
        [HttpPost("SendSms")]
        public async Task<IActionResult> SendSmsAsync([FromBody]SmsQueryParameters parameters)
        {
            await _capBus.PublishAsync("message.services.sms", parameters);
            return Ok();
        }
    }
}
