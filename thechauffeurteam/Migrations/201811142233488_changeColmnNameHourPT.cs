namespace thechauffeurteam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeColmnNameHourPT : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HourlyPrices", "SclassPerHour", c => c.Single(nullable: false));
            AddColumn("dbo.HourlyPrices", "VclassPerHour", c => c.Single(nullable: false));
            AddColumn("dbo.HourlyPrices", "EclassPerHour", c => c.Single(nullable: false));
            DropColumn("dbo.HourlyPrices", "SclassPerMile");
            DropColumn("dbo.HourlyPrices", "VclassPerMile");
            DropColumn("dbo.HourlyPrices", "EclassPerMile");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HourlyPrices", "EclassPerMile", c => c.Single(nullable: false));
            AddColumn("dbo.HourlyPrices", "VclassPerMile", c => c.Single(nullable: false));
            AddColumn("dbo.HourlyPrices", "SclassPerMile", c => c.Single(nullable: false));
            DropColumn("dbo.HourlyPrices", "EclassPerHour");
            DropColumn("dbo.HourlyPrices", "VclassPerHour");
            DropColumn("dbo.HourlyPrices", "SclassPerHour");
        }
    }
}
