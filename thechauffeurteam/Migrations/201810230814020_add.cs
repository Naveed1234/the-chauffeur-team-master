namespace thechauffeurteam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DriverName = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Gender = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        Nationality = c.String(nullable: false),
                        City = c.String(nullable: false),
                        PostCode = c.String(nullable: false),
                        DriverEmail = c.String(nullable: false),
                        phNo = c.String(nullable: false),
                        Fax = c.String(nullable: false),
                        JoinDate = c.DateTime(nullable: false),
                        LeftDate = c.DateTime(),
                        DirectCash = c.Boolean(nullable: false),
                        LikeAccount = c.Boolean(nullable: false),
                        DriverImage = c.Byte(nullable: false),
                        Status = c.String(),
                        DriverId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PCOLicenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DriverID = c.Int(nullable: false),
                        NiNumber = c.String(nullable: false),
                        LicenseNo = c.String(nullable: false),
                        LicenseType = c.String(nullable: false),
                        IssueDate = c.DateTime(nullable: false),
                        ExpiryDate = c.DateTime(nullable: false),
                        Insurance = c.String(nullable: false),
                        LicenseImage = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DriverID = c.Int(nullable: false),
                        UserFirstName = c.String(nullable: false),
                        UserLastName = c.String(nullable: false),
                        UserEmail = c.String(nullable: false),
                        UserPhNo = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DriverID = c.Int(nullable: false),
                        CarType = c.String(nullable: false),
                        CarModel = c.String(nullable: false),
                        Make = c.String(nullable: false),
                        Year = c.DateTime(nullable: false),
                        Description = c.String(nullable: false),
                        Registration = c.String(nullable: false),
                        Color = c.String(nullable: false),
                        MaxPassenger = c.Int(nullable: false),
                        MaxLuggage = c.Int(nullable: false),
                        CarLicenseNo = c.String(nullable: false),
                        VehicleLicenseExp = c.DateTime(nullable: false),
                        VehicleInsurance = c.String(nullable: false),
                        InsuranceExpiry = c.DateTime(nullable: false),
                        MotExpire = c.DateTime(nullable: false),
                        RoadTaxExpiry = c.DateTime(nullable: false),
                        CarImage = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Passengers", "UserFirstName", c => c.String(nullable: false));
            AddColumn("dbo.Passengers", "UserLastName", c => c.String(nullable: false));
            AddColumn("dbo.Passengers", "UserEmail", c => c.String(nullable: false));
            AddColumn("dbo.Passengers", "UserPhNo", c => c.String(nullable: false));
            AlterColumn("dbo.Passengers", "Password", c => c.String(nullable: false));
            DropColumn("dbo.Passengers", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Passengers", "Email", c => c.String());
            AlterColumn("dbo.Passengers", "Password", c => c.String());
            DropColumn("dbo.Passengers", "UserPhNo");
            DropColumn("dbo.Passengers", "UserEmail");
            DropColumn("dbo.Passengers", "UserLastName");
            DropColumn("dbo.Passengers", "UserFirstName");
            DropTable("dbo.Vehicles");
            DropTable("dbo.UserLogins");
            DropTable("dbo.PCOLicenses");
            DropTable("dbo.Drivers");
        }
    }
}
