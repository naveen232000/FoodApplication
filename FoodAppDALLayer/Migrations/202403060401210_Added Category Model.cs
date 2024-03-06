namespace FoodAppDALLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCategoryModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.CategoryId)
                .Index(t => t.CategoryName, unique: true);
            
            AddColumn("dbo.FoodItems", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Restaurants", "City", c => c.String());
            CreateIndex("dbo.FoodItems", "CategoryId");
            AddForeignKey("dbo.FoodItems", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FoodItems", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Categories", new[] { "CategoryName" });
            DropIndex("dbo.FoodItems", new[] { "CategoryId" });
            DropColumn("dbo.Restaurants", "City");
            DropColumn("dbo.FoodItems", "CategoryId");
            DropTable("dbo.Categories");
        }
    }
}
