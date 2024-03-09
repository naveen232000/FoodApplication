namespace FoodAppDALLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class validationUpdated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ratings", "FoodId", "dbo.FoodItems");
            DropIndex("dbo.Ratings", new[] { "FoodId" });
            AlterColumn("dbo.Addresses", "Street", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Addresses", "City", c => c.String(nullable: false, maxLength: 75));
            AlterColumn("dbo.Addresses", "State", c => c.String(nullable: false, maxLength: 75));
            AlterColumn("dbo.Addresses", "Country", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Restaurants", "Name", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Restaurants", "City", c => c.String(nullable: false));
            DropColumn("dbo.Ratings", "FoodId");
            DropColumn("dbo.Ratings", "Like");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ratings", "Like", c => c.Boolean(nullable: false));
            AddColumn("dbo.Ratings", "FoodId", c => c.Int(nullable: false));
            AlterColumn("dbo.Restaurants", "City", c => c.String());
            AlterColumn("dbo.Restaurants", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Admins", "FirstName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Addresses", "Country", c => c.String());
            AlterColumn("dbo.Addresses", "State", c => c.String());
            AlterColumn("dbo.Addresses", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Addresses", "Street", c => c.String());
            CreateIndex("dbo.Ratings", "FoodId");
            AddForeignKey("dbo.Ratings", "FoodId", "dbo.FoodItems", "FoodId", cascadeDelete: true);
        }
    }
}
