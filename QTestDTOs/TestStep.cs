using System.Runtime.Serialization;

namespace QTestDTOs
{
    [DataContract]
    public class TestStep
    {
        [DataMember(EmitDefaultValue = false)]
        public int id{ get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string description { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string expected { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public int order { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string attachments { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public int group { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string called_test_case_name { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public int root_called_test_case_id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string web_url { get; set; }
    }
}
