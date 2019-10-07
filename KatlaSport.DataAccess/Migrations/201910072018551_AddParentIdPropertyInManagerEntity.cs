namespace KatlaSport.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddParentIdPropertyInManagerEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.managers", "manager_parent_id", c => c.Int());
        }

        public override void Down()
        {
            DropColumn("dbo.managers", "manager_parent_id");
        }
    }
}
