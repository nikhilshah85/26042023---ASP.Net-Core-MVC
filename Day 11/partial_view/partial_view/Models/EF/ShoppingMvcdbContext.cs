using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace partial_view.Models.EF;

public partial class ShoppingMvcdbContext : DbContext
{
    public ShoppingMvcdbContext()
    {
    }

    public ShoppingMvcdbContext(DbContextOptions<ShoppingMvcdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<HolidayProduct> HolidayProducts { get; set; }

    public virtual DbSet<KidsProduct> KidsProducts { get; set; }

    public virtual DbSet<MensProduct> MensProducts { get; set; }

    public virtual DbSet<WomensProduct> WomensProducts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=shoppingMVCDB;integrated security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HolidayProduct>(entity =>
        {
            entity.HasKey(e => e.PId).HasName("PK__Holiday___DD36D5626D02C0F6");

            entity.ToTable("Holiday_Product");

            entity.Property(e => e.PId)
                .ValueGeneratedNever()
                .HasColumnName("pId");
            entity.Property(e => e.PCategory)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pCategory");
            entity.Property(e => e.PIsInStock).HasColumnName("pIsInStock");
            entity.Property(e => e.PName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pName");
            entity.Property(e => e.PPrice).HasColumnName("pPrice");
        });

        modelBuilder.Entity<KidsProduct>(entity =>
        {
            entity.HasKey(e => e.PId).HasName("PK__Kids_Pro__DD36D562280021E6");

            entity.ToTable("Kids_Product");

            entity.Property(e => e.PId)
                .ValueGeneratedNever()
                .HasColumnName("pId");
            entity.Property(e => e.PCategory)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pCategory");
            entity.Property(e => e.PIsInStock).HasColumnName("pIsInStock");
            entity.Property(e => e.PName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pName");
            entity.Property(e => e.PPrice).HasColumnName("pPrice");
        });

        modelBuilder.Entity<MensProduct>(entity =>
        {
            entity.HasKey(e => e.PId).HasName("PK__Mens_Pro__DD36D562D83C5B39");

            entity.ToTable("Mens_Product");

            entity.Property(e => e.PId)
                .ValueGeneratedNever()
                .HasColumnName("pId");
            entity.Property(e => e.PCategory)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pCategory");
            entity.Property(e => e.PIsInStock).HasColumnName("pIsInStock");
            entity.Property(e => e.PName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pName");
            entity.Property(e => e.PPrice).HasColumnName("pPrice");
        });

        modelBuilder.Entity<WomensProduct>(entity =>
        {
            entity.HasKey(e => e.PId).HasName("PK__Womens_P__DD36D5620FE14709");

            entity.ToTable("Womens_Product");

            entity.Property(e => e.PId)
                .ValueGeneratedNever()
                .HasColumnName("pId");
            entity.Property(e => e.PCategory)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pCategory");
            entity.Property(e => e.PIsInStock).HasColumnName("pIsInStock");
            entity.Property(e => e.PName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pName");
            entity.Property(e => e.PPrice).HasColumnName("pPrice");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
