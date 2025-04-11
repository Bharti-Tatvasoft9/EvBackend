
using EVAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EVAPI.Data
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public virtual DbSet<EVMachine> Machines { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EVMachine>(entity =>
            {
                entity.HasKey(e => e.MachineId).HasName("PRIMARY");

                entity.ToTable("EVMachine");

                entity.HasIndex(e => e.StationId, "StationId");

                entity.Property(e => e.MachineId).HasColumnType("int(11)");
                entity.Property(e => e.MachineName).HasMaxLength(100);
                entity.Property(e => e.StationId).HasColumnType("int(11)");

            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
