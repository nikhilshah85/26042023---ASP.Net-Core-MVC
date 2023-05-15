using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVC_webapi.Models.EF;

public partial class StockManagementDbContext : DbContext
{
    public StockManagementDbContext()
    {
    }

    public StockManagementDbContext(DbContextOptions<StockManagementDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ClientInfo> ClientInfos { get; set; }

    public virtual DbSet<StcokInfo> StcokInfos { get; set; }

    public virtual DbSet<StockInfo> StockInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=stockManagementDB;integrated security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClientInfo>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("PK__clientIn__81A2CBE15F09E477");

            entity.ToTable("clientInfo");

            entity.Property(e => e.ClientId)
                .ValueGeneratedNever()
                .HasColumnName("clientId");
            entity.Property(e => e.ClientEmail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("clientEmail");
            entity.Property(e => e.ClientName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("clientName");
            entity.Property(e => e.FundsAvailable)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("fundsAvailable");
        });

        modelBuilder.Entity<StcokInfo>(entity =>
        {
            entity.HasKey(e => e.StockId).HasName("PK__StcokInf__CBAD876323346CD5");

            entity.ToTable("StcokInfo");

            entity.Property(e => e.StockId)
                .ValueGeneratedNever()
                .HasColumnName("stockId");
            entity.Property(e => e.StockName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("stockName");
            entity.Property(e => e.StockPrice).HasColumnName("stockPrice");
            entity.Property(e => e.StockQty).HasColumnName("stockQty");
        });

        modelBuilder.Entity<StockInfo>(entity =>
        {
            entity.HasKey(e => e.StockId).HasName("PK__StockInf__CBAD8763C429CFC4");

            entity.ToTable("StockInfo");

            entity.Property(e => e.StockId)
                .ValueGeneratedNever()
                .HasColumnName("stockId");
            entity.Property(e => e.StockName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("stockName");
            entity.Property(e => e.StockPrice).HasColumnName("stockPrice");
            entity.Property(e => e.StockQty).HasColumnName("stockQty");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
