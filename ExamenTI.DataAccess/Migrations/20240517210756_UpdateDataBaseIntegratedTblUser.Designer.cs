﻿// <auto-generated />
using System;
using ExamenTI.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExamenTI.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240517210756_UpdateDataBaseIntegratedTblUser")]
    partial class UpdateDataBaseIntegratedTblUser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ExamenTI.DataAccess.Entities.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("tblArticle");
                });

            modelBuilder.Entity("ExamenTI.DataAccess.Entities.ArticleStore", b =>
                {
                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<int>("StoreId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("ArticleId", "StoreId");

                    b.HasIndex("StoreId");

                    b.ToTable("tblArticleStore");
                });

            modelBuilder.Entity("ExamenTI.DataAccess.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("tblClient");
                });

            modelBuilder.Entity("ExamenTI.DataAccess.Entities.ClientArticle", b =>
                {
                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.HasKey("ClientId", "ArticleId");

                    b.HasIndex("ArticleId");

                    b.ToTable("tblClientArticle");
                });

            modelBuilder.Entity("ExamenTI.DataAccess.Entities.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Branch")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("tblStore");
                });

            modelBuilder.Entity("ExamenTI.DataAccess.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("clientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("clientId");

                    b.ToTable("tblUser");
                });

            modelBuilder.Entity("ExamenTI.DataAccess.Entities.ArticleStore", b =>
                {
                    b.HasOne("ExamenTI.DataAccess.Entities.Article", "Article")
                        .WithMany("ArticleStores")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExamenTI.DataAccess.Entities.Store", "Store")
                        .WithMany("ArticleStores")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("ExamenTI.DataAccess.Entities.ClientArticle", b =>
                {
                    b.HasOne("ExamenTI.DataAccess.Entities.Article", "Article")
                        .WithMany("ClientArticles")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExamenTI.DataAccess.Entities.Client", "Client")
                        .WithMany("ClientArticles")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("ExamenTI.DataAccess.Entities.User", b =>
                {
                    b.HasOne("ExamenTI.DataAccess.Entities.Client", "Client")
                        .WithMany()
                        .HasForeignKey("clientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("ExamenTI.DataAccess.Entities.Article", b =>
                {
                    b.Navigation("ArticleStores");

                    b.Navigation("ClientArticles");
                });

            modelBuilder.Entity("ExamenTI.DataAccess.Entities.Client", b =>
                {
                    b.Navigation("ClientArticles");
                });

            modelBuilder.Entity("ExamenTI.DataAccess.Entities.Store", b =>
                {
                    b.Navigation("ArticleStores");
                });
#pragma warning restore 612, 618
        }
    }
}
