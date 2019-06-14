namespace thechauffeurteam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class job5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.jobs", "Mile", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.jobs", "Mile", c => c.Int(nullable: false));
        }
    }
}
