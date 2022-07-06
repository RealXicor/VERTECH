using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VERTECH.Models
{
    public partial class InquiriesDatabaseContext : DbContext
    {
        public InquiriesDatabaseContext()
        {
        }

        public InquiriesDatabaseContext(DbContextOptions<InquiriesDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Inquiry> Inquiries { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local);Database=InquiriesDatabase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Inquiry>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.ProductName)
                    .IsUnicode(false)
                    .HasColumnName("productName");

                entity.Property(e => e.ProductPrice)
                    .IsUnicode(false)
                    .HasColumnName("productPrice");

                entity.Property(e => e.UserEmail)
                    .IsUnicode(false)
                    .HasColumnName("userEmail");

                entity.Property(e => e.UserMsg)
                    .IsUnicode(false)
                    .HasColumnName("userMsg");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
