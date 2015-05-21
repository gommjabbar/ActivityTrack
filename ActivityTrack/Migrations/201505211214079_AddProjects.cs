namespace ActivityTrack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProjects : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Activities", "ProjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Activities", "ProjectId");
            AddForeignKey("dbo.Activities", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Activities", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Activities", new[] { "ProjectId" });
            DropColumn("dbo.Activities", "ProjectId");
            DropTable("dbo.Projects");
        }
    }
}
