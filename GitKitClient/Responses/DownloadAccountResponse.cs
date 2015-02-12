namespace GitKitClient.Responses
{
    public class DownloadAccountResponse : BaseResponse<DownloadAccountResponse>
    {
        public UserInfo[] Users { get; set; }
        public string NextPageToken { get; set; }
    }
}