namespace thechauffeurteam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class job2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.jobs", "DriverId", c => c.Int(nullable: true));
            CreateIndex("dbo.jobs", "DriverId");
            AddForeignKey("dbo.jobs", "DriverId", "dbo.Drivers", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.jobs", "DriverId", "dbo.Drivers");
            DropIndex("dbo.jobs", new[] { "DriverId" });
            DropColumn("dbo.jobs", "DriverId");
        }
    }
}
