using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using Google.Apis.Auth.OAuth2;

namespace GitKitClient
{
    public class ServerAuthorization
    {
        public ServerAuthorization(string serverEmail, FileInfo keyFile)
        {            
            var serviceAccountEmail = serverEmail;

            var certificate = new X509Certificate2(keyFile.FullName, "notasecret", X509KeyStorageFlags.Exportable);

            var credential = new ServiceAccountCredential(
                new ServiceAccountCredential.Initializer(serviceAccountEmail)
                {
                    Scopes = new[] { "https://www.googleapis.com/auth/identitytoolkit" }
                }.FromCertificate(certificate));

            var cancellationToken = new CancellationToken();
            var task = credential.RequestAccessTokenAsync(cancellationToken);
            task.Wait();

            var seconds = credential.Token.ExpiresInSeconds.Value;
            AccessToken = new AccessToken(credential.Token.AccessToken, DateTime.Now.ToUniversalTime().AddSeconds(seconds));
        }

        public AccessToken AccessToken { get; set; }
        
    }
}