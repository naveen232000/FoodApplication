namespace FoodAppDALLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartId = c.Int(nullable: false, identity: true),
                        FoodId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        RestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CartId)
                .ForeignKey("dbo.FoodItems", t => t.FoodId)
                .ForeignKey("dbo.Restaurants", t => t.RestId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.FoodId)
                .Index(t => t.UserId)
                .Index(t => t.RestId);
            
            CreateTable(
                "dbo.FoodItems",
                c => new
                    {
                        FoodId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Image = c.Binary(),
                        Description = c.String(maxLength: 500),
                        RestId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Availability = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FoodId)
                .ForeignKey("dbo.Restaurants", t => t.RestId, cascadeDelete: true)
                .Index(t => t.RestId);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        RestId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Address = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Mobile = c.String(nullable: false),
                        Qty = c.String(nullable: false),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.RestId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        Mobile = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Role = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .Index(t => t.UserName, unique: true)
                .Index(t => t.Email, unique: true);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        FoodId = c.Int(nullable: false),
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
                .Index(t => t.FoodId);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        PaymentId = c.Int(nullable: false),
                        PaymentType = c.String(nullable: false),
                        RestId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PaymentStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentId)
                .ForeignKey("dbo.Restaurants", t => t.RestId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.PaymentId)
                .Index(t => t.PaymentId)
                .Index(t => t.RestId);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        RatingId = c.Int(nullable: false, identity: true),
                        FoodId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Like = c.Boolean(nullable: false),
                        Comments = c.String(nullable: false),
                        RatingCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RatingId)
                .ForeignKey("dbo.FoodItems", t => t.FoodId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.FoodId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "UserId", "dbo.Users");
            DropForeignKey("dbo.Ratings", "FoodId", "dbo.FoodItems");
            DropForeignKey("dbo.Payments", "PaymentId", "dbo.Orders");
            DropForeignKey("dbo.Payments", "RestId", "dbo.Restaurants");
            DropForeignKey("dbo.Orders", "FoodId", "dbo.FoodItems");
            DropForeignKey("dbo.Carts", "UserId", "dbo.Users");
            DropForeignKey("dbo.Carts", "RestId", "dbo.Restaurants");
            DropForeignKey("dbo.Carts", "FoodId", "dbo.FoodItems");
            DropForeignKey("dbo.FoodItems", "RestId", "dbo.Restaurants");
            DropIndex("dbo.Ratings", new[] { "UserId" });
            DropIndex("dbo.Ratings", new[] { "FoodId" });
            DropIndex("dbo.Payments", new[] { "RestId" });
            DropIndex("dbo.Payments", new[] { "PaymentId" });
            DropIndex("dbo.Orders", new[] { "FoodId" });
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.Users", new[] { "UserName" });
            DropIndex("dbo.FoodItems", new[] { "RestId" });
            DropIndex("dbo.Carts", new[] { "RestId" });
            DropIndex("dbo.Carts", new[] { "UserId" });
            DropIndex("dbo.Carts", new[] { "FoodId" });
            DropTable("dbo.Ratings");
            DropTable("dbo.Payments");
            DropTable("dbo.Orders");
            DropTable("dbo.Users");
            DropTable("dbo.Restaurants");
            DropTable("dbo.FoodItems");
            DropTable("dbo.Carts");
        }
    }
}
