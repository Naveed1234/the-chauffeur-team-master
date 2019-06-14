namespace thechauffeurteam.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingJobsTblFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.jobs", "PassengerId", c => c.Int(nullable: false));
            AddColumn("dbo.jobs", "Hours", c => c.Int());
            AddColumn("dbo.jobs", "Mile", c => c.Int(nullable: false));
            AlterColumn("dbo.jobs", "dateAndTime", c => c.String());
            AlterColumn("dbo.jobs", "status", c => c.Int());
            CreateIndex("dbo.jobs", "PassengerId");
            AddForeignKey("dbo.jobs", "PassengerId", "dbo.Passengers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.jobs", "PassengerId", "dbo.Passengers");
            DropIndex("dbo.jobs", new[] { "PassengerId" });
            AlterColumn("dbo.jobs", "status", c => c.Int(nullable: false));
            AlterColumn("dbo.jobs", "dateAndTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.jobs", "Mile");
            DropColumn("dbo.jobs", "Hours");
            DropColumn("dbo.jobs", "PassengerId");
        }
    }
}
