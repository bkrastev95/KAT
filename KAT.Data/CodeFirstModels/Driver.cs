using System.Collections.Generic;
using Microsoft.Build.Framework;

namespace KAT.Data.CodeFirstModels
{
    public class Driver
    {
        public long Id { get; set; }
        [Required]
        public string Egn { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
    }
}
