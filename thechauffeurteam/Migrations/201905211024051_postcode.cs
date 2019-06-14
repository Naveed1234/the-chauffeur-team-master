namespace thechauffeurteam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class postcode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FixPrices", "PostCodeId", c => c.Int(nullable: true));
            CreateIndex("dbo.FixPrices", "PostCodeId");
            AddForeignKey("dbo.FixPrices", "PostCodeId", "dbo.PostCodes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FixPrices", "PostCodeId", "dbo.PostCodes");
            DropIndex("dbo.FixPrices", new[] { "PostCodeId" });
            DropColumn("dbo.FixPrices", "PostCodeId");
        }
    }
}
