namespace FoodAppDALLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class virtualremovedrating : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ratings", "OrderId", "dbo.Orders");
            DropIndex("dbo.Ratings", new[] { "OrderId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Ratings", "OrderId");
            AddForeignKey("dbo.Ratings", "OrderId", "dbo.Orders", "OrderId", cascadeDelete: true);
        }
    }
}
