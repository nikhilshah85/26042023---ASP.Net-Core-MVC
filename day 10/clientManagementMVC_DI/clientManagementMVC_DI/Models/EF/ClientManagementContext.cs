using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace clientManagementMVC_DI.Models.EF;

public partial class ClientManagementContext : DbContext
{
    public ClientManagementContext()
    {
    }

    public ClientManagementContext(DbContextOptions<ClientManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ClientInfo> ClientInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;database=clientManagement;integrated security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClientInfo>(entity =>
        {
            entity.HasKey(e => e.Clientid).HasName("PK__clientIn__819DC769405FB009");

            entity.ToTable("clientInfo");

            entity.Property(e => e.Clientid)
                .ValueGeneratedNever()
                .HasColumnName("clientid");
            entity.Property(e => e.ClientIsActive).HasColumnName("clientIsActive");
            entity.Property(e => e.ClientLocation)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("clientLocation");
            entity.Property(e => e.ClientName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("clientName");
            entity.Property(e => e.ProjectValue).HasColumnName("projectValue");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
