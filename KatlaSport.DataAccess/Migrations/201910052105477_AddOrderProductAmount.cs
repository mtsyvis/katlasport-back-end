using System.Data.Entity.Migrations;

namespace KatlaSport.DataAccess.Migrations
{
    public partial class AddOrderProductAmount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.order_records", "order_product_amount", c => c.Int(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.order_records", "order_product_amount");
        }
    }
}
