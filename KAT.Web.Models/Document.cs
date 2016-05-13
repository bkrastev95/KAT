using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace KAT.Web.Models
{
    [DataContract]
    public class Document
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string RegNumber { get; set; }
        [DataMember]
        public byte[] Picture { get; set; }
        [DataMember]
        public ICollection<Violation> Violations { get; set; }
        [DataMember]
        public Policeman Policeman { get; set; }
        [DataMember]
        public Camera Camera { get; set; }
        [DataMember]
        public Driver Driver { get; set; }
        [DataMember]
        public Nomenclature DocumentType { get; set; }
    }
}
