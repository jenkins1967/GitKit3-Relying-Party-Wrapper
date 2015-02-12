namespace GitKitClient.Requests
{
    public class DeleteAccountRequest : JsonSerializeable
    {
        public string LocalId { get; set; }
    }
}