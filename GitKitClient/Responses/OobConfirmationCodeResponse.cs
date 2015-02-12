namespace GitKitClient.Responses
{
    public class OobConfirmationCodeResponse : BaseResponse<OobConfirmationCodeResponse>
    {
        public string OobCode { get; set; }
    }
}