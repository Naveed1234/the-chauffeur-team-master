namespace thechauffeurteam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingDistanceTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DistancePrices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MileFrom = c.Int(nullable: false),
                        MileTo = c.Int(nullable: false),
                        SclassFirstMile = c.Single(nullable: false),
                        SclassPerMile = c.Single(nullable: false),
                        VclassFirstMile = c.Single(nullable: false),
                        VclassPerMile = c.Single(nullable: false),
                        EclassFirstMile = c.Single(nullable: false),
                        EclassPerMile = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Drivers", "DriverImage", c => c.Binary());
            AlterColumn("dbo.PCOLicenses", "LicenseImage", c => c.Binary());
            AlterColumn("dbo.Vehicles", "CarImage", c => c.Binary());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicles", "CarImage", c => c.Byte(nullable: false));
            AlterColumn("dbo.PCOLicenses", "LicenseImage", c => c.Byte(nullable: false));
            AlterColumn("dbo.Drivers", "DriverImage", c => c.Byte(nullable: false));
            DropTable("dbo.DistancePrices");
        }
    }
}
