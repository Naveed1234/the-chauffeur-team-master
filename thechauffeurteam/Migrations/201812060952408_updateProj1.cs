namespace thechauffeurteam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateProj1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.jobs", "PassengerId", "dbo.Passengers");
            DropIndex("dbo.jobs", new[] { "PassengerId" });
            AlterColumn("dbo.jobs", "PassengerId", c => c.Int());
            CreateIndex("dbo.jobs", "PassengerId");
            AddForeignKey("dbo.jobs", "PassengerId", "dbo.Passengers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.jobs", "PassengerId", "dbo.Passengers");
            DropIndex("dbo.jobs", new[] { "PassengerId" });
            AlterColumn("dbo.jobs", "PassengerId", c => c.Int(nullable: false));
            CreateIndex("dbo.jobs", "PassengerId");
            AddForeignKey("dbo.jobs", "PassengerId", "dbo.Passengers", "Id", cascadeDelete: true);
        }
    }
}
