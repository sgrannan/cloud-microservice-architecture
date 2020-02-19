using System;
using CustomerService.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CustomerService.Data
{
    public partial class CustomerContext : DbContext
    {
        public CustomerContext()
        {
        }

        public CustomerContext(DbContextOptions<CustomerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Addresses>(entity =>
            {
                entity.HasKey(e => e.AddressId)
                    .HasName("address_id");

                entity.Property(e => e.AddressId)
                    .HasColumnName("address_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AddressLine1)
                    .HasColumnName("address_line1")
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine2)
                    .HasColumnName("address_line2")
                    .IsUnicode(false);

                entity.Property(e => e.AddressType).HasColumnName("address_type");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .IsUnicode(false);

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Zipcode).HasColumnName("zipcode");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Addresses_Customers");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("customer_id");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("customer_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("user_id");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .IsUnicode(false);

                entity.Property(e => e.Username).HasColumnName("username");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Customers");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
