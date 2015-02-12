namespace GitKitClient.Requests
{
    public class SetAccountInfoRequest : JsonSerializeable
    {
        public string IdToken { get; set; }
        public string LocalId { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; } 
        public string[] Provider { get; set; }
        public string OobCode { get; set; }
        public bool EmailVerified { get; set; }
        public bool UpgradeToFederatedLogin { get; set; }
        public string CaptchaChallenge { get; set; }
        public string CaptchaResponse { get; set; }
    }
}