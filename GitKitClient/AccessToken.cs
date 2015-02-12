using System;

namespace GitKitClient
{
    public class AccessToken
    {
        public AccessToken(string token, DateTime expiresOnUtc)
        {
            Token = token;
            ExpiresOnUtc = expiresOnUtc;
        }
        public string Token { get; set; }

        public DateTime ExpiresOnUtc { get; set; }

        public bool IsExpired
        {
            get { return DateTime.Now.ToUniversalTime() > ExpiresOnUtc; }
        }
    }
}