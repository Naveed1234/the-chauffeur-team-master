namespace thechauffeurteam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.jobs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        dateAndTime = c.DateTime(nullable: false),
                        pickUp = c.String(),
                        DropUP = c.String(),
                        Distance = c.String(),
                        CarType = c.String(),
                        Price = c.String(),
                        DriverMessage = c.String(),
                        status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.jobs");
        }
    }
}
