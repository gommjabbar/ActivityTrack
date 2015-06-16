namespace ActivityTrack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedEstimation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activities", "EstimatedEffort", c => c.Double(nullable: false));
            AddColumn("dbo.Activities", "EstimatedStartDate", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Activities", "EstimatedStartDate");
            DropColumn("dbo.Activities", "EstimatedEffort");
        }
    }
}
