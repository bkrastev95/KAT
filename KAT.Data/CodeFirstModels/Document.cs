using System;
using System.Collections.Generic;
using KAT.Data.CodeFirstModels.Nomenclatures;

namespace KAT.Data.CodeFirstModels
{
    public class Document
    {
        public long Id { get; set; }
        [Microsoft.Build.Framework.Required]
        public DateTime Date { get; set; }

        public string RegNumber { get; set; }
        public byte[] Picture { get; set; }
        [Microsoft.Build.Framework.Required]
        public virtual ICollection<Violation> Violations { get; set; }
        [Microsoft.Build.Framework.Required]
        public virtual Policeman Policeman { get; set; }
        public virtual Camera Camera { get; set; }
        [Microsoft.Build.Framework.Required]
        public virtual Driver Driver { get; set; }
        [Microsoft.Build.Framework.Required]
        public virtual DocumentType DocumentType { get; set; }
        
    }
}
