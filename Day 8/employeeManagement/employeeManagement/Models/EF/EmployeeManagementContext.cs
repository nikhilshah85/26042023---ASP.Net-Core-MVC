using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace employeeManagement.Models.EF;

public partial class EmployeeManagementContext : DbContext
{
    public EmployeeManagementContext()
    {
    }

    public EmployeeManagementContext(DbContextOptions<EmployeeManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DeptInfo> DeptInfos { get; set; }

    public virtual DbSet<EmpInfo> EmpInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=employeeManagement;integrated security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DeptInfo>(entity =>
        {
            entity.HasKey(e => e.DeptNo).HasName("PK__deptInfo__BE2D3F557DF09E62");

            entity.ToTable("deptInfo");

            entity.HasIndex(e => e.DeptName, "unk_deptName").IsUnique();

            entity.Property(e => e.DeptNo)
                .ValueGeneratedNever()
                .HasColumnName("deptNo");
            entity.Property(e => e.DeptCity)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("deptCity");
            entity.Property(e => e.DeptName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("deptName");
        });

        modelBuilder.Entity<EmpInfo>(entity =>
        {
            entity.HasKey(e => e.EmpNo).HasName("PK__empInfo__AFB335925C9E6F13");

            entity.ToTable("empInfo");

            entity.Property(e => e.EmpNo)
                .ValueGeneratedNever()
                .HasColumnName("empNo");
            entity.Property(e => e.EmpDeptNo).HasColumnName("empDeptNo");
            entity.Property(e => e.EmpDesignation)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("empDesignation");
            entity.Property(e => e.EmpIsPermenant).HasColumnName("empIsPermenant");
            entity.Property(e => e.EmpName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("empName");
            entity.Property(e => e.EmpSalary).HasColumnName("empSalary");

            entity.HasOne(d => d.EmpDeptNoNavigation).WithMany(p => p.EmpInfos)
                .HasForeignKey(d => d.EmpDeptNo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_empDeptNo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
