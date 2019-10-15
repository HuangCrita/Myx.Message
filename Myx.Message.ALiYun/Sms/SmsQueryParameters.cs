﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Myx.Message.ALiYun.Sms
{
    public class SmsQueryParameters
    {
        public SmsQueryParameters()
        {
        }

        public SmsQueryParameters(string phoneNumbers, string signName, string templateCode, Dictionary<string, string> templateParam)
        {
            PhoneNumbers = phoneNumbers;
            SignName = signName;
            TemplateCode = templateCode;
            TemplateParam = templateParam;
        }

        public string PhoneNumbers { get; set; }
        public string SignName { get; set; }
        public string TemplateCode { get; set; }
        public Dictionary<string,string> TemplateParam { get; set; }
    }
}
