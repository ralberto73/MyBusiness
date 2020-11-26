using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MyBusiness.Models
{
    public partial class MyBusinessContext : DbContext
    {
        public MyBusinessContext()
        {
        }

        public MyBusinessContext(DbContextOptions<MyBusinessContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<WorkOrder> WorkOrders { get; set; }
        public virtual DbSet<WorkOrderDetail> WorkOrderDetails { get; set; }
        public virtual DbSet<WorkOrderStatus> WorkOrderStatuses { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=LAPTOP-60J88C7D\\LOCALDB;Initial Catalog=MyBusiness;Integrated Security=True;Pooling=False");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");

                entity.Property(e => e.BrandId).HasMaxLength(20);

                entity.Property(e => e.Description).HasMaxLength(150);
            });

            modelBuilder.Entity<WorkOrder>(entity =>
            {
                entity.ToTable("WorkOrder");

                entity.Property(e => e.Brand)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CretedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('anonymous')");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MainContat).HasMaxLength(100);

                entity.Property(e => e.Model)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('anonymous')");

                entity.Property(e => e.UpdtaedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.WorkOrderStatusId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasDefaultValueSql("(N'CREATED')");
            });

            modelBuilder.Entity<WorkOrderDetail>(entity =>
            {
                entity.Property(e => e.WorkOrderDetailId).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.ProviderPrice).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.SalePrice).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.WorkOrderDetailType).HasMaxLength(50);
            });

            modelBuilder.Entity<WorkOrderStatus>(entity =>
            {
                entity.ToTable("WorkOrderStatus");

                entity.Property(e => e.WorkOrderStatusId).HasMaxLength(20);

                entity.Property(e => e.Color)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StatusDescription).HasMaxLength(150);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
