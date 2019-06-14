namespace thechauffeurteam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Passengers", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Passengers", "MyProperty", c => c.Int(nullable: false));
        }
    }
}
