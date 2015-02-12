using System.Collections.Specialized;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using GitKitClient.Requests;
using GitKitClient.Responses;
using Newtonsoft.Json;

namespace GitKitClient
{
    public interface IIdentityClient
    {
        string GetAccountInfoByEmail(string email);
    }

    public class IdentityClient
    {
        private readonly AccessToken _accessToken;
        private readonly string _serviceAccountEmail;
        private readonly RpcHelper _helper;

        public IdentityClient(AccessToken accessToken)
        {
            _accessToken = accessToken;
            _helper = new RpcHelper(accessToken, "https://www.googleapis.com/identitytoolkit/v3/relyingparty");
        }

        //public IdentityClient(string serviceAccountEmail, string serviceAccountKey, string serverApiKey, string apiUrl)
        //{
        //    _serviceAccountEmail = serviceAccountEmail;
        //    _helper = new RpcHelper(serviceAccountEmail, serviceAccountKey, serverApiKey, apiUrl);
        //}

        public string GetAccountInfoByEmail(string email)
        {
            var response = _helper.InvokeApi("getAccountinfo", new NameValueCollection()
            {
                {"email", email}
            });

            return response;
        }

        /// <summary>
        /// Batch download user accounts.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DownloadAccountResponse DownloadAccount(DownloadAccountRequest request)
        {
            var response = _helper.InvokeApi("downloadAccount", request);
            return JsonConvert.DeserializeObject<DownloadAccountResponse>(response);            
        }

        /// <summary>
        /// Creates the URI used by the IdP to authenticate the user.
        /// </summary>
        /// <returns></returns>
        public CreateAuthUriResponse CreateAuthUri(CreateAuthUriRequest request)
        {
            var response = _helper.InvokeApi("createAuthUri", request);
            return JsonConvert.DeserializeObject<CreateAuthUriResponse>(response);
        }

        /// <summary>
        /// Delete user account
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DeleteAccountResponse DeleteAccount(DeleteAccountRequest request)
        {
            var response = _helper.InvokeApi("deleteAccount", request);
            return JsonConvert.DeserializeObject<DeleteAccountResponse>(response);
        }

        /// <summary>
        /// Returns the account info of an authenticated user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public AccountInfoResponse GetAccountInfo(AccountInfoRequest request)
        {
            var response = _helper.InvokeApi("getAccountInfo", request);
            return JsonConvert.DeserializeObject<AccountInfoResponse>(response);
        }

        public OobConfirmationCodeResponse GetOobConfirmationCode(OobConfirmationCodeRequest request)
        {
            var response = _helper.InvokeApi("getOobConfirmationCode", request);
            return JsonConvert.DeserializeObject<OobConfirmationCodeResponse>(response);
        }

        public ResetPasswordResponse ResetPassword(ResetPasswordRequest request)
        {
            var response = _helper.InvokeApi("resetPassword", request);
            return JsonConvert.DeserializeObject<ResetPasswordResponse>(response);
        }

        public SetAccountInfoResponse SetAccountInfo(SetAccountInfoRequest request)
        {
            var response = _helper.InvokeApi("setAccountInfo", request);
            return JsonConvert.DeserializeObject<SetAccountInfoResponse>(response);
        }

        public string GetPublicKeys(string apiKey)
        {
            var args = new NameValueCollection()
            {
                {"key", apiKey}
            };
            return _helper.InvokeGetApi("publickeys", args);
        }
    }


}
