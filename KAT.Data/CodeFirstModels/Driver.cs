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
        public string FirstName { get; set; }
        [Required]
        public string SecondName { get; set; }
        [Required]
        public string LastName { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
    }
}
