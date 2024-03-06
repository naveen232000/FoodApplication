namespace FoodAppDALLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class restaurentroleidadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurants", "RoleId", c => c.Int(nullable: true));
            CreateIndex("dbo.Restaurants", "RoleId");
            AddForeignKey("dbo.Restaurants", "RoleId", "dbo.Roles", "RoleId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Restaurants", "RoleId", "dbo.Roles");
            DropIndex("dbo.Restaurants", new[] { "RoleId" });
            DropColumn("dbo.Restaurants", "RoleId");
        }
    }
}
