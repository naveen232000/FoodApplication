namespace FoodAppDALLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class paymentstatusstring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Payments", "PaymentStatus", c => c.String(nullable: false, maxLength: 255));
            DropColumn("dbo.Payments", "CouponCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Payments", "CouponCode", c => c.String());
            AlterColumn("dbo.Payments", "PaymentStatus", c => c.Int(nullable: false));
        }
    }
}
