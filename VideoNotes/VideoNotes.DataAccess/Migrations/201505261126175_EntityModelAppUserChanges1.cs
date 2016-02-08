namespace VideoNotes.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntityModelAppUserChanges1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Category", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Category", new[] { "ApplicationUser_Id" });
            RenameColumn(table: "dbo.Category", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            AlterColumn("dbo.Category", "ApplicationUserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Category", "ApplicationUserId");
            AddForeignKey("dbo.Category", "ApplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Category", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Category", new[] { "ApplicationUserId" });
            AlterColumn("dbo.Category", "ApplicationUserId", c => c.String(maxLength: 128));
            RenameColumn(table: "dbo.Category", name: "ApplicationUserId", newName: "ApplicationUser_Id");
            CreateIndex("dbo.Category", "ApplicationUser_Id");
            AddForeignKey("dbo.Category", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
