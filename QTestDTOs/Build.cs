using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QTestDTOs
{
    [DataContract]
    public class Build
    {
        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<Property> properties { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public Release release { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int order { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string pid { get; set; }

    }
}
