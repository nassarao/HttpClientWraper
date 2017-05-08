using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QTestDTOs
{
    [DataContract]
    public class TestLog
    {
        [DataMember(EmitDefaultValue = false)]
        public string status { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public double test_case_version_id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime exe_start_date { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public DateTime exe_end_date { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public int user_id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string note { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public List<TestStepLog>test_step_logs { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public List<Attachment> attachments { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string class_name { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public TestCase test_case { get; set; }
    }
}