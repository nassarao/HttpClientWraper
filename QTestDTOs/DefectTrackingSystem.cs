using System.Runtime.Serialization;

namespace QTestDTOs
{
    [DataContract]
    public class DefectTrackingSystem
    {
        [DataMember(EmitDefaultValue = false)]
        public int id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string url { get; set; }

        /// <summary>
        /// Indicate qtest is using this connection or not
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public bool active { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string connection_name { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string system_name { get; set; }
    }
}
