using Myx.Message.ALiYun.Sms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Myx.Message.ALiYun
{
    public interface IALiYunClient
    {
        Task<string> SendSmsAsync(SmsQueryParameters queryParameters);
    }
}
