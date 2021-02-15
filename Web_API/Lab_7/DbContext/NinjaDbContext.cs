using Lab_7.Configurations;
using Lab_7.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lab_7.DbContext
{
    public class NinjaDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<NinjaEntity> Ninjas { get; set; }

        public DbSet<NinjaEquipmentEntity> NinjaItems { get; set; }

        public NinjaDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NinjaEntityConfiguration());
            modelBuilder.ApplyConfiguration(new NinjaEquipmentEntityConfiguration());
        }
    }
}
