namespace KAT.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedAndSomeChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "Model_Id", c => c.Long());
            AddColumn("dbo.Documents", "RegNumber", c => c.String());
            CreateIndex("dbo.Cars", "Model_Id");
            AddForeignKey("dbo.Cars", "Model_Id", "dbo.Models", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cars", "Model_Id", "dbo.Models");
            DropIndex("dbo.Cars", new[] { "Model_Id" });
            DropColumn("dbo.Documents", "RegNumber");
            DropColumn("dbo.Cars", "Model_Id");
        }
    }
}
