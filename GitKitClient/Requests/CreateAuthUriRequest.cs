using Newtonsoft.Json;

namespace GitKitClient.Requests
{
    public class CreateAuthUriRequest:JsonSerializeable
    {
        public string Identifier { get; set; }
        public string ContinueUri { get; set; }
        [JsonProperty("openidRealm")]
        public string OpenIdRealm { get; set; }
        public string ProviderId { get; set; }
        public string ClientId { get; set; }
        public string Context { get; set; }
    }
}
