namespace Rentalbase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EndDateToDurationMonths : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Lease", "DurationMonths", c => c.Int(nullable: false));
            DropColumn("dbo.Lease", "EndDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Lease", "EndDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Lease", "DurationMonths");
        }
    }
}
