namespace thechauffeurteam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addjobFieldMessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.jobs", "Message", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.jobs", "Message");
        }
    }
}
