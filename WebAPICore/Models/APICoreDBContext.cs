using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPICore.Models
{
    public partial class APICoreDBContext : DbContext
    {
        public APICoreDBContext()
        {
        }

        public APICoreDBContext(DbContextOptions<APICoreDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Mark> Mark { get; set; }
        public virtual DbSet<MarkList> MarkList { get; set; }
        public virtual DbSet<Professor> Professor { get; set; }
        public virtual DbSet<ProfessorTeachCourse> ProfessorTeachCourse { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentAttendCourse> StudentAttendCourse { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=94.228.237.14\\SQL2017; Database=APICoreDB; User ID=MarkoDB;Password=Test12358;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mark>(entity =>
            {
                entity.Property(e => e.Comment)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Mark1).HasColumnName("Mark");
            });

            modelBuilder.Entity<MarkList>(entity =>
            {
                entity.Property(e => e.MarkId)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Professor>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.AverageRating).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Pin)
                    .HasColumnName("PIN")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
