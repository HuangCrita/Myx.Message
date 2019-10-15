using Myx.Message.Sdk;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Myx.Message.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = MyxMessageClientFactory.Create("http://localhost:5000");
            var paramsDir = new Dictionary<string, string>();
            paramsDir.Add("sellmoney", "147258369");
            await client.SendSms(new SmsQueryParameters(
                "15820713311",
                "共享惠",
                "SMS_165412326",
                paramsDir
                ));
        }
    }
}
