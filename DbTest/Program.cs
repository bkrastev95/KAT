using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KAT.Data.CodeFirstModels;
using KAT.Data.KAT.Context;

namespace DbTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new KatContext())
            {
                // Create and save a new Blog 
                Console.Write("Enter a name for a new Blog: ");
                var name = Console.ReadLine();

                var driver = new Driver { FirstName = name };
                db.Drivers.Add(driver);
                db.SaveChanges();

                // Display all Blogs from the database 
                var query = from b in db.Drivers
                            orderby b.FirstName
                            select b;

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.FirstName);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        } 
    }
}
