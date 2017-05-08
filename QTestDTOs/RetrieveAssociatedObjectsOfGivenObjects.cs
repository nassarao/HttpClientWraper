using System.Collections.Generic;
using System.Runtime.Serialization;



namespace QTestDTOs
{
    [DataContract]
    public class AssociatedObject
    {
        [DataMember(EmitDefaultValue = false)]
        public int id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string pid { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string link_type { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string self { get; set; }

		public KeyValuePair<int, string> key_value { get { return new KeyValuePair<int, string>(id, pid); } }
	}
  
    [DataContract]
    public class GivenObject
    {
        [DataMember(EmitDefaultValue = false)]
        public int id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public List<AssociatedObject> objects { get; set; }
    }

	[DataContract]
	public class Link
	{
        [DataMember(EmitDefaultValue = false)]
        public string rel { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string href { get; set; }
	}

	[DataContract]
	public class TestCaseObject
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
        public string web_url { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public int parent_id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public double test_case_version_id { get; set; }

		public KeyValuePair<int, string> key_value { get { return new KeyValuePair<int, string>(id, name); } }
	}

 
}