using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QTestDTOs
{
    [DataContract]
    public class TestCase
    {

        [DataMember(EmitDefaultValue = false)]
        public int id { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string parent_id { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string description { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string preconition { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public int order { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string pid { get; set; }
      
        [DataMember(EmitDefaultValue = false)]
        public double test_case_version_id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public int testRunId { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string attachments { get; set; }//TODO:Array of attachements

       [DataMember(EmitDefaultValue = false)]
        public string version { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string web_url { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string  name { get; set; }
       // [DataMember]
        public List<Link> links { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public List<Property> properties { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string url { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public List<TestStep> test_steps { get; set; }
		[DataMember(EmitDefaultValue = false)]
		public List<AssociatedObject> objects{ get; set; }


		public KeyValuePair<int, string> key_value { get { return new KeyValuePair<int, string>(id, name); } }

        public TestCase(string name)
        {
            this.name = name;
       

        }
        public TestCase()
        {

        }

    }
}