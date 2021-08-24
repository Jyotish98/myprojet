﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Team_2_OnlineCourierManagement.Entities;

namespace Team_2_OnlineCourierManagement.Migrations
{
    [DbContext(typeof(CourierManagementContext))]
    [Migration("20210728072157_initial1")]
    partial class initial1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Team_2_OnlineCourierManagement.Entities.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContanctNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonRole")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("Team_2_OnlineCourierManagement.Entities.Bill", b =>
                {
                    b.Property<int>("BillNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BillDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ConsigneeAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConsigneeContanctNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConsigneeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConsignerAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConsignerContanctNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConsignerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ConsignmentCharges")
                        .HasColumnType("float");

                    b.Property<int?>("ConsignmentId")
                        .HasColumnType("int");

                    b.Property<string>("ConsignmentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BillNo");

                    b.HasIndex("ConsignmentId");

                    b.ToTable("Bills");
                });

            modelBuilder.Entity("Team_2_OnlineCourierManagement.Entities.Consignee", b =>
                {
                    b.Property<int>("ConsigneeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContanctNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonRole")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ConsigneeId");

                    b.ToTable("Consignees");
                });

            modelBuilder.Entity("Team_2_OnlineCourierManagement.Entities.Consigner", b =>
                {
                    b.Property<int>("ConsignerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContanctNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonRole")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ConsignerId");

                    b.ToTable("Consigners");
                });

            modelBuilder.Entity("Team_2_OnlineCourierManagement.Entities.Consignment", b =>
                {
                    b.Property<int>("ConsignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ConsigneeId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("ConsignerId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<decimal>("ConsignmentCharges")
                        .HasColumnType("Money");

                    b.Property<string>("ConsignmentStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConsignmentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBooking")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DeliveryExecitiveId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpectedDeliveryDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ConsignmentId");

                    b.HasIndex("ConsigneeId");

                    b.HasIndex("ConsignerId");

                    b.HasIndex("DeliveryExecitiveId");

                    b.ToTable("Consignments");
                });

            modelBuilder.Entity("Team_2_OnlineCourierManagement.Entities.DeliveryExecutive", b =>
                {
                    b.Property<int>("DeliveryExecitiveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContanctNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonRole")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DeliveryExecitiveId");

                    b.ToTable("DeliveryExecutives");
                });

            modelBuilder.Entity("Team_2_OnlineCourierManagement.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContanctNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonRole")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Team_2_OnlineCourierManagement.Entities.Bill", b =>
                {
                    b.HasOne("Team_2_OnlineCourierManagement.Entities.Consignment", "consignment")
                        .WithMany()
                        .HasForeignKey("ConsignmentId");

                    b.Navigation("consignment");
                });

            modelBuilder.Entity("Team_2_OnlineCourierManagement.Entities.Consignment", b =>
                {
                    b.HasOne("Team_2_OnlineCourierManagement.Entities.Consignee", "consignee")
                        .WithMany()
                        .HasForeignKey("ConsigneeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Team_2_OnlineCourierManagement.Entities.Consigner", "consigner")
                        .WithMany()
                        .HasForeignKey("ConsignerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Team_2_OnlineCourierManagement.Entities.DeliveryExecutive", "deliveryExecitive")
                        .WithMany()
                        .HasForeignKey("DeliveryExecitiveId");

                    b.Navigation("consignee");

                    b.Navigation("consigner");

                    b.Navigation("deliveryExecitive");
                });
#pragma warning restore 612, 618
        }
    }
}
