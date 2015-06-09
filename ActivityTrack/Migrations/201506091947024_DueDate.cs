namespace ActivityTrack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DueDate : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Activities", "StartDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Activities", "StartDate", c => c.DateTimeOffset(precision: 7));
        }
    }
}
