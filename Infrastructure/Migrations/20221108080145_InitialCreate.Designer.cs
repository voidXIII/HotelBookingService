﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(FurnitureStoreContext))]
    [Migration("20221108080145_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.DeliveryType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DeliveryTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DeliveryTypes");
                });

            modelBuilder.Entity("Domain.Entities.Function", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FunctionTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Functions");
                });

            modelBuilder.Entity("Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTimeOffset>("DateOfOrder")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("DeliveryTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PaymentIntentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Sum")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("DeliveryTypeId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Domain.Entities.OrderedProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderedProducts");
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(550)
                        .HasColumnType("nvarchar(550)");

                    b.Property<string>("Dimensions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FunctionId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TopologyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FunctionId");

                    b.HasIndex("TopologyId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Domain.Entities.Topology", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("TopologyTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Topologies");
                });

            modelBuilder.Entity("Domain.Entities.Order", b =>
                {
                    b.HasOne("Domain.Entities.DeliveryType", "DeliveryType")
                        .WithMany()
                        .HasForeignKey("DeliveryTypeId");

                    b.OwnsOne("Domain.Entities.Address", "Address", b1 =>
                        {
                            b1.Property<int>("OrderId")
                                .HasColumnType("int");

                            b1.Property<string>("City")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Country")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("FirstName")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("LastName")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Street")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ZipCode")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("DeliveryType");
                });

            modelBuilder.Entity("Domain.Entities.OrderedProduct", b =>
                {
                    b.HasOne("Domain.Entities.Order", null)
                        .WithMany("OrderedProducts")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("Domain.Entities.ProductOrdered", "ProductOrdered", b1 =>
                        {
                            b1.Property<int>("OrderedProductId")
                                .HasColumnType("int");

                            b1.Property<string>("ImageUrl")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("ProductId")
                                .HasColumnType("int");

                            b1.Property<string>("ProductName")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("OrderedProductId");

                            b1.ToTable("OrderedProducts");

                            b1.WithOwner()
                                .HasForeignKey("OrderedProductId");
                        });

                    b.Navigation("ProductOrdered");
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.HasOne("Domain.Entities.Function", "Function")
                        .WithMany()
                        .HasForeignKey("FunctionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Topology", "Topology")
                        .WithMany()
                        .HasForeignKey("TopologyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Function");

                    b.Navigation("Topology");
                });

            modelBuilder.Entity("Domain.Entities.Order", b =>
                {
                    b.Navigation("OrderedProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
