﻿using System.Data.Entity;
using System.Data.Entity.Spatial;
using KAT.Data.CodeFirstModels;
using KAT.Data.CodeFirstModels.Nomenclatures;

namespace KAT.Data.KAT.Context
{
    public class KatDataContext : DbContext
    {
        public DbSet<Policeman> Policemеn { get; set; }
        public DbSet<Rank> Ranks { get; set; } 
        public DbSet<Violation> Violations { get; set; }
        public DbSet<Camera> Cameras { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarType> CarTypes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<User> Users { get; set; } 
    }
}
