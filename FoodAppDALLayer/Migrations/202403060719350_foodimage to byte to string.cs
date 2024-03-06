namespace FoodAppDALLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foodimagetobytetostring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.FoodItems", "Image", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.FoodItems", "Image", c => c.Binary());
        }
    }
}
