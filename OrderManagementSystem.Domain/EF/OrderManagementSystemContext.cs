using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OrderManagementSystem.Domain.Entities;

namespace OrderManagementSystem.Domain.EF
{
    public partial class OrderManagementSystemContext : DbContext
    {
        public OrderManagementSystemContext()
        {
        }

        public OrderManagementSystemContext(DbContextOptions<OrderManagementSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<OrderStatusMaster> OrderStatusMasters { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<RoleMaster> RoleMasters { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CustomerAddress)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.CustomerEmail)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.CustomerPhone)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.DateDelivered).HasColumnType("datetime");

                entity.Property(e => e.Discount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<OrderStatusMaster>(entity =>
            {
                entity.ToTable("OrderStatusMaster");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Origin)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Sku)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("SKU")
                    .IsFixedLength(true);

                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<RoleMaster>(entity =>
            {
                entity.ToTable("RoleMaster");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.RefreshToken)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Token)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRole");

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
