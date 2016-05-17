using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KAT.Data.CodeFirstModels.Nomenclatures
{
    public class Brand
    {
        public long Id { get; set; }

        [Required]
        [StringLength(450)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<Model> Models { get; set; }
    }
}
