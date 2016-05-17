using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KAT.Data.CodeFirstModels.Nomenclatures
{
    using System.Collections.Generic;

    public class Violation
    {
        public long Id { get; set; }

        [StringLength(450)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }

        public virtual ICollection<Document> Documents { get; set; }
    }
}
