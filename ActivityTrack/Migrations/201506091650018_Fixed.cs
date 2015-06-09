namespace ActivityTrack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fixed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Times", "ActivityEO_Id", "dbo.Activities");
            DropIndex("dbo.Times", new[] { "ActivityEO_Id" });
            DropColumn("dbo.Times", "ActivityId");
            RenameColumn(table: "dbo.Times", name: "ActivityEO_Id", newName: "ActivityId");
            AlterColumn("dbo.Times", "ActivityId", c => c.Int(nullable: false));
            CreateIndex("dbo.Times", "ActivityId");
            AddForeignKey("dbo.Times", "ActivityId", "dbo.Activities", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Times", "ActivityId", "dbo.Activities");
            DropIndex("dbo.Times", new[] { "ActivityId" });
            AlterColumn("dbo.Times", "ActivityId", c => c.Int());
            RenameColumn(table: "dbo.Times", name: "ActivityId", newName: "ActivityEO_Id");
            AddColumn("dbo.Times", "ActivityId", c => c.Int(nullable: false));
            CreateIndex("dbo.Times", "ActivityEO_Id");
            AddForeignKey("dbo.Times", "ActivityEO_Id", "dbo.Activities", "Id");
        }
    }
}
