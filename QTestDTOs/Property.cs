using System.Runtime.Serialization;

namespace QTestDTOs
{
    [DataContract]
    public class Property
    {
        [DataMember(EmitDefaultValue = false)]
        public int field_id { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public string field_value { get; set; }

        public Property(int id, int value)
        {
            field_id = id;
            field_value = value.ToString();
        }

        public Property(int id, string value)
        {
            field_id = id;
            field_value = value;
        }
    }

    
}
