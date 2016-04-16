namespace KAT.Data.CodeFirstModels
{
    using Nomenclatures;

    public class Policeman
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public virtual Rank Rank { get; set; }
    }
}
