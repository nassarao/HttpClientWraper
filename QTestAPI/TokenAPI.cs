using HttpClientFramework;
using QTestDTOs;
using System.Collections.Generic;
using System.Configuration;

namespace QTestAPIMethods
{
    public static class TokenAPI
    {
        public static string url { get; set; }

        public static Token GetTokenFromFile()
        {
            Token token = new Token();
            token.access_token = System.IO.File.ReadAllText(ConfigurationManager.AppSettings["QTTokenPath"]);

            return token;
        }

        public static void WriteTokenToFile(Token token)
        {
            System.IO.File.WriteAllText(ConfigurationManager.AppSettings["QTTokenPath"], token.access_token);
        }

        public static PostObject GetNewToken(Login login)
        {
            //POST "oauth/token"
            url = "oauth/token";

            //Body data to pass
            List<KeyValuePair<string, string>> body = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("grant_type", login.GrantType),
                    new KeyValuePair<string, string>("username", login.UserName),
                    new KeyValuePair<string, string>("password", login.Password),
                };


            return new PostObject(url, body, "POST");
        }

        public static PostObject RevokeToken()
        {
            //POST /oauth/revoke
            url = "oauth/revoke";
            return new PostObject(url, "POST");
        }

        public static PostObject GetStatus()
        {
            //GET /oauth/status
            url = "oauth/status";

            return new PostObject(url, "GET");
        }


    }
}
