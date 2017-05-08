using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QTestDTOs
{
    [DataContract]
    public class TestRun 
    {
        [DataMember(EmitDefaultValue = false)]
		public int id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public double test_case_version_id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public int run_order { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string web_url { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string status { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string note { get; set; }
        [DataMember(EmitDefaultValue = false)]
 
        public DateTime start_date { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime end_date { get; set; }
        [DataMember(EmitDefaultValue = false)]
     
        public TestCase test_case { get; set; }
        //[DataMember(EmitDefaultValue = false)]
        //public KeyValuePair<int, string> key_value { get { return new KeyValuePair<int, string>(id, name); } }


        [DataMember(EmitDefaultValue = false)]

        public int creator_id{ get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string Tester { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string Log { get; set; }

        [DataMember(EmitDefaultValue = false)]

        public string pid { get; set; }
        [DataMember(EmitDefaultValue = false)]

        public List<Property> properties { get; set; }

        public TestRun()
        {

        }
    }      
}
