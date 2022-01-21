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

        public virtual DbSet<Predmet> Predmet { get; set; }

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

            modelBuilder.Entity<Predmet>(entity =>
            {
                entity.Property(e => e.Naziv)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Tip)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
