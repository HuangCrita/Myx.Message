using System;
using System.Collections.Generic;
using System.Text;

namespace Myx.Message.Sdk
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
        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNumbers { get; set; }
        /// <summary>
        /// 签名
        /// </summary>
        public string SignName { get; set; }
        /// <summary>
        /// 短信模板编号
        /// </summary>
        public string TemplateCode { get; set; }
        /// <summary>
        /// 模板参数
        /// </summary>
        public Dictionary<string, string> TemplateParam { get; set; }
    }
}
