using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KAT.Data.CodeFirstModels.Nomenclatures;

namespace KAT.Data.CodeFirstModels
{
    public class Car
    {
        public long Id { get; set; }

        [Required]
        [StringLength(450)]
        [Index(IsUnique = true)]
        public string RegNumber { get; set; }

        public string Color { get; set; }
        public virtual CarType Type { get; set; }
        public virtual Model Model { get; set; }

        public virtual Driver Driver { get; set; }
    }
}
