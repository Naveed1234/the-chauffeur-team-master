namespace thechauffeurteam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PCOLicenses", "selfEmployed", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PCOLicenses", "selfEmployed");
        }
    }
}
