using System.Runtime.Serialization;

namespace QTestDTOs
{
    [DataContract]
    public class ExecutionStatus
    {
        [DataMember(EmitDefaultValue = false)]
        public int id { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }

    }
}
