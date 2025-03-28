﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Data;

namespace WebApplication1.Migrations
{
    [DbContext(typeof(WebApplication1Context))]
    partial class WebApplication1ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication1.Models.CustomerTb", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CUSTOMER_ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnName("CUSTOMER_ADDRESS")
                        .HasMaxLength(500);

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnName("CUSTOMER_NAME")
                        .HasMaxLength(50);

                    b.HasKey("CustomerId");

                    b.ToTable("CUSTOMER_TB");
                });

            modelBuilder.Entity("WebApplication1.Models.OrderDetailTb", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnName("ORDER_ID");

                    b.Property<int>("ProductId")
                        .HasColumnName("PRODUCT_ID");

                    b.Property<int>("Quantity");

                    b.HasKey("OrderId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("ORDERDETAIL_TB");
                });

            modelBuilder.Entity("WebApplication1.Models.OrderTb", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ORDER_ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnName("ORDER_DATETIME")
                        .HasColumnType("datetime");

                    b.Property<int>("CustomerId")
                        .HasColumnName("CUSTOMER_ID");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("ORDER_TB");
                });

            modelBuilder.Entity("WebApplication1.Models.ProductTb", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PRODUCT_ID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProductDescription")
                        .HasMaxLength(255);

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<decimal?>("ProductPrice")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("ProductId");

                    b.ToTable("PRODUCT_TB");
                });

            modelBuilder.Entity("WebApplication1.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("EmailConfirmed");

                    b.Property<string>("Password");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("USER_TB");
                });

            modelBuilder.Entity("WebApplication1.Models.OrderDetailTb", b =>
                {
                    b.HasOne("WebApplication1.Models.OrderTb", "Order_OrderDetail")
                        .WithMany("OrderDetailTbs")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication1.Models.ProductTb", "Product_OrderDetail")
                        .WithMany("OrderDetailTbs")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebApplication1.Models.OrderTb", b =>
                {
                    b.HasOne("WebApplication1.Models.CustomerTb", "Customer")
                        .WithMany("OrderTbs")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
