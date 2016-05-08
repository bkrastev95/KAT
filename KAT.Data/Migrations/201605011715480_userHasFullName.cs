namespace KAT.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userHasFullName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "FullName", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "FullName");
        }
    }
}
