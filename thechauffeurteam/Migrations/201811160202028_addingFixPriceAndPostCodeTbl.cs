namespace thechauffeurteam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingFixPriceAndPostCodeTbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FixPrices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PickUp = c.Int(nullable: false),
                        DropOff = c.Int(nullable: false),
                        Sclass = c.Single(nullable: false),
                        Vclass = c.Single(nullable: false),
                        Eclass = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PostCodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostCodeValue = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PostCodes");
            DropTable("dbo.FixPrices");
        }
    }
}
