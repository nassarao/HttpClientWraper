using System.Runtime.Serialization;

namespace QTestDTOs
{
    [DataContract]
    public class Attachment
    {
        [DataMember(EmitDefaultValue = false)]

        public string name { get; set; }
        [DataMember(EmitDefaultValue = false)]

        public string content_type { get; set; }

        [DataMember(EmitDefaultValue = false)]

        /// <summary>
        /// Base64Encode
        /// </summary>
        public string data { get; set; }
        [DataMember(EmitDefaultValue = false)]

        public string web_url { get; set; }
    }
}
