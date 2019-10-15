using Myx.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Myx.Message.Core.Entities
{
    public class SmsRecord :MyxBaseEntity<long>
    {
        public SmsRecord()
        {
        }

        public SmsRecord(string phoneNumbers, string signName, string templateCode, string templateParam, DateTime sendTime, string status, string reason = "")
        {
            PhoneNumbers = phoneNumbers;
            SignName = signName;
            TemplateCode = templateCode;
            TemplateParam = templateParam;
            SendTime = sendTime;
            Status = status;
            Reason = reason;
        }

        public string PhoneNumbers { get; set; }

        public string SignName { get; set; }

        public string TemplateCode { get; set; }

        public string TemplateParam { get; set; }

        public DateTime SendTime { get; set; }

        public string Status { get; set; }
    
        public string Reason { get; set; }    
    }
}
