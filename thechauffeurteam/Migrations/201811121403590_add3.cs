namespace thechauffeurteam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.jobs", "JobType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.jobs", "JobType");
        }
    }
}
