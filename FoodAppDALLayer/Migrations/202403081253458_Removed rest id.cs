namespace FoodAppDALLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removedrestid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Payments", "RestId", "dbo.Restaurants");
            DropIndex("dbo.Payments", new[] { "RestId" });
            DropColumn("dbo.Payments", "RestId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Payments", "RestId", c => c.Int(nullable: false));
            CreateIndex("dbo.Payments", "RestId");
            AddForeignKey("dbo.Payments", "RestId", "dbo.Restaurants", "RestId", cascadeDelete: true);
        }
    }
}
