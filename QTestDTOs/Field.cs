using System.Collections.Generic;
using System.Runtime.Serialization;

namespace QTestDTOs
{
    [DataContract]
    public class Field
    {
        public class Status
        {
            public const int 
                id = 1334120,
                New = 201,
                InProgress = 202, 
                ReadyForBaseLine = 203,
                Baselined = 204;
        }

        public class Precondition
        {
            public const int
                id = 1334124;     
        }


        public class Priority
        {
            public const int
                id = 1334125,
                Undecided = 721,
                Low = 722, 
                Medium = 723,
                High = 724,
                Urgent = 725;
        }

        public class Type
        {
            public const int
                id = 1334121,
                Manual = 701,
                Automation = 702,
                Performance = 703,
                Scenario = 704;
        }
        public class AssignedTo
        {
            //TODO:figure out way to generate this
            public const int
                id = 1334113,
                PraakritPradhan = 29142,
                AhmadNassar = 28739,
                BrianFarwick = 16895,            
                NickWerle = 34952;
        }

        public class Description
        {
            public const int
                id = 1334123;
        }

        [DataMember(EmitDefaultValue = false)]
        public int id { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string label { get; set; }
        /// <summary>
        /// required field when submission new defect
        /// </summary>


        [DataMember(EmitDefaultValue = false)]
        public bool required { get; set; }
        /// <summary>
        /// if true, just use values in allowed_values only
        /// </summary>

        [DataMember(EmitDefaultValue = false)]
        public bool constrained { get; set; }
        /// <summary>
        /// order of field for display
        /// </summary>

        [DataMember(EmitDefaultValue = false)]
        public int order { get; set; }
        /// <summary>
        /// can have multi-values (sample checkbox custom filed)
        /// </summary>

        [DataMember(EmitDefaultValue = false)]
        public bool multiple { get; set; }
        /// <summary>
        /// 	can be String, LongText, DateTime, Number, Boolead, URL, ArrayNumber
        /// </summary>

        [DataMember(EmitDefaultValue = false)]
        public string attribute_type { get; set; }
        /// <summary>
        /// Array of Key + Value as data f dropdown list
        /// </summary>

        [DataMember(EmitDefaultValue = false)]
        public List<KeyValuePair<int,string>> allowed_values { get; set; }
    }
}
