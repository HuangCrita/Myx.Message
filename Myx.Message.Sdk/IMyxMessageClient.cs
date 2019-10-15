using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Myx.Message.Sdk
{
    public interface IMyxMessageClient
    {
        Task SendSms(SmsQueryParameters parameters);
    }
}
