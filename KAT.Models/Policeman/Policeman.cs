namespace KAT.Models.Policeman
{
    public class Policeman : Nomenclature.Nomenclature
    {
        public bool IsActive { get; set; }

        public Nomenclature.Nomenclature Rank { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Policeman && ((Policeman)obj).Name == Name;
        }
    }
}
