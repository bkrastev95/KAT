using System.Runtime.Serialization;

namespace KAT.Web.Models
{
    [DataContract]
    public class Driver
    {
        [DataMember]
        public long Id { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string SecondName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        //[DataMember]
        //public List<Car> Cars { get; set; }
    }
}