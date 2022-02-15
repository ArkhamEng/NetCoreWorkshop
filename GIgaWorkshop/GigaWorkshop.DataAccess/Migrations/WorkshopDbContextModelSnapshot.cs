﻿// <auto-generated />
using System;
using GigaWorkshop.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GigaWorkshop.DataAccess.Migrations
{
    [DbContext(typeof(WorkshopDbContext))]
    partial class WorkshopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Inventory")
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GigaWorkshop.DataAccess.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Category", "Inventory");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsActive = true,
                            Name = "Category One"
                        },
                        new
                        {
                            Id = 2,
                            IsActive = true,
                            Name = "Category Two"
                        },
                        new
                        {
                            Id = 3,
                            IsActive = true,
                            Name = "Category Three"
                        },
                        new
                        {
                            Id = 4,
                            IsActive = true,
                            Name = "Category Four",
                            ParentCategoryId = 3
                        });
                });

            modelBuilder.Entity("GigaWorkshop.DataAccess.Entities.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FK_Product_Image")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Size")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FK_Product_Image");

                    b.ToTable("Image", "Inventory");
                });

            modelBuilder.Entity("GigaWorkshop.DataAccess.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(10,3)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,3)");

                    b.Property<string>("SKU")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SKU", "Name", "Description")
                        .HasDatabaseName("IDX_Name_Description");

                    b.ToTable("Product", "Inventory");
                });

            modelBuilder.Entity("GigaWorkshop.DataAccess.Entities.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("FK_Product_Stock")
                        .HasColumnType("int");

                    b.Property<int>("FK_Product_Warehouse")
                        .HasColumnType("int");

                    b.Property<float>("LastQuantity")
                        .HasColumnType("real");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<float>("Quantity")
                        .HasColumnType("real");

                    b.Property<int>("WarehouseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FK_Product_Stock");

                    b.HasIndex("FK_Product_Warehouse");

                    b.ToTable("Stock", "Inventory");
                });

            modelBuilder.Entity("GigaWorkshop.DataAccess.Entities.Warehouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Warehouse", "Inventory");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsActive = true,
                            Name = "Warehouse North One"
                        },
                        new
                        {
                            Id = 2,
                            IsActive = true,
                            Name = "Warehouse East"
                        },
                        new
                        {
                            Id = 3,
                            IsActive = true,
                            Name = "Warehouse West"
                        });
                });

            modelBuilder.Entity("GigaWorkshop.DataAccess.Entities.Category", b =>
                {
                    b.HasOne("GigaWorkshop.DataAccess.Entities.Category", "ParentCategory")
                        .WithMany("Categories")
                        .HasForeignKey("ParentCategoryId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("FK_Category_Category");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("GigaWorkshop.DataAccess.Entities.Image", b =>
                {
                    b.HasOne("GigaWorkshop.DataAccess.Entities.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("FK_Product_Image")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("GigaWorkshop.DataAccess.Entities.Product", b =>
                {
                    b.HasOne("GigaWorkshop.DataAccess.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Category_Product");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("GigaWorkshop.DataAccess.Entities.Stock", b =>
                {
                    b.HasOne("GigaWorkshop.DataAccess.Entities.Product", "Product")
                        .WithMany("Stocks")
                        .HasForeignKey("FK_Product_Stock")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GigaWorkshop.DataAccess.Entities.Warehouse", "Warehouse")
                        .WithMany("Stocks")
                        .HasForeignKey("FK_Product_Warehouse")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("GigaWorkshop.DataAccess.Entities.Category", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("GigaWorkshop.DataAccess.Entities.Product", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("Stocks");
                });

            modelBuilder.Entity("GigaWorkshop.DataAccess.Entities.Warehouse", b =>
                {
                    b.Navigation("Stocks");
                });
#pragma warning restore 612, 618
        }
    }
}