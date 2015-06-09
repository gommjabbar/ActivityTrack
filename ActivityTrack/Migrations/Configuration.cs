using ActivityTrack.DTO;
using ActivityTrack.Models;

namespace ActivityTrack.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ActivityTrack.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ActivityTrack.Models.ApplicationDbContext";
        }

        protected override void Seed(ActivityTrack.Models.ApplicationDbContext context)
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

            ProjectEO p1 = new ProjectEO{Name = "Test1"};
            ProjectEO p2 = new ProjectEO{ Name ="Test2"};

            context.Projects.AddOrUpdate(p1);
            context.Projects.AddOrUpdate(p2);


        }
    }
}
