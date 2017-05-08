using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Remoting;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace QTESTAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            QtHttpClient client = new QtHttpClient();
            Login login = new Login(client);
            if (login.GetNewToken())
            {
                client.SetAuthToken(login.Token);

                TestLog testLog = new TestLog(client);
                TestRun testRun = new TestRun(client);
                TestCase testCase = new TestCase(client);
                TestStep testStep = new TestStep(client);
                
                // Console.WriteLine(testLog.Create(4530414));
                // Console.ReadLine();
                // Console.WriteLine(testRun.GetByType(0,"root")); 
                // Console.WriteLine(testCase.Update(2631572));
                // Console.WriteLine(testCase.Create());

                // Console.WriteLine(testCase.)

                //Console.WriteLine(testStep.Get());

                using (TextWriter writer = File.CreateText("C:\\out.txt"))
                {
                   writer.WriteLine(testLog.Get());
                    writer.Write(writer.NewLine);
                }

                login.RevokeToken();
            }
            Console.WriteLine(login.Token.ApiResonseMessage);
            Console.ReadLine();
        }

        public static string GetAllProjects(HttpClient client)
        {
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/api/v3/projects").Result;

            return (response.Content.ReadAsStringAsync().Result);
        }
    }
}
