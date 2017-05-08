using System.Runtime.Serialization;

namespace QTestDTOs
{
    public class Automation
    {
        [DataContract]
        public class Host
        {
            [DataMember(EmitDefaultValue = false)]
            public string host_name { get; set; }

            [DataMember(EmitDefaultValue = false)]
            public string ip_address { get; set; }

            [DataMember(EmitDefaultValue = false)]   
            public string mac_address { get; set; }

            [DataMember(EmitDefaultValue = false)]
            public string host_guid { get; set; }
        }

        public class Agent
        {
            [DataMember(EmitDefaultValue = false)]
            public string name { get; set; }

            [DataMember(EmitDefaultValue = false)]
            public string framework { get; set; }

            [DataMember(EmitDefaultValue = false)]
            public string framework_id { get; set; }

            [DataMember(EmitDefaultValue = false)]
            public string agent_client_id { get; set; }

            [DataMember(EmitDefaultValue = false)]
            public bool active { get; set; }
        }


    }
}
