namespace thechauffeurteam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingHourlyPrice : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HourlyPrices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HourFrom = c.Int(nullable: false),
                        HourTo = c.Int(nullable: false),
                        SclassPerMile = c.Single(nullable: false),
                        VclassPerMile = c.Single(nullable: false),
                        EclassPerMile = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HourlyPrices");
        }
    }
}
