namespace GitKitClient.Responses
{
    public class VerifyAssertionResponse : BaseResponse<VerifyAssertionResponse>
    {
        public string FederatedId { get; set; }
        public string ProviderId { get; set; }
        public string LocalId { get; set; }
        public bool EmailRecycled { get; set; }
        public bool EmailVerified { get; set; }
        public string Email { get; set; }
        public string InputEmail { get; set; }
        public string OriginalEmail { get; set; }
        public string OauthRequestToken { get; set; }
        public string OauthScope { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string NickName { get; set; }
        public string DisplayName { get; set; }
        public string IdToken { get; set; }
        public string Action { get; set; }
        public string Language { get; set; }
        public string Timezone { get; set; }
        public string PhotoUrl { get; set; }
        public string DateOfBirth { get; set; }
        public string Context { get; set; }
        public string[] VerifiedProvider { get; set; }
        public bool NeedConfirmation { get; set; }
    }

    public class VerifyPasswordResponse : BaseResponse<VerifyPasswordResponse>
    {
        public string LocalId { get; set; }
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string IdToken { get; set; }
        public bool Registered { get; set; }

    }
}