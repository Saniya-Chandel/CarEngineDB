using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CarEngineDB.Models;

public partial class CarDbContext : DbContext
{
    public CarDbContext()
    {
    }

    public CarDbContext(DbContextOptions<CarDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<Engine> Engines { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-TF8BM6A\\SANIYA;Database=CarDB;User ID=sa;Password=user123;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.ToTable("Car");

            entity.Property(e => e.CarId).ValueGeneratedNever();
            entity.Property(e => e.Model)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.Engine).WithMany(p => p.Cars)
                .HasForeignKey(d => d.EngineId)
                .HasConstraintName("FK_Car_Engine");
        });

        modelBuilder.Entity<Engine>(entity =>
        {
            entity.ToTable("Engine");

            entity.Property(e => e.EngineId).ValueGeneratedNever();
            entity.Property(e => e.EngineType)
                .HasMaxLength(150)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
