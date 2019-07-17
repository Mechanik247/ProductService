using ProductService.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ProductService.DAL
{
   public class SchoolContext : DbContext
   {
        public SchoolContext() : base("name=SchoolContext")
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}