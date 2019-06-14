namespace thechauffeurteam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateProj : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.jobs", "PassengerPhone", c => c.String());
            AddColumn("dbo.jobs", "DriverId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.jobs", "DriverId");
            DropColumn("dbo.jobs", "PassengerPhone");
        }
    }
}
