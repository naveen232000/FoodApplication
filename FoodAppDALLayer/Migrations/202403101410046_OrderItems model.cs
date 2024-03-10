namespace FoodAppDALLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderItemsmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        OrderItemId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        FoodId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderItemId)
                .ForeignKey("dbo.FoodItems", t => t.FoodId)
                .ForeignKey("dbo.Orders", t => t.OrderId)
                .Index(t => t.OrderId)
                .Index(t => t.FoodId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderItems", "FoodId", "dbo.FoodItems");
            DropIndex("dbo.OrderItems", new[] { "FoodId" });
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            DropTable("dbo.OrderItems");
        }
    }
}
