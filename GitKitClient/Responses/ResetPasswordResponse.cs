namespace GitKitClient.Responses
{
    public class ResetPasswordResponse : JsonDeserializeable<ResetPasswordResponse>
    {
        public string Email { get; set; }
    }
}