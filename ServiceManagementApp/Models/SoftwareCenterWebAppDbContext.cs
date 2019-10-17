using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ServiceManagementApp.Models
{
    public partial class SoftwareCenterWebAppDbContext : DbContext
    {
        public SoftwareCenterWebAppDbContext()
        {
        }

        public SoftwareCenterWebAppDbContext(DbContextOptions<SoftwareCenterWebAppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actions> Actions { get; set; }
        public virtual DbSet<Agreements> Agreements { get; set; }
        public virtual DbSet<CustomerContacts> CustomerContacts { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<FavFiles> FavFiles { get; set; }
        public virtual DbSet<Files> Files { get; set; }
        public virtual DbSet<Issues> Issues { get; set; }
        public virtual DbSet<Knowledges> Knowledges { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:softwarecenter.database.windows.net,1433;Initial Catalog=SoftwareCenterWebAppDb;Persist Security Info=False;User ID=WebApp;Password=Salta!1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Actions>(entity =>
            {
                entity.HasIndex(e => e.AgreementId);

                entity.HasIndex(e => e.CustomerId);

                entity.HasIndex(e => e.ProductId);

                entity.HasOne(d => d.Agreement)
                    .WithMany(p => p.Actions)
                    .HasForeignKey(d => d.AgreementId);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Actions)
                    .HasForeignKey(d => d.CustomerId);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Actions)
                    .HasForeignKey(d => d.ProductId);
            });

            modelBuilder.Entity<CustomerContacts>(entity =>
            {
                entity.HasIndex(e => e.CustomerId);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerContacts)
                    .HasForeignKey(d => d.CustomerId);
            });

            modelBuilder.Entity<FavFiles>(entity =>
            {
                entity.HasIndex(e => e.FileId);

                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.File)
                    .WithMany(p => p.FavFiles)
                    .HasForeignKey(d => d.FileId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FavFiles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Files>(entity =>
            {
                entity.HasIndex(e => e.AgreementId);

                entity.HasIndex(e => e.CustomerId);

                entity.HasIndex(e => e.IssueId);

                entity.HasIndex(e => e.KnowledgeId);

                entity.HasIndex(e => e.ProductId);

                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.Agreement)
                    .WithMany(p => p.Files)
                    .HasForeignKey(d => d.AgreementId);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Files)
                    .HasForeignKey(d => d.CustomerId);

                entity.HasOne(d => d.Issue)
                    .WithMany(p => p.Files)
                    .HasForeignKey(d => d.IssueId);

                entity.HasOne(d => d.Knowledge)
                    .WithMany(p => p.Files)
                    .HasForeignKey(d => d.KnowledgeId);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Files)
                    .HasForeignKey(d => d.ProductId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Files)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Issues>(entity =>
            {
                entity.HasIndex(e => e.AgreementId);

                entity.HasIndex(e => e.CustomerId);

                entity.HasIndex(e => e.ProductId);

                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.Agreement)
                    .WithMany(p => p.Issues)
                    .HasForeignKey(d => d.AgreementId);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Issues)
                    .HasForeignKey(d => d.CustomerId);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Issues)
                    .HasForeignKey(d => d.ProductId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Issues)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Knowledges>(entity =>
            {
                entity.HasIndex(e => e.AgreementId);

                entity.HasIndex(e => e.CustomerId);

                entity.HasIndex(e => e.ProductId);

                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.Agreement)
                    .WithMany(p => p.Knowledges)
                    .HasForeignKey(d => d.AgreementId);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Knowledges)
                    .HasForeignKey(d => d.CustomerId);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Knowledges)
                    .HasForeignKey(d => d.ProductId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Knowledges)
                    .HasForeignKey(d => d.UserId);
            });
        }
    }
}
