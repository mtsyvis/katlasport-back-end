namespace KatlaSport.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddEntitiesInFieldOfTrade : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.order_product_item",
                c => new
                    {
                        order_product_item_order_id = c.Int(nullable: false),
                        order_product_item_product_id = c.Int(nullable: false),
                        order_product_item_amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.order_product_item_order_id, t.order_product_item_product_id })
                .ForeignKey("dbo.product_store_items", t => t.order_product_item_product_id, cascadeDelete: true)
                .ForeignKey("dbo.order_records", t => t.order_product_item_order_id, cascadeDelete: true)
                .Index(t => t.order_product_item_order_id)
                .Index(t => t.order_product_item_product_id);

            CreateTable(
                "dbo.order_records",
                c => new
                    {
                        order_id = c.Int(nullable: false, identity: true),
                        order_date = c.DateTime(nullable: false),
                        order_total_cost = c.Decimal(precision: 18, scale: 2),
                        order_description = c.String(maxLength: 300),
                        order_customer_id = c.Int(nullable: false),
                        order_status_id = c.Int(nullable: false),
                        order_manager_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.order_id)
                .ForeignKey("dbo.customer_records", t => t.order_customer_id, cascadeDelete: true)
                .ForeignKey("dbo.managers", t => t.order_manager_id, cascadeDelete: true)
                .ForeignKey("dbo.order_statuses", t => t.order_status_id, cascadeDelete: true)
                .Index(t => t.order_customer_id)
                .Index(t => t.order_status_id)
                .Index(t => t.order_manager_id);

            CreateTable(
                "dbo.managers",
                c => new
                    {
                        manager_id = c.Int(nullable: false, identity: true),
                        manager_name = c.String(nullable: false, maxLength: 300),
                        manager_phone = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.manager_id);

            CreateTable(
                "dbo.order_statuses",
                c => new
                    {
                        order_status_id = c.Int(nullable: false, identity: true),
                        order_status_name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.order_status_id);
        }

        public override void Down()
        {
            DropForeignKey("dbo.order_product_item", "order_product_item_order_id", "dbo.order_records");
            DropForeignKey("dbo.order_records", "order_status_id", "dbo.order_statuses");
            DropForeignKey("dbo.order_records", "order_manager_id", "dbo.managers");
            DropForeignKey("dbo.order_records", "order_customer_id", "dbo.customer_records");
            DropForeignKey("dbo.order_product_item", "order_product_item_product_id", "dbo.product_store_items");
            DropIndex("dbo.order_records", new[] { "order_manager_id" });
            DropIndex("dbo.order_records", new[] { "order_status_id" });
            DropIndex("dbo.order_records", new[] { "order_customer_id" });
            DropIndex("dbo.order_product_item", new[] { "order_product_item_product_id" });
            DropIndex("dbo.order_product_item", new[] { "order_product_item_order_id" });
            DropTable("dbo.order_statuses");
            DropTable("dbo.managers");
            DropTable("dbo.order_records");
            DropTable("dbo.order_product_item");
        }
    }
}
