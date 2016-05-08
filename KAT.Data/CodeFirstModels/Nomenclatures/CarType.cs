using System.Collections.Generic;

namespace KAT.Data.CodeFirstModels.Nomenclatures
{
    public class CarType
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Car> Cars{ get; set; }
    }
}
