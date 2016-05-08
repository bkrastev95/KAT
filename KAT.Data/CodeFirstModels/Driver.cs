using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KAT.Data.CodeFirstModels
{
    public class Driver
    {
        public long Id { get; set; }

        [Required]
        public string Egn { get; set; }
        [Microsoft.Build.Framework.Required]
        public string FirstName { get; set; }
        [Microsoft.Build.Framework.Required]
        public string SecondName { get; set; }
        [Microsoft.Build.Framework.Required]
        public string LastName { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
    }
}
