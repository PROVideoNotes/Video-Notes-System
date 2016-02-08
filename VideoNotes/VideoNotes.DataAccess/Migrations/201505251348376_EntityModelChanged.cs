namespace VideoNotes.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntityModelChanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CategoryVideo", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.CategoryVideo", "VideoId", "dbo.Video");
            DropIndex("dbo.CategoryVideo", new[] { "CategoryId" });
            DropIndex("dbo.CategoryVideo", new[] { "VideoId" });
            AddColumn("dbo.Video", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Video", "CategoryId");
            AddForeignKey("dbo.Video", "CategoryId", "dbo.Category", "CategoryId", cascadeDelete: true);
            DropTable("dbo.CategoryVideo");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CategoryVideo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        VideoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Video", "CategoryId", "dbo.Category");
            DropIndex("dbo.Video", new[] { "CategoryId" });
            DropColumn("dbo.Video", "CategoryId");
            CreateIndex("dbo.CategoryVideo", "VideoId");
            CreateIndex("dbo.CategoryVideo", "CategoryId");
            AddForeignKey("dbo.CategoryVideo", "VideoId", "dbo.Video", "VideoId", cascadeDelete: true);
            AddForeignKey("dbo.CategoryVideo", "CategoryId", "dbo.Category", "CategoryId", cascadeDelete: true);
        }
    }
}
