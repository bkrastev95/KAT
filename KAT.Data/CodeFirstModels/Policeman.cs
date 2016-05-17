using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KAT.Data.CodeFirstModels
{
    using Nomenclatures;

    public class Policeman
    {
        public long Id { get; set; }

        [StringLength(450)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public virtual Rank Rank { get; set; }
    }
}
