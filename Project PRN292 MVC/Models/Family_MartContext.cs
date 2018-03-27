using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Project_PRN292_MVC.Models
{
    public partial class Family_MartContext : DbContext
    {
        public Family_MartContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<About> About { get; set; }
        public virtual DbSet<Blogs> Blogs { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<ConnectWithUs> ConnectWithUs { get; set; }
        public virtual DbSet<ContactInformations> ContactInformations { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<FactAndQuestions> FactAndQuestions { get; set; }
        public virtual DbSet<Founders> Founders { get; set; }
        public virtual DbSet<OpeningHours> OpeningHours { get; set; }
        public virtual DbSet<ProductCategoryConnection> ProductCategoryConnection { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }
        public virtual DbSet<ShopInformation> ShopInformation { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer(@"Server=desktop-gsc4244\sqlexpress;Database=Family Mart;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<About>(entity =>
            {
                entity.Property(e => e.AboutId).HasColumnName("AboutID");

                entity.Property(e => e.ImageName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Blogs>(entity =>
            {
                entity.HasKey(e => e.BlogId);

                entity.Property(e => e.BlogId).HasColumnName("BlogID");

                entity.Property(e => e.AuthorId).HasColumnName("AuthorID");

                entity.Property(e => e.Content).IsRequired();

                entity.Property(e => e.DateCreated)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ImageName).HasColumnType("nchar(10)");

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Blogs_Customers");
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName).HasMaxLength(100);

                entity.Property(e => e.DateCreated)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ConnectWithUs>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Host).HasMaxLength(50);

                entity.Property(e => e.Link).IsUnicode(false);
            });

            modelBuilder.Entity<ContactInformations>(entity =>
            {
                entity.HasKey(e => e.ContactInformationId);

                entity.Property(e => e.ContactInformationId).HasColumnName("ContactInformationID");

                entity.Property(e => e.Email).HasColumnType("nchar(50)");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("nchar(10)")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FactAndQuestions>(entity =>
            {
                entity.HasKey(e => e.FaQid);

                entity.Property(e => e.FaQid).HasColumnName("FaQID");
            });

            modelBuilder.Entity<Founders>(entity =>
            {
                entity.HasKey(e => e.FounderId);

                entity.Property(e => e.FounderId).HasColumnName("FounderID");

                entity.Property(e => e.ContactLink).IsUnicode(false);

                entity.Property(e => e.ImageName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<OpeningHours>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Saturday)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sunday)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WeekDays)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProductCategoryConnection>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.CategoryId });

                entity.ToTable("Product-Category Connection");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.ProductCategoryConnection)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product-Category Connection_Categories");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductCategoryConnection)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product-Category Connection_Products");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("nchar(10)")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ImageName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Reviews>(entity =>
            {
                entity.HasKey(e => e.ReviewId);

                entity.Property(e => e.ReviewId).HasColumnName("ReviewID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Message).IsRequired();

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reviews_Customers");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reviews_Products");
            });

            modelBuilder.Entity<ShopInformation>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fax)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
