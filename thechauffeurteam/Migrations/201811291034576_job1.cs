namespace thechauffeurteam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class job1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.jobs", "Distance");
        }
        
        public override void Down()
        {
            AddColumn("dbo.jobs", "Distance", c => c.String());
        }
    }
}
