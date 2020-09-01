using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SurvivalGameCoreAPI.Models
{
    public partial class SGDBContext : DbContext
    {
        public SGDBContext()
        {
        }

        public SGDBContext(DbContextOptions<SGDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Catagory> Catagory { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Imgs> Imgs { get; set; }
        public virtual DbSet<Manufacturers> Manufacturers { get; set; }
        public virtual DbSet<Members> Members { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethod { get; set; }
        public virtual DbSet<Procurement> Procurement { get; set; }
        public virtual DbSet<ProductAttributes> ProductAttributes { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<RelatedProducts> RelatedProducts { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Wishlist> Wishlist { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=sgdb-server.database.windows.net;Initial Catalog=SGDB;Persist Security Info=True;User ID=SGadmin;Password=bs2020SG");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catagory>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.CatagoryId)
                    .IsRequired()
                    .HasColumnName("CatagoryID")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Catagory)
                    .WithMany(p => p.Class)
                    .HasForeignKey(d => d.CatagoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Class_Catagory");
            });

            modelBuilder.Entity<Imgs>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .HasColumnName("ProductID")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Imgs)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Imgs_Products");
            });

            modelBuilder.Entity<Manufacturers>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Depiction).HasMaxLength(50);

                entity.Property(e => e.Img).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Members>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Account).HasMaxLength(50);

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.Birthday).HasColumnType("smalldatetime");

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.PostCode).HasMaxLength(10);
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.ToTable("Order Details");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.OrderId)
                    .IsRequired()
                    .HasColumnName("OrderID")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .HasColumnName("ProductID")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order Details_Orders");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order Details_Products");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.DeliveryMethod).HasMaxLength(50);

                entity.Property(e => e.Depiction).HasMaxLength(50);

                entity.Property(e => e.MemberId)
                    .IsRequired()
                    .HasColumnName("MemberID")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.OrderDate).HasColumnType("smalldatetime");

                entity.Property(e => e.PaymentMethodId)
                    .IsRequired()
                    .HasColumnName("PaymentMethodID")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ShipAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ShippedDate).HasColumnType("smalldatetime");

                entity.Property(e => e.StatusId)
                    .IsRequired()
                    .HasColumnName("StatusID")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Members");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_PaymentMethod");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Status");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.PaymentMethod1)
                    .IsRequired()
                    .HasColumnName("PaymentMethod")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Procurement>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .HasColumnName("ProductID")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.PurchasingDay).HasColumnType("smalldatetime");

                entity.Property(e => e.UintPrice).HasColumnType("money");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Procurement)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Procurement_Products");
            });

            modelBuilder.Entity<ProductAttributes>(entity =>
            {
                entity.ToTable("Product Attributes");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Pid)
                    .IsRequired()
                    .HasColumnName("PID")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.P)
                    .WithMany(p => p.ProductAttributes)
                    .HasForeignKey(d => d.Pid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product Attributes_Products");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ClassId)
                    .IsRequired()
                    .HasColumnName("ClassID")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Color).HasMaxLength(150);

                entity.Property(e => e.ManufacturerId)
                    .IsRequired()
                    .HasColumnName("ManufacturerID")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Class");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Manufacturers");
            });

            modelBuilder.Entity<RelatedProducts>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .HasColumnName("ProductID")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.RelationPid)
                    .IsRequired()
                    .HasColumnName("RelationPID")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.RelatedProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RelatedProducts_Products");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Status1)
                    .IsRequired()
                    .HasColumnName("Status")
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Wishlist>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.MemberId)
                    .IsRequired()
                    .HasColumnName("MemberID")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ProductId)
                    .IsRequired()
                    .HasColumnName("ProductID")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Wishlist)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Wishlist_Members");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Wishlist)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Wishlist_Products");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
