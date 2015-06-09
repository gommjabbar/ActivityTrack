namespace ActivityTrack.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedSomeBugs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Times", "CreateDate", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.Times", "UpdateDate", c => c.DateTimeOffset(precision: 7));
            AddColumn("dbo.Times", "DeleteDate", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Times", "DeleteDate");
            DropColumn("dbo.Times", "UpdateDate");
            DropColumn("dbo.Times", "CreateDate");
        }
    }
}
