namespace VideoNotes.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigrationCategoryChanges : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Category", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Category", "UserId", c => c.String());
        }
    }
}
