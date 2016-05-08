using System.ComponentModel.DataAnnotations;
using KAT.Data.CodeFirstModels.Nomenclatures;

namespace KAT.Data.CodeFirstModels
{
    public class Car
    {
        public long Id { get; set; }

        [Required]
        public string RegNumber { get; set; }
        public virtual CarType Type { get; set; }
        public virtual Model Model { get; set; }
    }
}
