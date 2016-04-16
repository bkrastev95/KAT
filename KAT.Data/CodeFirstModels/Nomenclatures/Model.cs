namespace KAT.Data.CodeFirstModels.Nomenclatures
{
    public class Model
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual Brand Brand { get; set; }
    }
}
