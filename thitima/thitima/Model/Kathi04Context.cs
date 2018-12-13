using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace thitima.Model
{
    public partial class Kathi04Context : DbContext
    {
        public Kathi04Context()
        {
        }

        public Kathi04Context(DbContextOptions<Kathi04Context> options)
            : base(options)
        {
        }

        public virtual DbSet<TableCustomer> TableCustomer { get; set; }
        public virtual DbSet<TableProduct> TableProduct { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-RSEVAK5\\SQLEXPRESS;Initial Catalog=kathi04;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TableCustomer>(entity =>
            {
                entity.HasKey(e => e.CustId);

                entity.ToTable("Table_Customer");

                entity.Property(e => e.CustId)
                    .HasColumnName("CustID")
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Lastname)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TableProduct>(entity =>
            {
                entity.HasKey(e => e.Code);

                entity.ToTable("Table_Product");

                entity.Property(e => e.Code)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.Name)
                    .HasMaxLength(35)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
