namespace FoodAppDALLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbcontextchangsorder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            AddColumn("dbo.OrderItems", "Order_OrderId", c => c.Int());
            CreateIndex("dbo.OrderItems", "Order_OrderId");
            AddForeignKey("dbo.OrderItems", "Order_OrderId", "dbo.Orders", "OrderId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "Order_OrderId", "dbo.Orders");
            DropIndex("dbo.OrderItems", new[] { "Order_OrderId" });
            DropColumn("dbo.OrderItems", "Order_OrderId");
            AddForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders", "OrderId", cascadeDelete: true);
        }
    }
}
