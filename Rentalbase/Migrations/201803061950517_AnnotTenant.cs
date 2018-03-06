namespace Rentalbase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnnotTenant : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tenant", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Tenant", "Phone", c => c.String(nullable: false, maxLength: 12));
            AlterColumn("dbo.Tenant", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tenant", "Email", c => c.String());
            AlterColumn("dbo.Tenant", "Phone", c => c.String());
            AlterColumn("dbo.Tenant", "Name", c => c.String());
        }
    }
}
