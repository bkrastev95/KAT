using System;
using System.Collections.Generic;

namespace KAT.Models.Document
{
    public class Document
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }

        public string RegNumber { get; set; }
        public byte[] Picture { get; set; }
        public ICollection<Violation.Violation> Violations { get; set; }

        public Policeman.Policeman Policeman { get; set; }
        public Camera.Camera Camera { get; set; }

        public Driver.Driver Driver { get; set; }

        public Nomenclature.Nomenclature DocumentType { get; set; }

    }
}
