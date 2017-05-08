using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json.Linq;

namespace HttpClientFramework
{
    public class PostObject
    {
      
        public string Url{ get; set; }
        public HttpContent Content { get; set; }
        public List<KeyValuePair<string,string>> Body { get; set; }
        public string  CallType { get; set; }

        public PostObject(string url, JObject jObject, string callType)
        {
            this.Url = url;
            this.Content = new StringContent(jObject.ToString(),Encoding.UTF8, "application/json");
            this.CallType = callType;
        }


        public PostObject(string url, List<KeyValuePair<string,string>> body, string callType)
        {
            this.Url = url;
            this.Body = body;
            Content = new FormUrlEncodedContent(Body);
            this.CallType = callType;
        }

        public PostObject(string url,string callType)
        {
            this.Url = url;
            this.CallType = callType;

        }
    }
}