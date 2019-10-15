using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Dysmsapi.Model.V20170525;
using Microsoft.Extensions.Options;
using Myx.Message.ALiYun.Sms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Myx.Message.ALiYun
{
    public class ALiYunClient : IALiYunClient
    {
        private const string SmsProduct = "Dysmsapi";//短信API产品名称

        private const string SmsDomain = "dysmsapi.aliyuncs.com";//短信API产品域名
        private readonly DefaultAcsClient _smsClient;
        public ALiYunClient(IOptions<ALiYunConfig> configOptions)
        {
            var aLiYunConfig = configOptions.Value;
            if (aLiYunConfig is null)
                throw new ArgumentNullException("ALiYunConfig can not be null.");
            DefaultProfile smsProfile = DefaultProfile.GetProfile(aLiYunConfig.RegionId, aLiYunConfig.AccessKeyId, aLiYunConfig.AccessSecret);
            smsProfile.AddEndpoint(aLiYunConfig.EndpointName, aLiYunConfig.RegionId, SmsProduct, SmsDomain);
            _smsClient = new DefaultAcsClient(smsProfile);
        }

        public Task<string> SendSmsAsync(SmsQueryParameters queryParameters)
        {
            SendSmsRequest request = new SendSmsRequest();

            // 必填:待发送手机号。支持以逗号分隔的形式进行批量调用，批量上限为20个手机号码,批量调用相对于单条调用及时性稍有延迟,验证码类型的短信推荐使用单条调用的方式
            request.PhoneNumbers = queryParameters.PhoneNumbers;
            //必填:短信签名-可在短信控制台中找到
            request.SignName = queryParameters.SignName ?? "共享惠";
            //必填:短信模板-可在短信控制台中找到
            request.TemplateCode = queryParameters.TemplateCode;
            //可选:模板中的变量替换JSON串,如模板内容为"亲爱的${name},您的验证码为${code}"时,此处的值为
            //request.TemplateParam = "{\"number\":\"" + code + "\"}";
            request.TemplateParam = JsonConvert.SerializeObject(queryParameters.TemplateParam);

            SendSmsResponse sendSmsResponse = _smsClient.GetAcsResponse(request);
            return Task.FromResult(sendSmsResponse.Message);
        }
    }
}
