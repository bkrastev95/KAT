using System;

namespace KAT.Models.Driver
{
    using System.Collections.Generic;

    using Car;


    public class Driver
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string LastName { get; set; }

        public string Egn { get; set; }

        public List<Car> Cars { get; set; }

        public string FullName
        {
            get
            {
                return string.Format("{0} {1} {2}", FirstName, SecondName, LastName);
            }
        }

        public override bool Equals(object obj)
        {
            return obj is Driver && ((Driver) obj).Egn == Egn;
        }
    }
}
