using Microsoft.EntityFrameworkCore;
using SoftwareCenterWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareCenterWebApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<IssueModel> Issues { get; set; }
        public DbSet<ActionModel> Actions { get; set; }
        public DbSet<CustomerContactModel> CustomerContacts { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<KnowledgeModel> Knowledges { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<ProjectModel> Projects { get; set; }
        public DbSet<AgreementModel> Agreements { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<FileModel> Files { get; set; }
        public DbSet<FavFilesModel> FavFiles { get; set; }







    }
}
