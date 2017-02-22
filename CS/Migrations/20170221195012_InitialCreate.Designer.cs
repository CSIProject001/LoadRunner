using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CS.Data;

namespace CS.Migrations
{
    [DbContext(typeof(CandiContext))]
    [Migration("20170221195012_InitialCreate")]
    partial class InitialCreate
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
        }
    }
}
