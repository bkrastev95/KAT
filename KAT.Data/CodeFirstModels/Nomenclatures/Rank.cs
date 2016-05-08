namespace KAT.Data.CodeFirstModels.Nomenclatures
{
    using System.Collections.Generic;

    public class Rank
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Policeman> Policemen { get; set; }
    }
}
