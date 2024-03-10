namespace FoodAppDALLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adminpassword : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Admins", "Password", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Admins", "Password", c => c.String(nullable: false));
        }
    }
}
