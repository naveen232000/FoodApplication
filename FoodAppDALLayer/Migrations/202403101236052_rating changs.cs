namespace FoodAppDALLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ratingchangs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ratings", "FoodId", "dbo.FoodItems");
            DropIndex("dbo.Ratings", new[] { "FoodId" });
            AddColumn("dbo.Ratings", "OrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.Ratings", "OrderId");
            AddForeignKey("dbo.Ratings", "OrderId", "dbo.Orders", "OrderId");
            DropColumn("dbo.Ratings", "FoodId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ratings", "FoodId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Ratings", "OrderId", "dbo.Orders");
            DropIndex("dbo.Ratings", new[] { "OrderId" });
            DropColumn("dbo.Ratings", "OrderId");
            CreateIndex("dbo.Ratings", "FoodId");
            AddForeignKey("dbo.Ratings", "FoodId", "dbo.FoodItems", "FoodId", cascadeDelete: true);
        }
    }
}
