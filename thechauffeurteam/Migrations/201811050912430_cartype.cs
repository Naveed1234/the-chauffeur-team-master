namespace thechauffeurteam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cartype : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Eclasses", "FirstMile", c => c.Single(nullable: false));
            AlterColumn("dbo.Eclasses", "PerMiles", c => c.Single(nullable: false));
            AlterColumn("dbo.Sclasses", "FirstMile", c => c.Single(nullable: false));
            AlterColumn("dbo.Sclasses", "PerMiles", c => c.Single(nullable: false));
            AlterColumn("dbo.Vclasses", "FirstMile", c => c.Single(nullable: false));
            AlterColumn("dbo.Vclasses", "PerMiles", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vclasses", "PerMiles", c => c.String());
            AlterColumn("dbo.Vclasses", "FirstMile", c => c.String());
            AlterColumn("dbo.Sclasses", "PerMiles", c => c.String());
            AlterColumn("dbo.Sclasses", "FirstMile", c => c.String());
            AlterColumn("dbo.Eclasses", "PerMiles", c => c.String());
            AlterColumn("dbo.Eclasses", "FirstMile", c => c.String());
        }
    }
}
