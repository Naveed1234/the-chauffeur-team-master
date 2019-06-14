namespace thechauffeurteam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDriverPcoLicenseModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PCOLicenses", "DriverLicenseNo", c => c.String(nullable: false));
            AddColumn("dbo.PCOLicenses", "PcoDriverLicenseNo", c => c.String(nullable: false));
            AddColumn("dbo.PCOLicenses", "PcoDriverLicenseIssueDate", c => c.String(nullable: false));
            AddColumn("dbo.PCOLicenses", "PcoDriverLicenseExpiryDate", c => c.String(nullable: false));
            DropColumn("dbo.PCOLicenses", "LicenseNo");
            DropColumn("dbo.PCOLicenses", "LicenseType");
            DropColumn("dbo.PCOLicenses", "Insurance");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PCOLicenses", "Insurance", c => c.String(nullable: false));
            AddColumn("dbo.PCOLicenses", "LicenseType", c => c.String(nullable: false));
            AddColumn("dbo.PCOLicenses", "LicenseNo", c => c.String(nullable: false));
            DropColumn("dbo.PCOLicenses", "PcoDriverLicenseExpiryDate");
            DropColumn("dbo.PCOLicenses", "PcoDriverLicenseIssueDate");
            DropColumn("dbo.PCOLicenses", "PcoDriverLicenseNo");
            DropColumn("dbo.PCOLicenses", "DriverLicenseNo");
        }
    }
}
