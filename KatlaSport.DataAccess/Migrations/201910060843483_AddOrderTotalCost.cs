namespace KatlaSport.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddOrderTotalCost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.order_records", "order_total_cost", c => c.Decimal(precision: 18, scale: 2));
        }

        public override void Down()
        {
            DropColumn("dbo.order_records", "order_total_cost");
        }
    }
}
