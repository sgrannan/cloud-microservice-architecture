using System;
using InventoryService.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InventoryService.Data
{
    public partial class InventoryContext : DbContext
    {
        public InventoryContext()
        {
        }

        public InventoryContext(DbContextOptions<InventoryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Items> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("category_id");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("category_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryName)
                    .HasColumnName("category_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Items>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("item_id");

                entity.Property(e => e.ItemId)
                    .HasColumnName("item_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryTypeId).HasColumnName("category_type_id");

                entity.Property(e => e.InStock).HasColumnName("in_stock");

                entity.Property(e => e.ItemDescription)
                    .HasColumnName("item_description")
                    .IsUnicode(false);

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasColumnName("item_name")
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdatedDate)
                    .HasColumnName("last_updated_date")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.CategoryType)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.CategoryTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Items_Categories");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
