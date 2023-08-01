using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace imageuploadapi.Models;

public partial class KaninidbContext : DbContext
{
    public KaninidbContext()
    {
    }

    public KaninidbContext(DbContextOptions<KaninidbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Imagetbl> Imagetbls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=kaninidb;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Imagetbl>(entity =>
        {
            entity.HasKey(e => e.Imgid).HasName("PK__imagetbl__C5B995DEA5D97278");

            entity.ToTable("imagetbl");

            entity.Property(e => e.Imgid).HasColumnName("imgid");
            entity.Property(e => e.Imgname)
                .IsUnicode(false)
                .HasColumnName("imgname");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
