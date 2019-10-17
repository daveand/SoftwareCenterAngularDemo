﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ServiceManagementApp.Models;

namespace ServiceManagementApp.Migrations
{
    [DbContext(typeof(SoftwareCenterWebAppDbContext))]
    [Migration("20191017130356_testing2")]
    partial class testing2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ServiceManagementApp.Models.Actions", b =>
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

                    b.Property<string>("Status");

                    b.Property<string>("Title");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("AgreementId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Actions");
                });

            modelBuilder.Entity("ServiceManagementApp.Models.Agreements", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Agreements");
                });

            modelBuilder.Entity("ServiceManagementApp.Models.CustomerContacts", b =>
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

            modelBuilder.Entity("ServiceManagementApp.Models.Customers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ServiceManagementApp.Models.FavFiles", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FileId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("FileId");

                    b.HasIndex("UserId");

                    b.ToTable("FavFiles");
                });

            modelBuilder.Entity("ServiceManagementApp.Models.Files", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AgreementId");

                    b.Property<int>("CustomerId");

                    b.Property<string>("FileName");

                    b.Property<string>("FilePath");

                    b.Property<int?>("IssueId");

                    b.Property<int?>("KnowledgeId");

                    b.Property<int?>("ProductId");

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

            modelBuilder.Entity("ServiceManagementApp.Models.Issues", b =>
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

            modelBuilder.Entity("ServiceManagementApp.Models.Knowledges", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AgreementId");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<int?>("CustomerId");

                    b.Property<string>("Description");

                    b.Property<string>("Notes");

                    b.Property<int?>("ProductId");

                    b.Property<string>("Remedy");

                    b.Property<string>("Title");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("AgreementId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Knowledges");
                });

            modelBuilder.Entity("ServiceManagementApp.Models.Products", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ServiceManagementApp.Models.Projects", b =>
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

            modelBuilder.Entity("ServiceManagementApp.Models.Users", b =>
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

            modelBuilder.Entity("ServiceManagementApp.Models.Actions", b =>
                {
                    b.HasOne("ServiceManagementApp.Models.Agreements", "Agreement")
                        .WithMany("Actions")
                        .HasForeignKey("AgreementId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ServiceManagementApp.Models.Customers", "Customer")
                        .WithMany("Actions")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ServiceManagementApp.Models.Products", "Product")
                        .WithMany("Actions")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ServiceManagementApp.Models.Users", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ServiceManagementApp.Models.CustomerContacts", b =>
                {
                    b.HasOne("ServiceManagementApp.Models.Customers", "Customer")
                        .WithMany("CustomerContacts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ServiceManagementApp.Models.FavFiles", b =>
                {
                    b.HasOne("ServiceManagementApp.Models.Files", "File")
                        .WithMany("FavFiles")
                        .HasForeignKey("FileId");

                    b.HasOne("ServiceManagementApp.Models.Users", "User")
                        .WithMany("FavFiles")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ServiceManagementApp.Models.Files", b =>
                {
                    b.HasOne("ServiceManagementApp.Models.Agreements", "Agreement")
                        .WithMany("Files")
                        .HasForeignKey("AgreementId");

                    b.HasOne("ServiceManagementApp.Models.Customers", "Customer")
                        .WithMany("Files")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ServiceManagementApp.Models.Issues", "Issue")
                        .WithMany("Files")
                        .HasForeignKey("IssueId");

                    b.HasOne("ServiceManagementApp.Models.Knowledges", "Knowledge")
                        .WithMany("Files")
                        .HasForeignKey("KnowledgeId");

                    b.HasOne("ServiceManagementApp.Models.Products", "Product")
                        .WithMany("Files")
                        .HasForeignKey("ProductId");

                    b.HasOne("ServiceManagementApp.Models.Users", "User")
                        .WithMany("Files")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ServiceManagementApp.Models.Issues", b =>
                {
                    b.HasOne("ServiceManagementApp.Models.Agreements", "Agreement")
                        .WithMany("Issues")
                        .HasForeignKey("AgreementId");

                    b.HasOne("ServiceManagementApp.Models.Customers", "Customer")
                        .WithMany("Issues")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ServiceManagementApp.Models.Products", "Product")
                        .WithMany("Issues")
                        .HasForeignKey("ProductId");

                    b.HasOne("ServiceManagementApp.Models.Users", "User")
                        .WithMany("Issues")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ServiceManagementApp.Models.Knowledges", b =>
                {
                    b.HasOne("ServiceManagementApp.Models.Agreements", "Agreement")
                        .WithMany("Knowledges")
                        .HasForeignKey("AgreementId");

                    b.HasOne("ServiceManagementApp.Models.Customers", "Customer")
                        .WithMany("Knowledges")
                        .HasForeignKey("CustomerId");

                    b.HasOne("ServiceManagementApp.Models.Products", "Product")
                        .WithMany("Knowledges")
                        .HasForeignKey("ProductId");

                    b.HasOne("ServiceManagementApp.Models.Users", "User")
                        .WithMany("Knowledges")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
