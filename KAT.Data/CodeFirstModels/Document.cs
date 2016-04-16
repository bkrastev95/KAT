using System;
using System.Collections.Generic;
using KAT.Data.CodeFirstModels.Nomenclatures;
using Microsoft.Build.Framework;

namespace KAT.Data.CodeFirstModels
{
    public class Document
    {
        public long Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public byte[] Picture { get; set; }
        [Required]
        public virtual ICollection<Violation> Violations { get; set; }
        [Required]
        public virtual Policeman Policeman { get; set; }
        public virtual Camera Camera { get; set; }
        [Required]
        public virtual Driver Driver { get; set; }
        [Required]
        public virtual DocumentType DocumentType { get; set; }
        
    }
}
