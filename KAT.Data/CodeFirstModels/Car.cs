using KAT.Data.CodeFirstModels.Nomenclatures;
using Microsoft.Build.Framework;

namespace KAT.Data.CodeFirstModels
{
    public class Car
    {
        public long Id { get; set; }
        [Required]
        public string RegNumber { get; set; }
        public virtual CarType Type { get; set; }
        public virtual Brand Brand { get; set; }
    }
}
