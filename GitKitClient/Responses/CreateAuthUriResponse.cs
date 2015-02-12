namespace GitKitClient.Responses
{
    public class CreateAuthUriResponse:BaseResponse<CreateAuthUriResponse>
    {        
        public string AuthUri { get; set; }
        public string ProviderId { get; set; }
        public bool Registered { get; set; }
        public bool ForExistingProvider { get; set; }
    }
}
