namespace GitKitClient.Requests
{
    public class ResetPasswordRequest : JsonSerializeable
    {
        public string OobCode { get; set; }
        public string NewPassword { get; set; }
        public string OldPassword { get; set; }
        public string Email { get; set; }
    }
}