namespace thechauffeurteam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class logoImageModelAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logo_Img",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        LogoImage = c.Binary(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Logo_Img");
        }
    }
}
