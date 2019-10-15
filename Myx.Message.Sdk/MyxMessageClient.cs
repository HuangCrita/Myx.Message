using Newtonsoft.Json;
using Polly;
using Polly.Retry;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Myx.Message.Sdk
{
    internal class MyxMessageClient : IMyxMessageClient
    {
        private const string sendSmsApi = "api/message/SendSms";
        private readonly HttpClient client;
        private readonly AsyncRetryPolicy asyncRetryPolicy;

        public MyxMessageClient(string url)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
            asyncRetryPolicy = Policy
              .Handle<Exception>()
              .RetryAsync(3);
        }
        
        public async Task SendSms(SmsQueryParameters parameters)
        {
            await asyncRetryPolicy.ExecuteAsync( async () => {
                HttpContent content = new StringContent(JsonConvert.SerializeObject(parameters));
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                await client.PostAsync(sendSmsApi, content);
            });
        }
    }
}
