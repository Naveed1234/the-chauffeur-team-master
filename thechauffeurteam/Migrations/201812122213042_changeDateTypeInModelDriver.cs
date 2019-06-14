namespace thechauffeurteam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeDateTypeInModelDriver : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Drivers", "DateOfBirth", c => c.String(nullable: false));
            AlterColumn("dbo.Drivers", "JoinDate", c => c.String(nullable: false));
            AlterColumn("dbo.Drivers", "LeftDate", c => c.String());
            AlterColumn("dbo.PCOLicenses", "IssueDate", c => c.String(nullable: false));
            AlterColumn("dbo.PCOLicenses", "ExpiryDate", c => c.String(nullable: false));
            AlterColumn("dbo.Vehicles", "Year", c => c.String(nullable: false));
            AlterColumn("dbo.Vehicles", "VehicleLicenseExp", c => c.String(nullable: false));
            AlterColumn("dbo.Vehicles", "InsuranceExpiry", c => c.String(nullable: false));
            AlterColumn("dbo.Vehicles", "MotExpire", c => c.String(nullable: false));
            AlterColumn("dbo.Vehicles", "RoadTaxExpiry", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicles", "RoadTaxExpiry", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Vehicles", "MotExpire", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Vehicles", "InsuranceExpiry", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Vehicles", "VehicleLicenseExp", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Vehicles", "Year", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PCOLicenses", "ExpiryDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PCOLicenses", "IssueDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Drivers", "LeftDate", c => c.DateTime());
            AlterColumn("dbo.Drivers", "JoinDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Drivers", "DateOfBirth", c => c.DateTime(nullable: false));
        }
    }
}
