using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAppMVC.Models
{
    public partial class GuestBookDBFirstContext : DbContext
    {
        public GuestBookDBFirstContext()
        {
        }

        public GuestBookDBFirstContext(DbContextOptions<GuestBookDBFirstContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GuestBook> GuestBook { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=.\\MSSQLSERVER2014; Database=GuestBookDBFirst; User ID=sa; Password=P@ssw0rd; Trusted_Connection=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuestBook>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Message).HasColumnType("text");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
