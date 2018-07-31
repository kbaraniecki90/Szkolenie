namespace Szkolenie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CientMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        Login = c.String(),
                        Data = c.DateTime(nullable: false),
                        ProblemDetails = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.Int(nullable: false),
                        FixDetails = c.String(),
                        FixData = c.DateTime(nullable: false),
                        IsFixed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Clients");
        }
    }
}
