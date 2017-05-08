using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QTestDTOs
{
    [DataContract]
    public class Module
    {

        [DataMember(EmitDefaultValue = false)]
        public int id { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string description { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string web_url { get; set; }

        public KeyValuePair<int, string> keyvalue { get { return new KeyValuePair<int, string>(id, name); } }
    }
}
