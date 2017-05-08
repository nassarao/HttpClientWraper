using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QTestDTOs
{
    [DataContract]
    public class TestStepLog
    {
        [DataMember(EmitDefaultValue = false)]
        public int test_step_id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public int user_id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public int execution_status { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string actual_result { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public int called_test_case_name { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public int run_order { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public int group { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public TestStep test_step { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public List<DefectLink> defects { get; set; }
    }
}
