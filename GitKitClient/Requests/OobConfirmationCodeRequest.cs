using System;
using GitKitClient.Extensions;
using Newtonsoft.Json;

namespace GitKitClient.Requests
{
    public class OobConfirmationCodeRequest : JsonSerializeable
    {
        public string Kind { get { return "identitytoolkit#relyingparty"; } }

        public string RequestType { get; private set; }
        
        public string Email { get; set; }
        /// <summary>
        /// recaptcha challenge
        /// </summary>
        public string Challenge { get; set; }

        /// <summary>
        /// recaptcha response
        /// </summary>
        [JsonProperty("captchaResp")]
        public string CaptchaResponse { get; set; }

        public string UserIp { get; set; }
        /// <summary>
        /// New email if the code is for email change
        /// </summary>
        public string NewEmail { get; set; }

        /// <summary>
        /// Login token for email change
        /// </summary>
        public string IdToken { get; set; }

        public void SetRequestType(ConfirmationCodeRequestType requestType)
        {
            var name = Enum.GetName(typeof (ConfirmationCodeRequestType), requestType);
            RequestType = name.SplitAtCapsAndUpperCase('_');
        }


    }
}