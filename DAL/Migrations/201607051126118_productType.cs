namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductTypes",
                c => new
                    {
                        ProductTypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductTypeID);
            
            AddColumn("dbo.Products", "ProductTypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "ProductTypeID");
            AddForeignKey("dbo.Products", "ProductTypeID", "dbo.ProductTypes", "ProductTypeID", cascadeDelete: true);
            //DropColumn("dbo.Products", "ProductType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "ProductType", c => c.Int());
            DropForeignKey("dbo.Products", "ProductTypeID", "dbo.ProductTypes");
            DropIndex("dbo.Products", new[] { "ProductTypeID" });
            DropColumn("dbo.Products", "ProductTypeID");
            DropTable("dbo.ProductTypes");
        }
    }
}
