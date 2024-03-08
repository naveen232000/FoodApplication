namespace FoodAppDALLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedpaymentmodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "PaymentId", "dbo.Payments");
            DropIndex("dbo.Orders", new[] { "PaymentId" });
            AddColumn("dbo.Orders", "PaymentType", c => c.String(nullable: false));
            AddColumn("dbo.Orders", "PaymentStatus", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Orders", "Discount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Orders", "PaymentId");
            DropTable("dbo.Payments");
        }
        
        public override void Down()
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
            
            AddColumn("dbo.Orders", "PaymentId", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "Discount");
            DropColumn("dbo.Orders", "PaymentStatus");
            DropColumn("dbo.Orders", "PaymentType");
            CreateIndex("dbo.Orders", "PaymentId");
            AddForeignKey("dbo.Orders", "PaymentId", "dbo.Payments", "PaymentId", cascadeDelete: true);
        }
    }
}
