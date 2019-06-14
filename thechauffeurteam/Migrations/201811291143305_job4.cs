namespace thechauffeurteam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class job4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.jobs", "DriverId", "dbo.Drivers");
            DropIndex("dbo.jobs", new[] { "DriverId" });
            DropColumn("dbo.jobs", "DriverId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.jobs", "DriverId", c => c.Int(nullable: false));
            CreateIndex("dbo.jobs", "DriverId");
            AddForeignKey("dbo.jobs", "DriverId", "dbo.Drivers", "Id", cascadeDelete: true);
        }
    }
}
