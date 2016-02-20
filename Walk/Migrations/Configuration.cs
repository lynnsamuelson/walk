namespace Walk.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Walk.Models.WalkContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Walk.Models.WalkContext context)
        {
            context.Group.AddOrUpdate(
                  p => p.GroupName,
                  new Group() { GroupName = "Test", GroupId = 1, Updated = DateTime.Now }
                );

           

            context.SaveChanges();

            context.Families.AddOrUpdate(
                  p => p.FamilyName,
                  new Family { FamilyName = "Anderson", FamilyId =1, Updated = DateTime.Now }
                );
            context.SaveChanges();


            context.Members.AddOrUpdate(
                 p => p.LastName,
                 new Member
                 {
                     LastName = "Anderson",
                     FirstName = "Bernie",
                     Updated = DateTime.Now,
                     Group = context.Group.Single<Group>(s => s.GroupId == 1),
                     Family = context.Families.Single<Family>(s => s.FamilyId == 1)
                 }
               );
            context.SaveChanges();

            context.Activities.AddOrUpdate(
                 p => p.ActivityName,
                 new Activities
                 {
                     ActivityName = "walking",
                     Date = DateTime.Now,
                     ActivityId = 1,
                     Distance = 2.2d,
                     Participant = context.Members.Single<Member>(s => s.MemberId == 1)
                 }
               );
            context.SaveChanges();

            //context.Activities.AddOrUpdate(
            //     p => p.ActivityName,
            //     new Activities { ActivityName = "run", Distance = 1.1d, Date = DateTime.Now }
            //   );
            //context.SaveChanges();



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
        }
    }
}
