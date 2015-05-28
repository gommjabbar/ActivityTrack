namespace ActivityTrack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class minimalFixing : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Activities", name: "ActivtyTypeId", newName: "TypeId");
            RenameIndex(table: "dbo.Activities", name: "IX_ActivtyTypeId", newName: "IX_TypeId");
            AddColumn("dbo.Activities", "Description", c => c.String());
            AlterColumn("dbo.Activities", "StartDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Activities", "EndDate", c => c.DateTimeOffset(precision: 7));
            DropColumn("dbo.Activities", "ActivityDescription");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Activities", "ActivityDescription", c => c.String());
            AlterColumn("dbo.Activities", "EndDate", c => c.DateTime());
            AlterColumn("dbo.Activities", "StartDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Activities", "Description");
            RenameIndex(table: "dbo.Activities", name: "IX_TypeId", newName: "IX_ActivtyTypeId");
            RenameColumn(table: "dbo.Activities", name: "TypeId", newName: "ActivtyTypeId");
        }
    }
}
