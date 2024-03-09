namespace FoodAppDALLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRatingfoodid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ratings", "FoodId", c => c.Int(nullable: false));
            CreateIndex("dbo.Ratings", "FoodId");
            AddForeignKey("dbo.Ratings", "FoodId", "dbo.FoodItems", "FoodId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "FoodId", "dbo.FoodItems");
            DropIndex("dbo.Ratings", new[] { "FoodId" });
            DropColumn("dbo.Ratings", "FoodId");
        }
    }
}
