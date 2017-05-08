
using HttpClientFramework;
using QTestAPI;
using QTestAPIMethods;
using QTestDTOs;
using System;
using System.Net.Http;


namespace ApiCallTester
{
    class Program
    {
        static void Main(string[] args)
        {
             test.apiCall();
            Console.ReadLine();
        }


    }

    public static class test
    {
      
        public static void apiCall()
        {

            using (QtHttpClient client = new QtHttpClient("https://intelligrated.qtestnet.com/"))
            {
                string username = "andrew.callaway@intelligrated.com";
                string password = "Imincontrol7";
                Login qtestLogin = new Login(username, password);

                Token tok = LoginAPI.GetNewToken(qtestLogin, client, false);
                LoginAPI.SetAuthToken(tok, client);

                // e.context.Logger.Info("QTest Connection Successful");
                try
                {
                    HttpResponseMessage respons = client.Call(TestStepAPI.GetAll(26662, 8012783));
                    string data = respons.Content.ReadAsStringAsync().Result;

                }
                catch (Exception exception)
                {
                    Console.WriteLine("Exception {0}", exception);
                }


            }
        } 
    }
}
