namespace thechauffeurteam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class job : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.jobs", "PassengerName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.jobs", "PassengerName");
        }
    }
}
