using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace QTestDTOs
{
    [DataContract]
    public class Cycle
    {
        [DataMember(EmitDefaultValue = false)]
        public int id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public int parentId { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string name { get; set; }
    }
}
