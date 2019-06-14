namespace thechauffeurteam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Eclasses",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FirstMile = c.String(),
                        PerMiles = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Sclasses",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FirstMile = c.String(),
                        PerMiles = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Vclasses",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FirstMile = c.String(),
                        PerMiles = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vclasses");
            DropTable("dbo.Sclasses");
            DropTable("dbo.Eclasses");
        }
    }
}
