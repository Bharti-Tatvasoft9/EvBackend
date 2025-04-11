using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using EVAPI.Models;
namespace EVAPI.Data;

public partial class NeondbContext : DbContext
{
    public NeondbContext()
    {
    }

    public NeondbContext(DbContextOptions<NeondbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Evmachine> Evmachines { get; set; }

    //public virtual DbSet<Station> Stations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Evmachine>(entity =>
        {
            entity.HasKey(e => e.Machineid).HasName("evmachine_pkey");

            entity.ToTable("evmachine");

            entity.Property(e => e.Machineid)
                .ValueGeneratedNever()
                .HasColumnName("machineid");
            entity.Property(e => e.Machinename)
                .HasMaxLength(100)
                .HasColumnName("machinename");
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
