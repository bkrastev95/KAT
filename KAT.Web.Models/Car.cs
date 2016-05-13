using System.Runtime.Serialization;

namespace KAT.Web.Models
{
    [DataContract]
    public class Car
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string RegNumber { get; set; }
        [DataMember]
        public string Color { get; set; }
        [DataMember]
        public Nomenclature Type { get; set; }
        [DataMember]
        public Nomenclature Model { get; set; }
        [DataMember]
        public SimpleDriver Driver { get; set; }
    }
}
