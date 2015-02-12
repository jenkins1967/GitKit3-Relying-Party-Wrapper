namespace GitKitClient.Responses
{
    public class SetAccountInfoResponse : BaseResponse<SetAccountInfoResponse>
    {
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public ProviderUserInfo[] ProviderUserInfo { get; set; }
        public string IdToken { get; set; }
    }
}