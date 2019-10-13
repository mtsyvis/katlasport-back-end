namespace KatlaSport.DataAccess.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddPhotoUrlPropertyToManagerEntite : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.managers", "deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.managers", "manager_photo_url", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.managers", "manager_photo_url");
            DropColumn("dbo.managers", "deleted");
        }
    }
}
