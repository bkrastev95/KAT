using System.Runtime.Serialization;

namespace KAT.Web.Models
{
    [DataContract]
    public class Nomenclature
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}
