namespace thechauffeurteam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class job3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.jobs", "DriverName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.jobs", "DriverName");
        }
    }
}
