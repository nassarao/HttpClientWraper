using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QTestDTOs
{
    [DataContract]
    public class Project
    {


        [DataMember(EmitDefaultValue = false)]
        public int id { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string description { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string start_date {get; set;}

        [DataMember(EmitDefaultValue = false)]
        public string end_date { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<object> defect_tracking_systems { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<Link> links { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public int x_explorer_access_level { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public int status_id { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string date_format { get; set; }


        public bool sample { get; set; }
        public string web_url { get; set; }
        public KeyValuePair<int, string> key_value { get { return new KeyValuePair<int, string>(id, name); } }


        override
        public string ToString()
        {
            return name;
        }
    }
}
