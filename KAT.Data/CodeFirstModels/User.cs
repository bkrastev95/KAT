using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KAT.Data.CodeFirstModels
{
    public class User
    {
        public long Id { get; set; }
        [StringLength(450)]
        [Index(IsUnique = true)]
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public string FullName { get; set; }
    }
}
