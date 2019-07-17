namespace ProductService.Migrations
{
    using ProductService.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductService.DAL.SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProductService.DAL.SchoolContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var students = new List<Student>
            {
                new Student { FirstMidName = "Carson",   LastName = "Alexander",
                     },
                new Student { FirstMidName = "Meredith", LastName = "Alonso",
                    },
                new Student { FirstMidName = "Arturo",   LastName = "Anand",
                     },
                new Student { FirstMidName = "Gytis",    LastName = "Barzdukas",
                    },
                new Student { FirstMidName = "Yan",      LastName = "Li",
                     },
                new Student { FirstMidName = "Peggy",    LastName = "Justice",
                    },
                new Student { FirstMidName = "Laura",    LastName = "Norman",
                     },
                new Student { FirstMidName = "Nino",     LastName = "Olivetto",
                   }
            };


            students.ForEach(s => context.Students.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();
        }
    }
}
