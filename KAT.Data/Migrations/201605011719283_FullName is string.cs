namespace KAT.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FullNameisstring : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE dbo.Users DROP CONSTRAINT DF__Users__FullName__47DBAE45");
            AlterColumn("dbo.Users", "FullName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "FullName", c => c.Boolean(nullable: false));
        }
    }
}
