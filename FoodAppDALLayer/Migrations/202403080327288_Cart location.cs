namespace FoodAppDALLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cartlocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "destinationLatitude", c => c.Double(nullable: false));
            AddColumn("dbo.Carts", "destinationLongitude", c => c.Double(nullable: false));
            DropColumn("dbo.FoodItems", "AvailableQyt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FoodItems", "AvailableQyt", c => c.Int(nullable: false));
            DropColumn("dbo.Carts", "destinationLongitude");
            DropColumn("dbo.Carts", "destinationLatitude");
        }
    }
}
