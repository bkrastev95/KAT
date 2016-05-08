namespace KAT.Data.CodeFirstModels.Nomenclatures
{
    using System.Collections.Generic;

    public class Camera
    {
        public long Id { get; set; }

        public string Location { get; set; }

        public virtual ICollection<Document> Documents { get; set; }
    }
}
