namespace FoodAppDALLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedlatandlonginaddrs : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "Latitude", c => c.Double(nullable: false));
            AddColumn("dbo.Addresses", "Longitude", c => c.Double(nullable: false));
            AlterColumn("dbo.Ratings", "Comments", c => c.String(nullable: false, maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ratings", "Comments", c => c.String(nullable: false));
            DropColumn("dbo.Addresses", "Longitude");
            DropColumn("dbo.Addresses", "Latitude");
        }
    }
}
