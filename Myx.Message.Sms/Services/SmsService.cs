using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore.CAP;
using Myx.Message.ALiYun;
using Myx.Message.ALiYun.Sms;
using Myx.Message.Core.Entities;
using Myx.Message.Core.Repository;
using Newtonsoft.Json;

namespace Myx.Message.Sms.Services
{
    public class SmsService : ISmsService, ICapSubscribe
    {
        private readonly IALiYunClient _aLiYunClient;

        private readonly IBaseRepository<SmsRecord, long> _smsRecordRepository;

        public SmsService(IALiYunClient aLiYunClient, IBaseRepository<SmsRecord, long> smsRecordRepository)
        {
            _aLiYunClient = aLiYunClient;
            _smsRecordRepository = smsRecordRepository;
        }

        [CapSubscribe("message.services.sms")]
        public async Task SendSmsMessage(SmsQueryParameters parameters)
        {
            string status = "fail";
            string reason = "";
            try
            {
                var result = await _aLiYunClient.SendSmsAsync(parameters);
                status = result.ToLower().Equals("ok") ? "success" : "fail";
            }
            catch(Exception ex)
            {
                reason = ex.Message;
            }

            await _smsRecordRepository.Create(new SmsRecord(
                parameters.PhoneNumbers,
                parameters.SignName,
                parameters.TemplateCode,
                JsonConvert.SerializeObject(parameters.TemplateParam),
                DateTime.Now,
                status,
                reason
                ));
        }
    }
}
