﻿// <auto-generated />
using System;
using Kolokwium2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Kolokwium2.Migrations
{
    [DbContext(typeof(MainDbContext))]
    [Migration("20220623081530_add")]
    partial class add
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Kolokwium2.Models.File", b =>
                {
                    b.Property<int>("FileID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("nvarchar(4)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("FileSize")
                        .HasColumnType("int");

                    b.Property<int>("TeamID")
                        .HasColumnType("int");

                    b.HasKey("FileID");

                    b.HasIndex("TeamID");

                    b.ToTable("Files");

                    b.HasData(
                        new
                        {
                            FileID = 1,
                            FileExtension = "txt",
                            FileName = "filename",
                            FileSize = 2,
                            TeamID = 1
                        });
                });

            modelBuilder.Entity("Kolokwium2.Models.Member", b =>
                {
                    b.Property<int>("MemberID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MemberName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("MemberNickName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("MemberSurname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("OrganizationID")
                        .HasColumnType("int");

                    b.HasKey("MemberID");

                    b.HasIndex("OrganizationID");

                    b.ToTable("Members");

                    b.HasData(
                        new
                        {
                            MemberID = 1,
                            MemberName = "Johny",
                            MemberNickName = "Megapint",
                            MemberSurname = "Depp",
                            OrganizationID = 1
                        });
                });

            modelBuilder.Entity("Kolokwium2.Models.Membership", b =>
                {
                    b.Property<int>("MemberID")
                        .HasColumnType("int");

                    b.Property<int>("TeamID")
                        .HasColumnType("int");

                    b.Property<DateTime>("MemberShipDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TeamdID")
                        .HasColumnType("int");

                    b.HasKey("MemberID", "TeamID");

                    b.HasIndex("TeamdID");

                    b.ToTable("Memberships");

                    b.HasData(
                        new
                        {
                            MemberID = 1,
                            TeamID = 1,
                            MemberShipDate = new DateTime(2022, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Kolokwium2.Models.Organization", b =>
                {
                    b.Property<int>("OrganizationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OrganizationDomain")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OrganizationName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("OrganizationID");

                    b.ToTable("Organizations");

                    b.HasData(
                        new
                        {
                            OrganizationID = 1,
                            OrganizationDomain = "blue.com",
                            OrganizationName = "Blue"
                        });
                });

            modelBuilder.Entity("Kolokwium2.Models.Team", b =>
                {
                    b.Property<int>("TeamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrganizationID")
                        .HasColumnType("int");

                    b.Property<string>("TeamDescription")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TeamID");

                    b.HasIndex("OrganizationID");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            TeamID = 1,
                            OrganizationID = 1,
                            TeamDescription = "description",
                            TeamName = "xyz"
                        });
                });

            modelBuilder.Entity("Kolokwium2.Models.File", b =>
                {
                    b.HasOne("Kolokwium2.Models.Team", "Team")
                        .WithMany("Files")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Kolokwium2.Models.Member", b =>
                {
                    b.HasOne("Kolokwium2.Models.Organization", "Organization")
                        .WithMany("Members")
                        .HasForeignKey("OrganizationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("Kolokwium2.Models.Membership", b =>
                {
                    b.HasOne("Kolokwium2.Models.Member", "Member")
                        .WithMany("Memberships")
                        .HasForeignKey("MemberID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kolokwium2.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamdID");

                    b.Navigation("Member");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Kolokwium2.Models.Team", b =>
                {
                    b.HasOne("Kolokwium2.Models.Organization", "Organization")
                        .WithMany("Teams")
                        .HasForeignKey("OrganizationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("Kolokwium2.Models.Member", b =>
                {
                    b.Navigation("Memberships");
                });

            modelBuilder.Entity("Kolokwium2.Models.Organization", b =>
                {
                    b.Navigation("Members");

                    b.Navigation("Teams");
                });

            modelBuilder.Entity("Kolokwium2.Models.Team", b =>
                {
                    b.Navigation("Files");
                });
#pragma warning restore 612, 618
        }
    }
}
