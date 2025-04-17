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
    public virtual DbSet<ChargingEvent> Chargingevents { get; set; }

    public virtual DbSet<Station> Stations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Evmachine>(entity =>
        {
            entity.HasKey(e => e.Machineid).HasName("evmachine_pkey") ;

            entity.ToTable("evmachine");

            entity.Property(e => e.Machineid)
                .ValueGeneratedOnAdd()
                .HasColumnName("machineid");
            entity.Property(e => e.Machinename)
                .HasMaxLength(100)
                .HasColumnName("machinename");
            entity.Property(e => e.Stationid).HasColumnName("stationid");
                              });

        modelBuilder.Entity<ChargingEvent>(entity =>
        {
            entity.HasNoKey();

            entity.ToTable("chargingevent");
            entity.Property(e => e.Machineid).HasColumnName("machineid");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .HasColumnName("status");
            entity.Property(e => e.Timestamp).HasColumnName("timestamp");
        });

        modelBuilder.Entity<Station>(entity =>
        {
            entity.HasKey(e => e.Stationid).HasName("station_pkey");

            entity.ToTable("station");

            entity.Property(e => e.Stationid)
                .ValueGeneratedOnAdd()
                .HasColumnName("stationid");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .HasColumnName("address");
            entity.Property(e => e.Contactnumber)
                .HasMaxLength(15)
                .HasColumnName("contactnumber");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Stationname)
                .HasMaxLength(100)
                .HasColumnName("stationname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
