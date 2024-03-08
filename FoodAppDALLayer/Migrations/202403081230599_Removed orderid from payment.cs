namespace FoodAppDALLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removedorderidfrompayment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Payments", "PaymentId", "dbo.Orders");
            DropIndex("dbo.Payments", new[] { "PaymentId" });
            DropPrimaryKey("dbo.Payments");
            AlterColumn("dbo.Payments", "PaymentId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Payments", "PaymentId");
            CreateIndex("dbo.Orders", "PaymentId");
            AddForeignKey("dbo.Orders", "PaymentId", "dbo.Payments", "PaymentId");
            DropColumn("dbo.Payments", "OrderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Payments", "OrderId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Orders", "PaymentId", "dbo.Payments");
            DropIndex("dbo.Orders", new[] { "PaymentId" });
            DropPrimaryKey("dbo.Payments");
            AlterColumn("dbo.Payments", "PaymentId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Payments", "PaymentId");
            CreateIndex("dbo.Payments", "PaymentId");
            AddForeignKey("dbo.Payments", "PaymentId", "dbo.Orders", "OrderId");
        }
    }
}
