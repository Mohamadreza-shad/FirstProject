﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SeptaPay.Integration.Sepid.Contexts;

namespace Sepid.Api.Migrations
{
    [DbContext(typeof(SepidContext))]
    partial class SepidContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SeptaPay.Integration.Sepid.Model.PurchaseRequestEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("AmountAfterDiscount")
                        .HasColumnType("bigint");

                    b.Property<long>("AmountBeforeDiscount")
                        .HasColumnType("bigint");

                    b.Property<int?>("BarcodeStan")
                        .HasColumnType("int");

                    b.Property<int>("CampaignID")
                        .HasColumnType("int");

                    b.Property<long>("Counter")
                        .HasColumnType("bigint");

                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("EntityId")
                        .HasColumnType("bigint");

                    b.Property<int>("InstituteId")
                        .HasColumnType("int");

                    b.Property<long?>("IpgrRn")
                        .HasColumnType("bigint");

                    b.Property<int>("LockFlag")
                        .HasColumnType("int");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NationalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PAN")
                        .HasColumnType("bigint");

                    b.Property<Guid?>("PurchaseResponseId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ReceiveDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TerminalID")
                        .HasColumnType("int");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("WalletId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PurchaseResponseId")
                        .IsUnique()
                        .HasFilter("[PurchaseResponseId] IS NOT NULL");

                    b.ToTable("PurchaseRequest");
                });

            modelBuilder.Entity("SeptaPay.Integration.Sepid.Model.PurchaseResponseEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CentralMessageCode")
                        .HasColumnType("int");

                    b.Property<string>("EnMessageDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FaMessageDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InnerException")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Issrrn")
                        .HasColumnType("bigint");

                    b.Property<int>("MessageCode")
                        .HasColumnType("int");

                    b.Property<long>("Rrn")
                        .HasColumnType("bigint");

                    b.Property<int>("Stan")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("SwResult")
                        .HasColumnType("int");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("PurchaseResponse");
                });

            modelBuilder.Entity("SeptaPay.Integration.Sepid.Model.PurchaseRequestEntity", b =>
                {
                    b.HasOne("SeptaPay.Integration.Sepid.Model.PurchaseResponseEntity", "PurchaseResponse")
                        .WithOne("PurchaseRequestEntity")
                        .HasForeignKey("SeptaPay.Integration.Sepid.Model.PurchaseRequestEntity", "PurchaseResponseId");
                });
#pragma warning restore 612, 618
        }
    }
}
