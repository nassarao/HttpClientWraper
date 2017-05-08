using System;
using System.Runtime.Serialization;

namespace QTestDTOs
{
    [DataContract]
    public class Token
    {
        [DataMember(EmitDefaultValue = false)]
        public string access_token { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string token_type { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int expires_in { get; set; } //in MS?

        [DataMember(EmitDefaultValue = false)]
        public string scope { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Int64 expiration { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string api_response_message { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int validityInMilliseconds { get; set; }

    }
}