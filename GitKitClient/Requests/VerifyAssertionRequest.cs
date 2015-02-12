namespace GitKitClient.Requests
{
    public class VerifyAssertionRequest : JsonSerializeable
    {
        public string RequestUri { get; set; }
        public string PostBody { get; set; }
        public string PendingIdToken { get; set; }
    }
}