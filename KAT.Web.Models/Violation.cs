using System.Runtime.Serialization;

namespace KAT.Web.Models
{
    [DataContract]
    public class Violation
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Note { get; set; }
    }
}
