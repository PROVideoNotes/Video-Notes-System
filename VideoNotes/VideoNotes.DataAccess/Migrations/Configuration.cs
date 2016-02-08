namespace VideoNotes.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using VideoNotes.Core.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<VideoNotes.DataAccess.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(VideoNotes.DataAccess.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //context.Category.Add(new Category
            //{
            //    ApplicationUserId = "ee3014b1-bce5-46ff-aca4-652aa8a72a25",
            //    Name = "Finki",
            //});

            //context.Category.Add(new Category
            //{
            //    ApplicationUserId = "ee3014b1-bce5-46ff-aca4-652aa8a72a25",
            //    Name = "Feit",
            //});
          
        }
    }
}
