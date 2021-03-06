﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SoftwareCenterWebApp.Data;

namespace SoftwareCenterWebApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190828132603_issuemodelupdate2")]
    partial class issuemodelupdate2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SoftwareCenterWebApp.Models.ActionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgreementId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("CustomerId");

                    b.Property<string>("Description");

                    b.Property<DateTime>("DoneDate");

                    b.Property<string>("Notes");

                    b.Property<string>("Priority");

                    b.Property<int>("ProductId");

                    b.Property<string>("Responsible");

                    b.Property<string>("Status");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("AgreementId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.ToTable("Actions");
                });

            modelBuilder.Entity("SoftwareCenterWebApp.Models.AgreementModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Agreements");
                });

            modelBuilder.Entity("SoftwareCenterWebApp.Models.CustomerContactModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<string>("Position");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("CustomerContacts");
                });

            modelBuilder.Entity("SoftwareCenterWebApp.Models.CustomerModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("SoftwareCenterWebApp.Models.FileModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgreementId");

                    b.Property<int>("CustomerId");

                    b.Property<string>("FileName");

                    b.Property<string>("FilePath");

                    b.Property<int>("IssueId");

                    b.Property<int>("KnowledgeId");

                    b.Property<int>("ProductId");

                    b.Property<string>("Type");

                    b.Property<DateTime>("Uploaded");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("AgreementId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("IssueId");

                    b.HasIndex("KnowledgeId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("SoftwareCenterWebApp.Models.IssueModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AgreementId");

                    b.Property<DateTime>("CloseDate");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("CustomerId");

                    b.Property<string>("Description");

                    b.Property<string>("Notes");

                    b.Property<string>("Priority");

                    b.Property<int?>("ProductId");

                    b.Property<string>("Remedy");

                    b.Property<string>("Status");

                    b.Property<string>("Title");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("AgreementId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Issues");
                });

            modelBuilder.Entity("SoftwareCenterWebApp.Models.KnowledgeModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AgreementId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int>("CustomerId");

                    b.Property<string>("Description");

                    b.Property<int>("ProductId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("AgreementId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.ToTable("Knowledges");
                });

            modelBuilder.Entity("SoftwareCenterWebApp.Models.ProductModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SoftwareCenterWebApp.Models.ProjectModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ClosedDate");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<string>("Files");

                    b.Property<string>("ProjectLeader");

                    b.Property<string>("ProjectNumber");

                    b.Property<string>("RespTech");

                    b.Property<string>("SalesRep");

                    b.Property<string>("Status");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("SoftwareCenterWebApp.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Group");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SoftwareCenterWebApp.Models.ActionModel", b =>
                {
                    b.HasOne("SoftwareCenterWebApp.Models.AgreementModel", "Agreement")
                        .WithMany()
                        .HasForeignKey("AgreementId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SoftwareCenterWebApp.Models.CustomerModel", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SoftwareCenterWebApp.Models.ProductModel", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SoftwareCenterWebApp.Models.CustomerContactModel", b =>
                {
                    b.HasOne("SoftwareCenterWebApp.Models.CustomerModel", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SoftwareCenterWebApp.Models.FileModel", b =>
                {
                    b.HasOne("SoftwareCenterWebApp.Models.AgreementModel", "Agreement")
                        .WithMany()
                        .HasForeignKey("AgreementId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SoftwareCenterWebApp.Models.CustomerModel", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SoftwareCenterWebApp.Models.IssueModel", "Issue")
                        .WithMany()
                        .HasForeignKey("IssueId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SoftwareCenterWebApp.Models.KnowledgeModel", "Knowledge")
                        .WithMany()
                        .HasForeignKey("KnowledgeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SoftwareCenterWebApp.Models.ProductModel", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SoftwareCenterWebApp.Models.UserModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SoftwareCenterWebApp.Models.IssueModel", b =>
                {
                    b.HasOne("SoftwareCenterWebApp.Models.AgreementModel", "Agreement")
                        .WithMany()
                        .HasForeignKey("AgreementId");

                    b.HasOne("SoftwareCenterWebApp.Models.CustomerModel", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SoftwareCenterWebApp.Models.ProductModel", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("SoftwareCenterWebApp.Models.UserModel", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SoftwareCenterWebApp.Models.KnowledgeModel", b =>
                {
                    b.HasOne("SoftwareCenterWebApp.Models.AgreementModel", "Agreement")
                        .WithMany()
                        .HasForeignKey("AgreementId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SoftwareCenterWebApp.Models.CustomerModel", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SoftwareCenterWebApp.Models.ProductModel", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
