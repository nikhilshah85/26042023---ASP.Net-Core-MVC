using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace bankingSolution.Models.EF;

public partial class BankingDbContext : DbContext
{
    public BankingDbContext()
    {
    }

    public BankingDbContext(DbContextOptions<BankingDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccountsInfo> AccountsInfos { get; set; }

    public virtual DbSet<BranchInfo> BranchInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB; database=bankingDB; integrated security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountsInfo>(entity =>
        {
            entity.HasKey(e => e.AccNo).HasName("PK__Accounts__A4719705F37F4B6A");

            entity.ToTable("AccountsInfo");

            entity.Property(e => e.AccNo)
                .ValueGeneratedNever()
                .HasColumnName("accNo");
            entity.Property(e => e.AccBalance).HasColumnName("accBalance");
            entity.Property(e => e.AccIsActive).HasColumnName("accIsActive");
            entity.Property(e => e.AccLastName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("accLastName");
            entity.Property(e => e.AccName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("accName");
            entity.Property(e => e.AccType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("accType");
        });

        modelBuilder.Entity<BranchInfo>(entity =>
        {
            entity.HasKey(e => e.BrNo).HasName("PK__branchIn__52F63AE453B0C445");

            entity.ToTable("branchInfo");

            entity.Property(e => e.BrNo)
                .ValueGeneratedNever()
                .HasColumnName("brNo");
            entity.Property(e => e.BrCity)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("brCity");
            entity.Property(e => e.BrName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("brName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
