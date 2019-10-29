namespace PcComponentsShop.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaidAtField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "PaidAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "PaidAt");
        }
    }
}
