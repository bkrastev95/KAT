namespace KAT.Models.Nomenclature
{
    public class Nomenclature
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Nomenclature && ((Nomenclature)obj).Name == Name;
        }
    }
}
