using System.Runtime.Serialization;

namespace KAT.Web.Models
{
    [DataContract]
    public class Policeman
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public bool IsActive { get; set; }
        [DataMember]
        public Nomenclature Rank { get; set; }
    }
}
