namespace KAT.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uniques : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Brands", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Cars", "RegNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Drivers", "Egn", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Drivers", "Egn", c => c.String());
            AlterColumn("dbo.Cars", "RegNumber", c => c.String());
            AlterColumn("dbo.Brands", "Name", c => c.String());
        }
    }
}
