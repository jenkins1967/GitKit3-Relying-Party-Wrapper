using System;
using System.IO;
using GitKitClient;

namespace GitKitTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            var email = "117279041939-mtbsdil9fjr4tkqo1qgkmtjs7s8ircdn@developer.gserviceaccount.com";
            var key =
                "nMIICeAIBADANBgkqhkiG9w0BAQEFAASCAmIwggJeAgEAAoGBAM05zi1KVxDfS+c0\nrh0VEu8iuhap6F3cygrJGyzvkrHewBAZ4Nfr3AnnyrvpJF0OtZp1E+bCuZG0ufvf\nAtYb6ImuWI5iAIBst0FgrfN1OOOkETdCsN7kQ9z7IN8Vis8I49Hli5feN2emSvti\n5fL053oRQcumTHYvbywRZQIy6+4HAgMBAAECgYBj4kOH5Yu0qYmO0SQBAZXCj/tU\nNoPi0yf+0dyJJV0XdxuxenblgGUK6SbSCGnrZNJch6kVAidBVF3EycjenpyxLugT\n2B5e+YYB6ud3dxvXnklfaDMfiJ3xsE799Iq+BqyPJLHmNcQB4exQM0VuSlMhndTc\ngexKZJYJFqh8l0ip8QJBAOgX4X3twEYlVV3APkOKrDt2xywxm6M2zaTuMEdPRpoX\nROBQD/JOgZawVwUWcHFhrVNMmlrHlbAFc8rt3yjBog8CQQDiXXMxDii4V+ZOR660\nXuhH5/Y6IKgFQTWV9z3MLixjo2+cm4EuuRuPzJPqtQEG5OX5vQZqKc4m0gSkvX9S\nlIyJAkEAqPB5Gojs5CJYuR0uNUvDgqU65VhWyb8igWM/kSiLY658XCrq8J1khqNl\nNDbZMi6/U1r3IA0XUEEnwBbV0Xzg0QJBAIg/IxRFp3C9R1uafacG8NxG28dE3Jy9\nERnAhKuepw0Z1BX46xpKRDKbOfStGX8iyuE0SuYfX3uyMSVPAZGc47ECQQDensJv\nIPFnYGrrHLYrOv4JCPYi0oPJ1liX9F8ESZOXISn5LEqXWtxnCyZhOUQf9l+249yy\no917TqkshWGRGcVJ";
            var id = "AIzaSyApzbVv-vBHBshoZyRfh10yY7kS80kj9Y4";

            var authorization = new ServerAuthorization(email, new FileInfo("key.p12"));

            var client = new IdentityClient(authorization.AccessToken);

            var result = client.DownloadAccount();
            Console.ReadKey();
        }
    }
}
