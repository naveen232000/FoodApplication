namespace FoodAppDALLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class addressmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Street = c.String(),
                    City = c.String(nullable: false),
                    State = c.String(),
                    PostalCode = c.String(nullable: false),
                    Country = c.String(),
                    UserId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "UserId", "dbo.Users");
            DropIndex("dbo.Addresses", new[] { "UserId" });
            DropTable("dbo.Addresses");
        }
    }
}
