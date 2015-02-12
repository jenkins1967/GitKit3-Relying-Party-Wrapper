namespace GitKitClient.Requests
{
    public class AccountInfoRequest : JsonSerializeable
    {
        public string IdToken { get; set; }
        public string[] LocalId { get; set; }
        public string[] Email { get; set; }
    }
}