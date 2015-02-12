using System.Collections.Specialized;
using System.Net;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace GitKitClient
{
    internal class RpcHelper
    {
        private readonly AccessToken _token;
        //private readonly string _serviceAccountEmail;
        //private readonly string _serviceAccountKey;
        //private readonly string _serverApiKey;
        private readonly string _googleapiUrl;
        //private const string TOKEN_ENDPOINT = "https://accounts.google.com/o/oauth2/token";
        //private const int MAX_TOKEN_LIFETIME_SECS = 3600; // 1 hour in seconds
        //private const string SCOPE = "https://www.googleapis.com/auth/identitytoolkit";
        //private const string GRANT_TYPE = "urn:ietf:params:oauth:grant-type:jwt-bearer";

        public RpcHelper(AccessToken token, string apiUrl)
        {
            _token = token;
            _googleapiUrl = apiUrl.EndsWith("/") ? apiUrl : apiUrl + "/";
        }

        //public RpcHelper(string serviceAccountEmail, string serviceAccountKey, string serverApiKey, string googleapiUrl)
        //{
        //    _serviceAccountEmail = serviceAccountEmail;
        //    _serviceAccountKey = serviceAccountKey;
        //    _serverApiKey = serverApiKey;
            
        //}

       

        //      def GetAccountInfoByEmail(self, email):
  //  """Gets account info of an email.

  //  Args:
  //    email: string, user email.

  //  Returns:
  //    A dict of user attribute.
  //  """
  //  response = self._InvokeGitkitApi('getAccountInfo', {'email': [email]})
  //  # pylint does not recognize the return type of simplejson.loads
  //  # pylint: disable=maybe-no-member
  //  return response['users'][0]

  //def GetAccountInfoById(self, user_id):
  //  """Gets account info of a user id.

  //  Args:
  //    user_id: string, user id.

  //  Returns:
  //    A dict of user attribute.
  //  """
  //  response = self._InvokeGitkitApi('getAccountInfo', {'localId': [user_id]})
  //  # pylint does not recognize the return type of simplejson.loads
  //  # pylint: disable=maybe-no-member
  //  return response['users'][0]

  //def GetOobCode(self, request):
  //  """Gets out-of-band code requested by user.

  //  Args:
  //    request: dict, the request details.

  //  Returns:
  //    Out of band code string.
  //  """
  //  response = self._InvokeGitkitApi('getOobConfirmationCode', request)
  //  # pylint does not recognize the return type of simplejson.loads
  //  # pylint: disable=maybe-no-member
  //  return response.get('oobCode', None)

  //def DownloadAccount(self, next_page_token=None, max_results=None):
  //  """Downloads multiple accounts from Gitkit server.

  //  Args:
  //    next_page_token: string, pagination token.
  //    max_results: pagination size.

  //  Returns:
  //    An array of accounts.
  //  """
  //  param = {}
  //  if next_page_token:
  //    param['nextPageToken'] = next_page_token
  //  if max_results:
  //    param['maxResults'] = max_results
  //  response = self._InvokeGitkitApi('downloadAccount', param)
  //  # pylint does not recognize the return type of simplejson.loads
  //  # pylint: disable=maybe-no-member
  //  return response.get('nextPageToken', None), response.get('users', {})

  //def UploadAccount(self, hash_algorithm, hash_key, accounts):
  //  """Uploads multiple accounts to Gitkit server.

  //  Args:
  //    hash_algorithm: string, algorithm to hash password.
  //    hash_key: string, base64-encoded key of the algorithm.
  //    accounts: array of accounts to be uploaded.

  //  Returns:
  //    Response of the API.
  //  """
  //  param = {
  //      'hashAlgorithm': hash_algorithm,
  //      'signerKey': hash_key,
  //      'users': accounts
  //  }
  //  # pylint does not recognize the return type of simplejson.loads
  //  # pylint: disable=maybe-no-member
  //  return self._InvokeGitkitApi('uploadAccount', param)

  //def DeleteAccount(self, local_id):
  //  """Deletes an account.

  //  Args:
  //    local_id: string, user id to be deleted.

  //  Returns:
  //    API response.
  //  """
  //  # pylint does not recognize the return type of simplejson.loads
  //  # pylint: disable=maybe-no-member
  //  return self._InvokeGitkitApi('deleteAccount', {'localId': local_id})

  //def GetPublicCert(self):
  //  """Download Gitkit public cert.

  //  Returns:
  //    dict of public certs.
  //  """

  //  if self.server_api_key:
  //    cert_url = self.google_api_url + 'publicKeys?key=' + self.server_api_key
  //    headers = None
  //  else:
  //    cert_url = self.google_api_url + 'publicKeys'
  //    headers = {'Authorization': 'Bearer ' + self._GetAccessToken()}

  //  resp, content = self.http.request(cert_url, headers=headers)
  //  if resp.status == 200:
  //    return simplejson.loads(content)
  //  else:
  //    raise errors.GitkitServerError('Error response for cert url: %s' %
  //                                   content)


        public string InvokeGetApi(string method, NameValueCollection args)
        {
            var url = _googleapiUrl + method;
            
            using (var client = new WebClient())
            {
                client.QueryString = args;
                return client.DownloadString(url);
            }
        }
        public string InvokeApi(string method, JsonSerializeable args, bool needsServiceAccount = true)
        {
            return InvokeApi(method, args.ToJson(), needsServiceAccount);
        }
        public string InvokeApi(string method, string args, bool needsServiceAccount = true)
        {
            var url = _googleapiUrl + method;
            var data = JsonConvert.SerializeObject(args);
            using (var client = new WebClient())
            {
                client.Headers.Add("Content-type", "application/json");
                if (needsServiceAccount)
                {
                    client.Headers.Add("Authorization", "Bearer " + _token.Token);
                }
                
                var response = client.UploadString(url, data);
                return response;
            }
        }

        //def _InvokeGitkitApi(self, method, params, need_service_account=True):
        //  """Invokes Gitkit API, with optional access token for service account.

        //  Args:
        //    method: string, the api method name.
        //    params: dict of optional parameters for the API.
        //    need_service_account: false if service account is not needed.

        //  Raises:
        //    GitkitClientError: if the request is bad.
        //    GitkitServerError: if Gitkit can not handle the request.

        //  Returns:
        //    API response as dict.
        //  """
        //  body = simplejson.dumps(params)
        //  req = urllib2.Request(self.google_api_url + method)
        //  req.add_header('Content-type', 'application/json')
        //  if need_service_account:
        //    req.add_header('Authorization', 'Bearer ' + self._GetAccessToken())
        //  try:
        //    raw_response = urllib2.urlopen(req, body).read()
        //  except urllib2.HTTPError, err:
        //    if err.code == 400:
        //      raw_response = err.read()
        //    else:
        //      raise
        //  return self._CheckGitkitError(raw_response)

        //private string GetAccessToken()
        //{
        //    var body = BuildAccessTokenRequest();

        //    using (var client = new WebClient())
        //    {
        //        var response = client.UploadValues(TOKEN_ENDPOINT, new NameValueCollection()
        //        {
        //            {"assertion", GenerateAssertion()},
        //            {"grant_type", GRANT_TYPE}
        //        });

        //        return Encoding.UTF8.GetString(response);
        //    }
        //}

        //def _GetAccessToken(self):
  //  """Gets oauth2 access token for Gitkit API using service account.

  //  Returns:
  //    string, oauth2 access token.
  //  """
  //  body = urllib.urlencode({
  //      'assertion': self._GenerateAssertion(),
  //      'grant_type': 'urn:ietf:params:oauth:grant-type:jwt-bearer',
  //  })
  //  req = urllib2.Request(RpcHelper.TOKEN_ENDPOINT)
  //  req.add_header('Content-type', 'application/x-www-form-urlencoded')
  //  raw_response = urllib2.urlopen(req, body)
  //  return simplejson.loads(raw_response.read())['access_token']
        //private string BuildAccessTokenRequest()
        //{
        //    var token = new AcessTokenRequest
        //    {
        //        Assertion = GenerateAssertion(),
        //        GrantType = GRANT_TYPE
        //    };
        //    return token.ToJson();
        //}
        //private string GenerateAssertion()
        //{
        //    var now = DateTime.Now.Subtract(new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
        //    var payload = new Payload
        //    {
        //        Audience = TOKEN_ENDPOINT,
        //        Scope = SCOPE,
        //        Initialized = now,
        //        Expires = now + MAX_TOKEN_LIFETIME_SECS,
        //        Issuer = _serviceAccountEmail
        //    };

        //    return JsonWebToken.Encode(payload, _serviceAccountKey, JwtHashAlgorithm.HS256);
        //}
  //def _GenerateAssertion(self):
  //  """Generates the signed assertion that will be used in the request.

  //  Returns:
  //    string, signed Json Web Token (JWT) assertion.
  //  """
  //  now = long(time.time())
  //  payload = {
  //      'aud': RpcHelper.TOKEN_ENDPOINT,
  //      'scope': 'https://www.googleapis.com/auth/identitytoolkit',
  //      'iat': now,
  //      'exp': now + RpcHelper.MAX_TOKEN_LIFETIME_SECS,
  //      'iss': self.service_account_email
  //  }
  //  return crypt.make_signed_jwt(
  //      crypt.Signer.from_string(self.service_account_key),
  //      payload)

  ////def _CheckGitkitError(self, raw_response):
  //      """Raises error if API invocation failed.

  //  Args:
  //    raw_response: string, the http response.

  //  Raises:
  //    GitkitClientError: if the error code is 4xx.
  //    GitkitServerError: if the response if malformed.

  //  Returns:
  //    Successful response as dict.
  //  """
  //  try:
  //    response = simplejson.loads(raw_response)
  //    if 'error' not in response:
  //      return response
  //    else:
  //      error = response['error']
  //      if 'code' in error:
  //        code = error['code']
  //        if str(code).startswith('4'):
  //          raise errors.GitkitClientError(error['message'])
  //        else:
  //          raise errors.GitkitServerError(error['message'])
  //  except simplejson.JSONDecodeError:
  //    pass
  //  raise errors.GitkitServerError('null error code from Gitkit server')
    }

    internal class AcessTokenRequest:JsonSerializeable
    {
        [JsonProperty("assertion")]
        public string Assertion { get; set; }
        [JsonProperty("grant_type")]
        public string GrantType { get; set; }
    }

    internal class Payload : JsonSerializeable
    {
        [JsonProperty("aud")]
        public string Audience { get; set; }

        [JsonProperty("scope")]
        public string Scope { get; set; }

        [JsonProperty("exp")]
        public double Expires { get; set; }

        [JsonProperty("iat")]
        public double Initialized { get; set; }

        [JsonProperty("iss")]
        public string Issuer { get; set; }
        
    }
}
