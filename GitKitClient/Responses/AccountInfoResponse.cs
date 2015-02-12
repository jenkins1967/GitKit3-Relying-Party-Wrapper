namespace GitKitClient.Responses
{
    public class AccountInfoResponse : BaseResponse<AccountInfoResponse>
    {
        public UserInfo[] Users { get; set; }
    }
}