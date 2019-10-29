namespace PcComponentsShop.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrdersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderStatus = c.String(nullable: false, maxLength: 10),
                        FullGoodName = c.String(nullable: false, maxLength: 255),
                        GoodId = c.Int(nullable: false),
                        UserName = c.String(nullable: false),
                        GoodAmount = c.Int(nullable: false),
                        GoodCategory = c.String(nullable: false),
                        GoodPrice = c.Int(nullable: false),
                        GoodImgSrc = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Orders");
        }
    }
}
