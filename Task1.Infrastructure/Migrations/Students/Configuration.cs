namespace Task1.Infrastructure.Migrations.Students
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Task1.Core;
    using Task1.Core.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<Task1.Infrastructure.Data.DataAccess.StudentsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"Migrations\Students";
        }

        protected override void Seed(Task1.Infrastructure.Data.DataAccess.StudentsContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.Courses.AddOrUpdate(
              c => c.Name,
              new Course { Name = "Data Structures and Algorithms" },
              new Course { Name = "Programming with C#" },
              new Course { Name = "Distributed Systems" }
            );
        }
    }
}
