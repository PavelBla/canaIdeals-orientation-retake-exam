using Microsoft.EntityFrameworkCore;
using Mountaineering.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mountaineering.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Climber> Climbers { get; set; }
        public DbSet<Mountain> Mountains { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mountain>()
                .HasMany<Climber>(m => m.CurrClimbers)
                .WithOne(c => c.Mountain)
                .HasForeignKey(c => c.MountainId)
                .IsRequired(false);
        }
    }
}
