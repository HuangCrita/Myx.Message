using DotNetCore.CAP;
using Myx.Message.ALiYun.Sms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Myx.Message.Sms.Services
{
    public interface ISmsService
    {
        Task SendSmsMessage(SmsQueryParameters parameters);
    }
}
