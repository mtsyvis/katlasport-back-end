namespace KatlaSport.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddRelationsInManagerEntity : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.managers", "manager_parent_id");
            AddForeignKey("dbo.managers", "manager_parent_id", "dbo.managers", "manager_id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.managers", "manager_parent_id", "dbo.managers");
            DropIndex("dbo.managers", new[] { "manager_parent_id" });
        }
    }
}
