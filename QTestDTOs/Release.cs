using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QTestDTOs
{
    [DataContract]
    public class Release
    {

        [DataMember(EmitDefaultValue = false)]
        public List<Link> links { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int id { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int order { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string pid { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<Property> properties { get; set; }

    }
}
