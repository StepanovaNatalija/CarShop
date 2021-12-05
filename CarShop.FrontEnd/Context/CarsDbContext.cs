using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarShop.Library;

namespace CarShop.Frontend.Context
{
    
    public class CarsDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlServer(@"Server=LAPTOP-20BVNTSH\SQLEXPRESS; Database=CarsDB; Trusted_Connection=True;");
    }
}
