using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MartialArtsSchool.Models;

public partial class MarArtDbContext : DbContext
{
    public MarArtDbContext()
    {
    }

    public MarArtDbContext(DbContextOptions<MarArtDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Lesson> Lessons { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-ROR0S5F\\MSSQLSERVER01;Database=MarArtDb;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.HasKey(e => e.IdLesson).HasName("Lesson_pk");

            entity.ToTable("Lesson");

            entity.Property(e => e.IdLesson)
                .ValueGeneratedNever()
                .HasColumnName("id_lesson");
            entity.Property(e => e.Description)
                .HasMaxLength(600)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.IdMemeber).HasName("Member_pk");

            entity.ToTable("Member");

            entity.Property(e => e.IdMemeber)
                .ValueGeneratedNever()
                .HasColumnName("id_memeber");
            entity.Property(e => e.BirthDate)
                .HasColumnType("date")
                .HasColumnName("birth_date");
            entity.Property(e => e.FirstName)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("last_name");

            entity.HasMany(d => d.IdLessons).WithMany(p => p.IdMemebers)
                .UsingEntity<Dictionary<string, object>>(
                    "Zapi",
                    r => r.HasOne<Lesson>().WithMany()
                        .HasForeignKey("IdLesson")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Zapis_Lesson"),
                    l => l.HasOne<Member>().WithMany()
                        .HasForeignKey("IdMemeber")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("Zapis_Member"),
                    j =>
                    {
                        j.HasKey("IdMemeber", "IdLesson").HasName("Zapis_pk");
                        j.ToTable("Zapis");
                        j.IndexerProperty<int>("IdMemeber").HasColumnName("id_memeber");
                        j.IndexerProperty<int>("IdLesson").HasColumnName("id_lesson");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
