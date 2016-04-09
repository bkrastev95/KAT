namespace KAT.Models.Car
{
    using Nomenclature;


    public class Car
    {
        public long Id { get; set; }

        public string RegNumber { get; set; }

        public Nomenclature Color { get; set; }

        public Nomenclature Type { get; set; }

        public Nomenclature Brand { get; set; }
    }
}
