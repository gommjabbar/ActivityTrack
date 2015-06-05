namespace ActivityTrack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OptionalActivityType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Activities", "TypeId", "dbo.ActivityTypes");
            DropIndex("dbo.Activities", new[] { "TypeId" });
            RenameColumn(table: "dbo.Activities", name: "TypeId", newName: "ActivityTypeId");
            AlterColumn("dbo.Activities", "ActivityTypeId", c => c.Int());
            CreateIndex("dbo.Activities", "ActivityTypeId");
            AddForeignKey("dbo.Activities", "ActivityTypeId", "dbo.ActivityTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Activities", "ActivityTypeId", "dbo.ActivityTypes");
            DropIndex("dbo.Activities", new[] { "ActivityTypeId" });
            AlterColumn("dbo.Activities", "ActivityTypeId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Activities", name: "ActivityTypeId", newName: "TypeId");
            CreateIndex("dbo.Activities", "TypeId");
            AddForeignKey("dbo.Activities", "TypeId", "dbo.ActivityTypes", "Id", cascadeDelete: true);
        }
    }
}
