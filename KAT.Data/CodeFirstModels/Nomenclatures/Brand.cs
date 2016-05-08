﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KAT.Data.CodeFirstModels.Nomenclatures
{
    public class Brand
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<Model> Models { get; set; }
    }
}
