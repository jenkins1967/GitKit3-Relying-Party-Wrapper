namespace GitKitClient.Responses
{
    public class UploadAccountResponse : BaseResponse<UploadAccountResponse>
    {
        public Error[] Error { get; set; }
    }
}