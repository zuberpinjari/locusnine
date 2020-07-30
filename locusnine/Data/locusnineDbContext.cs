using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using locusnine.Models;

namespace locusnine.Data
{
    public class locusnineDbContext : DbContext
    {
        public locusnineDbContext(DbContextOptions<locusnineDbContext> options)
            : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Telling EF to use Id as identity
            modelBuilder.Entity<Users>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
        }
    }
}
