using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KAT.Data.CodeFirstModels.Nomenclatures
{
    public class Model
    {
        public long Id { get; set; }

        [StringLength(450)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
        public virtual Brand Brand { get; set; }
    }
}
