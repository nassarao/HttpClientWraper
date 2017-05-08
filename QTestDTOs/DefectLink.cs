using System.Runtime.Serialization;

namespace QTestDTOs
{
    [DataContract]
    public class DefectLink
    {
        [DataMember(EmitDefaultValue = false)]
        public int id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string external_defect_id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public int connection_id { get; set; }
        /// <summary>
        /// If it is a rally defect, external project id is “href” of rally project. It is for linking to exactly defect in Rally Web
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string external_project_id { get; set; }
        [DataMember(EmitDefaultValue = false)]
        public string web_url { get; set; }
    }
}
