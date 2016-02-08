namespace VideoNotes.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NoteEntytiShareFieldAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Note", "Share", c => c.Boolean(nullable: false));
            DropColumn("dbo.Video", "Share");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Video", "Share", c => c.Boolean(nullable: false));
            DropColumn("dbo.Note", "Share");
        }
    }
}
