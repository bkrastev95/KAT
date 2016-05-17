namespace KAT.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UniqueFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Brands", "Name", c => c.String(nullable: false, maxLength: 450));
            AlterColumn("dbo.Cars", "RegNumber", c => c.String(nullable: false, maxLength: 450));
            AlterColumn("dbo.Drivers", "Egn", c => c.String(nullable: false, maxLength: 450));
            AlterColumn("dbo.Cameras", "Location", c => c.String(maxLength: 450));
            AlterColumn("dbo.DocumentTypes", "Name", c => c.String(maxLength: 450));
            AlterColumn("dbo.Policemen", "Name", c => c.String(maxLength: 450));
            AlterColumn("dbo.Ranks", "Name", c => c.String(maxLength: 450));
            AlterColumn("dbo.Violations", "Name", c => c.String(maxLength: 450));
            AlterColumn("dbo.Models", "Name", c => c.String(maxLength: 450));
            AlterColumn("dbo.CarTypes", "Name", c => c.String(maxLength: 450));
            AlterColumn("dbo.Users", "Username", c => c.String(maxLength: 450));
            CreateIndex("dbo.Brands", "Name", unique: true);
            CreateIndex("dbo.Cars", "RegNumber", unique: true);
            CreateIndex("dbo.Drivers", "Egn", unique: true);
            CreateIndex("dbo.Cameras", "Location", unique: true);
            CreateIndex("dbo.DocumentTypes", "Name", unique: true);
            CreateIndex("dbo.Policemen", "Name", unique: true);
            CreateIndex("dbo.Ranks", "Name", unique: true);
            CreateIndex("dbo.Violations", "Name", unique: true);
            CreateIndex("dbo.Models", "Name", unique: true);
            CreateIndex("dbo.CarTypes", "Name", unique: true);
            CreateIndex("dbo.Users", "Username", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "Username" });
            DropIndex("dbo.CarTypes", new[] { "Name" });
            DropIndex("dbo.Models", new[] { "Name" });
            DropIndex("dbo.Violations", new[] { "Name" });
            DropIndex("dbo.Ranks", new[] { "Name" });
            DropIndex("dbo.Policemen", new[] { "Name" });
            DropIndex("dbo.DocumentTypes", new[] { "Name" });
            DropIndex("dbo.Cameras", new[] { "Location" });
            DropIndex("dbo.Drivers", new[] { "Egn" });
            DropIndex("dbo.Cars", new[] { "RegNumber" });
            DropIndex("dbo.Brands", new[] { "Name" });
            AlterColumn("dbo.Users", "Username", c => c.String());
            AlterColumn("dbo.CarTypes", "Name", c => c.String());
            AlterColumn("dbo.Models", "Name", c => c.String());
            AlterColumn("dbo.Violations", "Name", c => c.String());
            AlterColumn("dbo.Ranks", "Name", c => c.String());
            AlterColumn("dbo.Policemen", "Name", c => c.String());
            AlterColumn("dbo.DocumentTypes", "Name", c => c.String());
            AlterColumn("dbo.Cameras", "Location", c => c.String());
            AlterColumn("dbo.Drivers", "Egn", c => c.String(nullable: false));
            AlterColumn("dbo.Cars", "RegNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Brands", "Name", c => c.String(nullable: false));
        }
    }
}
