namespace Rentalbase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnnotLease : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Lease", "RateMonthly", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Lease", "RateMonthly", c => c.Single(nullable: false));
        }
    }
}
