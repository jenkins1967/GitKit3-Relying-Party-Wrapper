using GitKitClient.Responses;

namespace GitKitClient.Requests
{
    public class UploadAccountRequest : JsonSerializeable
    {
        public UserInfo[] Users { get; set; }

        public string HashAlgorithm { get; set; }
        public byte[] SignerKey { get; set; }
        public byte[] SaltSeparator { get; set; }
        public int Rounds { get; set; }
        public int MemoryCost { get; set; }
        
    }
}