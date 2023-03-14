using Entities.Concrate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrate.EntityFramework
{
    public class RentACarContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;DataBase=RentACar;Trusted_Connection=true");
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet <Color> Colors { get; set; }
        public DbSet<Brand> Brands { get; set; }
    }
}
