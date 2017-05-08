using HttpClientFramework;
using Newtonsoft.Json.Linq;
using QTestDTOs;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;

namespace QTestAPIMethods
{
    public static class LoginAPI 
    {
        public static string url { get; set; }

        public static Login GetLoginInformation()
        {
            Login login = new Login();
            //Todo: Get an API USER / this in config file or appstart?
            login.GrantType = ConfigurationManager.AppSettings["QTGrant_Type"];
            login.UserName = ConfigurationManager.AppSettings["QTUsername"];
            login.Password = ConfigurationManager.AppSettings["QTPassword"];

            return login;
        }

        public static bool InitializeClient(QtHttpClient client)
        {
            SetAuthToken(TokenAPI.GetTokenFromFile(),client);

            HttpResponseMessage verifyTokenResponse =  client.Call(TokenAPI.GetStatus());

            if (verifyTokenResponse.IsSuccessStatusCode)
                return true;

            else
                return GetNewToken(GetLoginInformation(), client, true) != null;

            
        }

        public static Token GetNewToken(Login login,QtHttpClient client, bool WriteToFileOnServer)
        {
           //TODO: Error checking for failing to get token
            SetClientLoginHeader(login, client);
            HttpResponseMessage response  = client.Call(TokenAPI.GetNewToken(login));
            if (response.IsSuccessStatusCode)
            {
                Token newToken = QtHttpClient.DeserializeToObject<Token>(response);

                SetAuthToken(newToken, client);
                if (WriteToFileOnServer)
                    TokenAPI.WriteTokenToFile(newToken);

                return newToken;
            }
            else
            {
                var responseBody = response.Content.ReadAsStringAsync().Result;
                var JResponse = JObject.Parse(responseBody);
                var message = "Login Failed: " + JResponse["error_description"].Value<string>();
                
                throw new System.Exception(message ?? "Login failed, unable to parse reason: " + responseBody);
            }
            
        }

        public static void SetAuthToken(Token token, QtHttpClient client)
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authorization", "bearer " + token.access_token);
        }

        public static void SetClientLoginHeader(Login login, QtHttpClient client)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", QtHttpClient.BasicEncode(login.UserName));

        }

    }
}
