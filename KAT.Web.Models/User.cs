using System.Runtime.Serialization;
using System.Security;

namespace KAT.Web.Models
{
    [DataContract]
    public class User
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public SecureString Password { get; set; }
        [DataMember]
        public bool IsAdmin { get; set; }
    }
}
