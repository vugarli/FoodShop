﻿// <auto-generated />
using System;
using FoodShop.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FoodShop.Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231223221117_initial2")]
    partial class initial2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FoodShop.Domain.Entities.BaseCategoryDiscriminators", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BaseCategoryDiscriminators");
                });

            modelBuilder.Entity("FoodShop.Domain.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BaseCategoryDiscriminatorId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BaseCategoryDiscriminatorId");

                    b.HasIndex("ParentId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("FoodShop.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("FoodShop.Domain.Entities.ProductEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("SKU")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductEntry");
                });

            modelBuilder.Entity("FoodShop.Domain.Entities.Variation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Variation");
                });

            modelBuilder.Entity("FoodShop.Domain.Entities.VariationCategory", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VariationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CategoryId", "VariationId");

                    b.HasIndex("VariationId");

                    b.ToTable("VariationCategory");
                });

            modelBuilder.Entity("FoodShop.Domain.Entities.VariationOption", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("VariationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("VariationId");

                    b.ToTable("VariationOption");
                });

            modelBuilder.Entity("ProductEntryVariationOption", b =>
                {
                    b.Property<Guid>("ProductEntriesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VariationOptionsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProductEntriesId", "VariationOptionsId");

                    b.HasIndex("VariationOptionsId");

                    b.ToTable("ProductEntryVariationOption");
                });

            modelBuilder.Entity("FoodShop.Domain.Entities.Category", b =>
                {
                    b.HasOne("FoodShop.Domain.Entities.BaseCategoryDiscriminators", "BaseCategoryDiscriminator")
                        .WithMany("Categories")
                        .HasForeignKey("BaseCategoryDiscriminatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodShop.Domain.Entities.Category", "ParentCategory")
                        .WithMany()
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("BaseCategoryDiscriminator");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("FoodShop.Domain.Entities.Product", b =>
                {
                    b.HasOne("FoodShop.Domain.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("FoodShop.Domain.Entities.ProductEntry", b =>
                {
                    b.HasOne("FoodShop.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("FoodShop.Domain.Entities.VariationCategory", b =>
                {
                    b.HasOne("FoodShop.Domain.Entities.Category", "Category")
                        .WithMany("VaritaionCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodShop.Domain.Entities.Variation", "Variation")
                        .WithMany("VaritaionCategories")
                        .HasForeignKey("VariationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Variation");
                });

            modelBuilder.Entity("FoodShop.Domain.Entities.VariationOption", b =>
                {
                    b.HasOne("FoodShop.Domain.Entities.Variation", "Variation")
                        .WithMany()
                        .HasForeignKey("VariationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Variation");
                });

            modelBuilder.Entity("ProductEntryVariationOption", b =>
                {
                    b.HasOne("FoodShop.Domain.Entities.ProductEntry", null)
                        .WithMany()
                        .HasForeignKey("ProductEntriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodShop.Domain.Entities.VariationOption", null)
                        .WithMany()
                        .HasForeignKey("VariationOptionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodShop.Domain.Entities.BaseCategoryDiscriminators", b =>
                {
                    b.Navigation("Categories");
                });

            modelBuilder.Entity("FoodShop.Domain.Entities.Category", b =>
                {
                    b.Navigation("VaritaionCategories");
                });

            modelBuilder.Entity("FoodShop.Domain.Entities.Variation", b =>
                {
                    b.Navigation("VaritaionCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
