using System;
using System.Collections.Generic;
using Eve.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eve.Core.Context;

public partial class EveContext : DbContext
{
    public EveContext()
    {
    }

    public EveContext(DbContextOptions<EveContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserLogin> UserLogins { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=SNT-MED0949\\SQLEXPRESS;Database=Eve;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserLogin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserLogi__3214EC07EB961BFA");

            entity.ToTable("UserLogin");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Pass)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
