using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KAT.Data.CodeFirstModels.Nomenclatures
{
    using System.Collections.Generic;

    public class Camera
    {
        public long Id { get; set; }

        [StringLength(450)]
        [Index(IsUnique = true)]
        public string Location { get; set; }

        public virtual ICollection<Document> Documents { get; set; }
    }
}
