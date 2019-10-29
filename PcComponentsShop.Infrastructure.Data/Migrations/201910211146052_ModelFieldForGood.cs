namespace PcComponentsShop.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelFieldForGood : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ComputerCases", "Model", c => c.String(nullable: false));
            AddColumn("dbo.MemoryModules", "Model", c => c.String(nullable: false));
            AddColumn("dbo.Motherboards", "Model", c => c.String(nullable: false));
            AddColumn("dbo.PowerSupplies", "Model", c => c.String(nullable: false));
            AddColumn("dbo.Processors", "Model", c => c.String(nullable: false));
            AddColumn("dbo.SSDDrives", "Model", c => c.String(nullable: false));
            AddColumn("dbo.VideoCards", "Model", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VideoCards", "Model");
            DropColumn("dbo.SSDDrives", "Model");
            DropColumn("dbo.Processors", "Model");
            DropColumn("dbo.PowerSupplies", "Model");
            DropColumn("dbo.Motherboards", "Model");
            DropColumn("dbo.MemoryModules", "Model");
            DropColumn("dbo.ComputerCases", "Model");
        }
    }
}
