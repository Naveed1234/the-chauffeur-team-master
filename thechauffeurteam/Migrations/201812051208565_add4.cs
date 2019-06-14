namespace thechauffeurteam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Drivers", "Fax", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Drivers", "Fax", c => c.String(nullable: false));
        }
    }
}
