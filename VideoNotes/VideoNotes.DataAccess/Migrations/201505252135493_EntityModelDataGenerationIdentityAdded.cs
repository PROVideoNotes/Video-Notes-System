namespace VideoNotes.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntityModelDataGenerationIdentityAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Category", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Category", new[] { "ApplicationUser_Id" });
            AddColumn("dbo.Category", "ApplicationUser_Id1", c => c.String(maxLength: 128));
            AlterColumn("dbo.Category", "ApplicationUser_Id", c => c.String(nullable: false));
            CreateIndex("dbo.Category", "ApplicationUser_Id1");
            AddForeignKey("dbo.Category", "ApplicationUser_Id1", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Category", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropIndex("dbo.Category", new[] { "ApplicationUser_Id1" });
            AlterColumn("dbo.Category", "ApplicationUser_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Category", "ApplicationUser_Id1");
            CreateIndex("dbo.Category", "ApplicationUser_Id");
            AddForeignKey("dbo.Category", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
