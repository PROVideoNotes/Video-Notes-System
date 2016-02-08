namespace VideoNotes.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Gategory_name_maxlen_changed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Category", "Name", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Category", "Name", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
