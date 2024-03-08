namespace FoodAppDALLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Discountaddedonpayment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Payments", "Discount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Payments", "Discount");
        }
    }
}
