using Microsoft.EntityFrameworkCore;
using Shortly_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shortly_Data
{
    public class AppDbContext : DbContext
    {
        ////create the constructor and inject the dbcontext options as parameter
        //
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        //Define tables

        public DbSet<Url> Urls { get; set; }

        public DbSet<User> Users { get; set; }
      
    }
}
