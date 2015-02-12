namespace GitKitClient.Requests
{
    public class VerifyPasswordRequest : JsonSerializeable
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PendingIdToken { get; set; }
        public string CaptchaChallenge { get; set; }
        public string CaptchaResponse { get; set; }
    }
}