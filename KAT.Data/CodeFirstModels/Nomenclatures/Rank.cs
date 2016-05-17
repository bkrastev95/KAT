using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KAT.Data.CodeFirstModels.Nomenclatures
{
    using System.Collections.Generic;

    public class Rank
    {
        public long Id { get; set; }

        [StringLength(450)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
        public string Code { get; set; }

        public virtual ICollection<Policeman> Policemen { get; set; }
    }
}
