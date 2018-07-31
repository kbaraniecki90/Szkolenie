namespace Szkolenie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CientMigration2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "Data", c => c.DateTime());
            AlterColumn("dbo.Clients", "FixData", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clients", "FixData", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Clients", "Data", c => c.DateTime(nullable: false));
        }
    }
}
