namespace GitKitClient.Requests
{
    public class DownloadAccountRequest : JsonSerializeable
    {
        public DownloadAccountRequest()
        {
            MaxResults = 40;
        }
        public string NextPageToken { get; set; }
        public int MaxResults { get; set; }
    }
}