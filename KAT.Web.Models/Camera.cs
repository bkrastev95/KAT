using System.Runtime.Serialization;

namespace KAT.Web.Models
{
    [DataContract]
    public class Camera
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string Location { get; set; }
    }
}
