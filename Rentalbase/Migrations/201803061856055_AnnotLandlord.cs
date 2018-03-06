namespace Rentalbase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnnotLandlord : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Landlord", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Landlord", "Street", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Landlord", "City", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Landlord", "State", c => c.String(nullable: false, maxLength: 2));
            AlterColumn("dbo.Landlord", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Landlord", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Landlord", "Email", c => c.String());
            AlterColumn("dbo.Landlord", "Phone", c => c.String());
            AlterColumn("dbo.Landlord", "State", c => c.String());
            AlterColumn("dbo.Landlord", "City", c => c.String());
            AlterColumn("dbo.Landlord", "Street", c => c.String());
            AlterColumn("dbo.Landlord", "Name", c => c.String());
        }
    }
}
