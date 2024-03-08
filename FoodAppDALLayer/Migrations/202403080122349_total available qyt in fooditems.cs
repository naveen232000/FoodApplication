namespace FoodAppDALLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class totalavailableqytinfooditems : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FoodItems", "AvailableQyt", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FoodItems", "AvailableQyt");
        }
    }
}
