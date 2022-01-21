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

        public virtual DbSet<Kurs> Kurs { get; set; }
        public virtual DbSet<ListaOcena> ListaOcena { get; set; }
        public virtual DbSet<Ocena> Ocena { get; set; }
        public virtual DbSet<Predmet> Predmet { get; set; }
        public virtual DbSet<Profesor> Profesor { get; set; }
        public virtual DbSet<ProfesorPredajeKurs> ProfesorPredajeKurs { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<StudentSlusaKurs> StudentSlusaKurs { get; set; }

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
            modelBuilder.Entity<ListaOcena>(entity =>
            {
                entity.Property(e => e.IdOcena)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StudentId).HasColumnName("StudentID");
            });

            modelBuilder.Entity<Ocena>(entity =>
            {
                entity.Property(e => e.Datum).HasColumnType("date");

                entity.Property(e => e.Komentar)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.KursId).HasColumnName("KursID");

                entity.Property(e => e.Ocena1).HasColumnName("Ocena");
            });

            modelBuilder.Entity<Predmet>(entity =>
            {
                entity.Property(e => e.Naziv)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Profesor>(entity =>
            {
                entity.Property(e => e.Ime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Prezime)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProfesorPredajeKurs>(entity =>
            {
                entity.Property(e => e.KursId).HasColumnName("KursID");

                entity.Property(e => e.ProfesorId).HasColumnName("ProfesorID");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Jmbg)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Prezime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Prosek).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Telefon)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StudentSlusaKurs>(entity =>
            {
                entity.Property(e => e.KursId).HasColumnName("KursID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
