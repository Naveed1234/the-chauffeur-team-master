namespace thechauffeurteam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addjobField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.jobs", "PdoorNumber", c => c.Int());
            AddColumn("dbo.jobs", "DdoorNumber", c => c.Int());
            AddColumn("dbo.jobs", "Attribute", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.jobs", "Attribute");
            DropColumn("dbo.jobs", "DdoorNumber");
            DropColumn("dbo.jobs", "PdoorNumber");
        }
    }
}
