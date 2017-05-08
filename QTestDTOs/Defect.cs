using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QTestDTOs
{
    [DataContract]
    public class Defect
    {
        [DataMember(EmitDefaultValue =false)]
        public int id { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<Property> properties { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<Attachment> attachments { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string label { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public bool required { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public bool constrained { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int order { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public bool multiple { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int data_type { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public bool searchable { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public bool free_text_search { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string search_key { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public bool system_field { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string original_name { get; set;}

        [DataMember(EmitDefaultValue = false)]
        public bool is_active { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<Link> links { get; set; }

    }
}
