using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KAT.Data.CodeFirstModels.Nomenclatures
{
    public class CarType
    {
        public long Id { get; set; }

        [StringLength(450)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
        public string Code { get; set; }
        public virtual ICollection<Car> Cars{ get; set; }
    }
}
