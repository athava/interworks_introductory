using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ERP_API.Models
{
    public partial class interworksDBContext : DbContext
    {
        public interworksDBContext()
        {
        }

        public interworksDBContext(DbContextOptions<interworksDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerSubscription> CustomerSubscriptions { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Subscription> Subscriptions { get; set; }
        public virtual DbSet<SubscriptionDiscount> SubscriptionDiscounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=interworksDB;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.CustomerType)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<CustomerSubscription>(entity =>
            {
                entity.ToTable("CustomerSubscription");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerSubscriptions)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerSubscription_Customer");

                entity.HasOne(d => d.Subscription)
                    .WithMany(p => p.CustomerSubscriptions)
                    .HasForeignKey(d => d.SubscriptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomerSubscription_Subscription");
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.Property(e => e.DiscountName)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.DiscountType)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.Property(e => e.SubscriptionName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<SubscriptionDiscount>(entity =>
            {
                entity.ToTable("SubscriptionDiscount");

                entity.HasOne(d => d.CustomerSubscription)
                    .WithMany(p => p.SubscriptionDiscounts)
                    .HasForeignKey(d => d.CustomerSubscriptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubscriptionDiscount_CustomerSubscription");

                entity.HasOne(d => d.Discount)
                    .WithMany(p => p.SubscriptionDiscounts)
                    .HasForeignKey(d => d.DiscountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubscriptionDiscount_Discounts");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
