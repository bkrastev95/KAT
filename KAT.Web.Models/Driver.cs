using System.Collections.Generic;
using System.Runtime.Serialization;

namespace KAT.Web.Models
{
    [DataContract]
    public class Driver : SimpleDriver
    {
        [DataMember]
        public List<Car> Cars { get; set; }
    }
}