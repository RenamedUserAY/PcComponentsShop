namespace PcComponentsShop.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableDATETIME : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "PaidAt", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "PaidAt", c => c.DateTime(nullable: false));
        }
    }
}
