namespace FoodAppDALLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Addorderandpayment3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                {
                    PaymentId = c.Int(nullable: false, identity: true),
                    PaymentType = c.String(nullable: false),
                    TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    PaymentStatus = c.String(nullable: false, maxLength: 255),
                    Discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                })
                .PrimaryKey(t => t.PaymentId);

            CreateTable(
                "dbo.Orders",
                c => new
                {
                    OrderId = c.Int(nullable: false, identity: true),
                    FoodId = c.Int(nullable: false),
                    UserId = c.Int(nullable: false),
                    Qty = c.Int(nullable: false),
                    TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    DeliveryAddress = c.String(nullable: false),
                    DeliveryCharge = c.Decimal(nullable: false, precision: 18, scale: 2),
                    OrderStatus = c.String(nullable: false),
                    PaymentId = c.Int(nullable: false),
                    EstimatedDeliveryTime = c.DateTime(nullable: false),
                    DateOfOrder = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.FoodItems", t => t.FoodId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Payments", t => t.PaymentId, cascadeDelete: true)
                .Index(t => t.FoodId)
                .Index(t => t.UserId)
                .Index(t => t.PaymentId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Orders", "PaymentId", "dbo.Payments");
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "FoodId", "dbo.FoodItems");
            DropIndex("dbo.Orders", new[] { "PaymentId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.Orders", new[] { "FoodId" });
            DropTable("dbo.Orders");
            DropTable("dbo.Payments");
        }
    }

}
