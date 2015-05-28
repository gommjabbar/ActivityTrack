namespace ActivityTrack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedEOs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Activities", "ActivityType_Id", "dbo.ActivityTypes");
            DropIndex("dbo.Activities", new[] { "ActivityType_Id" });
            DropColumn("dbo.Activities", "ActivtyTypeId");
            RenameColumn(table: "dbo.Activities", name: "ActivityType_Id", newName: "ActivtyTypeId");
            AlterColumn("dbo.Activities", "EndDate", c => c.DateTime());
            AlterColumn("dbo.Activities", "ActivtyTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Activities", "ActivtyTypeId");
            AddForeignKey("dbo.Activities", "ActivtyTypeId", "dbo.ActivityTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Activities", "ActivtyTypeId", "dbo.ActivityTypes");
            DropIndex("dbo.Activities", new[] { "ActivtyTypeId" });
            AlterColumn("dbo.Activities", "ActivtyTypeId", c => c.Int());
            AlterColumn("dbo.Activities", "EndDate", c => c.DateTime(nullable: false));
            RenameColumn(table: "dbo.Activities", name: "ActivtyTypeId", newName: "ActivityType_Id");
            AddColumn("dbo.Activities", "ActivtyTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Activities", "ActivityType_Id");
            AddForeignKey("dbo.Activities", "ActivityType_Id", "dbo.ActivityTypes", "Id");
        }
    }
}
