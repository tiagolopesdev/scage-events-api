using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.YouTube.v3;

namespace SCAGEEvents.Api.Build
{
    public static class ConnectionGloogleService
    {
        public static async Task<BaseClientService.Initializer> ConnectGoogle()
        {
            string[] scopes = {
                YouTubeService.Scope.Youtube,
                //"https://www.googleapis.com/auth/calendar",
                //DriveService.Scope.Drive
            };

            UserCredential credential;

            using (var stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "Credential", "credential.json"), FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.FromStream(stream).Secrets,
                        scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)
                );
            }

            return new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Pascom System Scale"
            };
        }
    }
}
