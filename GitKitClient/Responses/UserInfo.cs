namespace GitKitClient.Responses
{
    public class UserInfo
    {
        public string LocalId { get; set; }
        public string Email { get; set; }
        public bool EmailVerified { get; set; }
        public string DisplayName { get; set; }
        public string PhotoUrl { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] Salt { get; set; }
        public int Version { get; set; }
        public double PasswordUpdatedAt { get; set; }

        public ProviderUserInfo[] ProviderUserInfo { get; set; } 
    }
}