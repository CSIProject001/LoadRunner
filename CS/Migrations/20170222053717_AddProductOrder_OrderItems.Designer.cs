using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CS.Data;

namespace CS.Migrations
{
    [DbContext(typeof(CandiContext))]
    [Migration("20170222053717_AddProductOrder_OrderItems")]
    partial class AddProductOrder_OrderItems
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CS.Models.DBModels.Address", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<int?>("CustomerID");

                    b.Property<string>("Line1");

                    b.Property<string>("Line2");

                    b.Property<string>("State");

                    b.Property<string>("Zip");

                    b.HasKey("ID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("CS.Models.DBModels.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DOB");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Organization");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("CS.Models.DBModels.Phone", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Category");

                    b.Property<int?>("CustomerID");

                    b.Property<string>("PhoneNumber");

                    b.HasKey("ID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Phone");
                });

            modelBuilder.Entity("CS.Models.OrderViewModels.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BillingAddressID");

                    b.Property<string>("CCAuthorizationCode");

                    b.Property<int>("CustomerId");

                    b.Property<DateTime>("OrderDate");

                    b.Property<string>("OrderNumber");

                    b.Property<DateTime>("OrderReceivedDate");

                    b.Property<decimal>("OrderTotal");

                    b.Property<decimal>("PromotionAmount");

                    b.Property<string>("PromotionCode");

                    b.Property<DateTime>("ShippedDate");

                    b.Property<int?>("ShippingAddressID");

                    b.Property<decimal>("ShippingCost");

                    b.Property<string>("ShippingVia");

                    b.Property<decimal>("ShippingWeightTotal");

                    b.Property<decimal>("Tax");

                    b.Property<string>("TrackingCode");

                    b.HasKey("ID");

                    b.HasIndex("BillingAddressID");

                    b.HasIndex("ShippingAddressID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("CS.Models.OrderViewModels.OrderItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Coupon");

                    b.Property<int>("CouponPrice");

                    b.Property<int?>("OrderId");

                    b.Property<decimal>("OrderQuantity");

                    b.Property<decimal>("Price");

                    b.Property<int>("ProductId");

                    b.Property<decimal>("Total");

                    b.HasKey("ID");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItem");
                });

            modelBuilder.Entity("CS.Models.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<string>("ImageName");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name");

                    b.Property<string>("QuantityPerUnit");

                    b.Property<int>("ReOrderLevel");

                    b.Property<decimal>("UnitPrice");

                    b.Property<int>("UnitsInOrder");

                    b.Property<int>("UnitsInStock");

                    b.HasKey("ID");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("CS.Models.DBModels.Address", b =>
                {
                    b.HasOne("CS.Models.DBModels.Customer")
                        .WithMany("Addresses")
                        .HasForeignKey("CustomerID");
                });

            modelBuilder.Entity("CS.Models.DBModels.Phone", b =>
                {
                    b.HasOne("CS.Models.DBModels.Customer")
                        .WithMany("Phones")
                        .HasForeignKey("CustomerID");
                });

            modelBuilder.Entity("CS.Models.OrderViewModels.Order", b =>
                {
                    b.HasOne("CS.Models.DBModels.Address", "BillingAddress")
                        .WithMany()
                        .HasForeignKey("BillingAddressID");

                    b.HasOne("CS.Models.DBModels.Address", "ShippingAddress")
                        .WithMany()
                        .HasForeignKey("ShippingAddressID");
                });

            modelBuilder.Entity("CS.Models.OrderViewModels.OrderItem", b =>
                {
                    b.HasOne("CS.Models.OrderViewModels.Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId");
                });
        }
    }
}
