using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NTO_2024WPF.data;

public partial class CultureDateBaseContext : DbContext
{
    public CultureDateBaseContext()
    {
    }

    public CultureDateBaseContext(DbContextOptions<CultureDateBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Exhibit> Exhibits { get; set; }

    public virtual DbSet<Space> Spaces { get; set; }

    public virtual DbSet<Studio> Studios { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("data source =.\\DateBase\\CultureDateBase.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Exhibit>(entity =>
        {
            entity.ToTable("Exhibit");

            entity.HasOne(d => d.Studios).WithMany(p => p.Exhibits)
                .HasForeignKey(d => d.StudiosId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.ToTable("Teacher");

            entity.Property(e => e.Fio).HasColumnName("FIO");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
