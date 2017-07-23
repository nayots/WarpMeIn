using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarpMeIn.Models;

namespace WarpMeIn.Data
{
    public class WarpMeInDBContext : DbContext
    {
        public WarpMeInDBContext(DbContextOptions<WarpMeInDBContext> options) : base(options)
        {
        }

        public DbSet<WarpGate> WarpGates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<WarpGate>().HasKey(pk => pk.Id);
            modelBuilder.Entity<WarpGate>().Property(p => p.Id).ValueGeneratedNever();
            modelBuilder.Entity<WarpGate>().Property(p => p.Id).IsRequired();
            modelBuilder.Entity<WarpGate>().Property(p => p.ANKey).IsRequired();
            modelBuilder.Entity<WarpGate>().Property(p => p.URLFullPath).IsRequired();
            modelBuilder.Entity<WarpGate>().Property(p => p.Enabled).IsRequired().HasDefaultValue(true);
            modelBuilder.Entity<WarpGate>().Property(p => p.WarpCount).HasDefaultValue(0);
        }
    }
}
