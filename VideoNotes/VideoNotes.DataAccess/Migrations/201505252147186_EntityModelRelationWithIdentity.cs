namespace VideoNotes.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntityModelRelationWithIdentity : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Category", new[] { "ApplicationUser_Id1" });
            DropColumn("dbo.Category", "ApplicationUser_Id");
            RenameColumn(table: "dbo.Category", name: "ApplicationUser_Id1", newName: "ApplicationUser_Id");
            AlterColumn("dbo.Category", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Category", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Category", new[] { "ApplicationUser_Id" });
            AlterColumn("dbo.Category", "ApplicationUser_Id", c => c.String(nullable: false));
            RenameColumn(table: "dbo.Category", name: "ApplicationUser_Id", newName: "ApplicationUser_Id1");
            AddColumn("dbo.Category", "ApplicationUser_Id", c => c.String(nullable: false));
            CreateIndex("dbo.Category", "ApplicationUser_Id1");
        }
    }
}
