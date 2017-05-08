using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace HttpClientFramework
{
    public class QtHttpClient : HttpClient
    {

        public QtHttpClient(string baseAddress)
        {
            BaseAddress = new Uri(baseAddress);

        }

        /// <summary>
        /// Makes API Call and returns the object in c#
        /// </summary>
        /// <typeparam name="T">Type of object you expect to be reutrned</typeparam>
        /// <param name="pObj">PostObject you wish to call</param>
        /// <returns>Object you declared as return type</returns>
        public async Task<T> Call<T>(PostObject pObj)
        {
            pObj.Url = BaseAddress + pObj.Url;

            switch (pObj.CallType.ToUpper())
            {
                case "POST":
                    using (HttpResponseMessage response = PostAsync(pObj.Url, pObj.Content).Result)
                        if (response.IsSuccessStatusCode)
                        {
                            return DeserializeToObject<T>(response);
                        }
                        else
                            return default(T);

                case "DELETE":
                    using (HttpResponseMessage response = DeleteAsync(pObj.Url).Result)
                        if (response.IsSuccessStatusCode)
                            return DeserializeToObject<T>(response);
                        else
                            return default(T);

                case "PUT":
                    using (HttpResponseMessage response = PutAsync(pObj.Url, pObj.Content).Result)
                        if (response.IsSuccessStatusCode)
                            return DeserializeToObject<T>(response);
                        else
                            return default(T);

                case "GET":
                    using (HttpResponseMessage response = GetAsync(pObj.Url).Result)
                        if (response.IsSuccessStatusCode)
                            return DeserializeToObject<T>(response);
                        else
                            return default(T);

                default:
                    throw new ArgumentException("Argument does not match a usable Http request");
            };
        }

        public HttpResponseMessage Call(PostObject pObj)
        {
            pObj.Url = BaseAddress + pObj.Url;

            switch (pObj.CallType.ToUpper())
            {
                case "POST":
                    return PostAsync(pObj.Url, pObj.Content).Result;


                case "DELETE":
                    return DeleteAsync(pObj.Url).Result;

                case "PUT":
                    return PutAsync(pObj.Url, pObj.Content).Result;


                case "GET":
                    return GetAsync(pObj.Url).Result;

                default:
                    throw new ArgumentException("Argument does not match a usable Http request");
            }


        }

        public static T DeserializeToObject<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
                var obj = Activator.CreateInstance(typeof(T));

                obj = ser.ReadObject(response.Content.ReadAsStreamAsync().Result);

                return (T)obj;
            }
            throw new NullReferenceException();
        }
        /// <summary>
        /// Data should be json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static T DeserializeStringToObject<T>(string data)
        {

            JavaScriptSerializer oJS = new JavaScriptSerializer();

            var obj = Activator.CreateInstance(typeof(T));
            obj = oJS.Deserialize<T>(data);
            return (T)obj;

        }

        public static JObject Serialize(object obj)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            using (StreamReader reader = new StreamReader(memoryStream))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
                serializer.WriteObject(memoryStream, obj);
                memoryStream.Position = 0;
                string json = reader.ReadToEnd();
                return JObject.Parse(json);
            }
        }

        #region HttpRequest Methods
        private async Task<HttpResponseMessage> Delete(PostObject pObj)
        {
            return await DeleteAsync(pObj.Url);
        }
        private async Task<HttpResponseMessage> Put(PostObject pObj)
        {
            return await PutAsync(pObj.Url, pObj.Content);
        }
        private Task<HttpResponseMessage> Post(PostObject pObj)
        {
            return PostAsync(pObj.Url, pObj.Content);
        }
        private Task<HttpResponseMessage> Get(PostObject pObj)
        {
            return GetAsync(pObj.Url);
        }
        #endregion


        private bool IsValid(HttpResponseMessage response)
        {
            return response.IsSuccessStatusCode;
        }

        public static string BasicEncode(string toEncode)
        {
            // ":" is necessary because there is no password...
            var byteArray = Encoding.Default.GetBytes(toEncode + ":");
            string encoded =
                System.Convert.ToBase64String(byteArray);
            return encoded;
        }

    }
}
