﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkForceManagement.API.Models;

namespace WorkForceManagement.API.Migrations
{
    [DbContext(typeof(WFMDbContext))]
    [Migration("20221004162432_updated")]
    partial class updated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WorkForceManagement.API.Models.Employees", b =>
                {
                    b.Property<int>("employee_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("employee_name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<decimal>("experience")
                        .HasColumnType("decimal(5,0)");

                    b.Property<string>("lockstatus")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("manager")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<int>("profile_id")
                        .HasColumnType("int");

                    b.Property<int?>("profilesprofile_id")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("wfm_manager")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("employee_id");

                    b.HasIndex("profilesprofile_id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("WorkForceManagement.API.Models.Profiles", b =>
                {
                    b.Property<int>("profile_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("profile_name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("profile_id");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("WorkForceManagement.API.Models.Skillmaps", b =>
                {
                    b.Property<int>("employee_id")
                        .HasColumnType("int");

                    b.Property<int>("skillid")
                        .HasColumnType("int");

                    b.HasKey("employee_id", "skillid");

                    b.HasIndex("skillid");

                    b.ToTable("Skillmaps");
                });

            modelBuilder.Entity("WorkForceManagement.API.Models.Skills", b =>
                {
                    b.Property<int>("skillid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("skillname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("skillid");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("WorkForceManagement.API.Models.Softlocks", b =>
                {
                    b.Property<int>("lockid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("employee_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("lastupdated")
                        .HasColumnType("datetime");

                    b.Property<string>("manager")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("managerstatus")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)")
                        .HasDefaultValue("awaiting_approval");

                    b.Property<DateTime>("mgrlastupdate")
                        .HasColumnType("datetime");

                    b.Property<string>("mgrstatuscomment")
                        .HasColumnType("varchar");

                    b.Property<DateTime>("reqdate")
                        .HasColumnType("datetime");

                    b.Property<string>("requestmessage")
                        .HasColumnType("varchar");

                    b.Property<string>("status")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("wfmremark")
                        .HasColumnType("varchar");

                    b.HasKey("lockid");

                    b.HasIndex("employee_id");

                    b.ToTable("Softlocks");
                });

            modelBuilder.Entity("WorkForceManagement.API.Models.Users", b =>
                {
                    b.Property<string>("username")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("email")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.HasKey("username");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WorkForceManagement.API.Models.Employees", b =>
                {
                    b.HasOne("WorkForceManagement.API.Models.Profiles", "profiles")
                        .WithMany("employees")
                        .HasForeignKey("profilesprofile_id");

                    b.Navigation("profiles");
                });

            modelBuilder.Entity("WorkForceManagement.API.Models.Skillmaps", b =>
                {
                    b.HasOne("WorkForceManagement.API.Models.Employees", "employees")
                        .WithMany("skillmaps")
                        .HasForeignKey("employee_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WorkForceManagement.API.Models.Skills", "skills")
                        .WithMany("skillmaps")
                        .HasForeignKey("skillid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("employees");

                    b.Navigation("skills");
                });

            modelBuilder.Entity("WorkForceManagement.API.Models.Softlocks", b =>
                {
                    b.HasOne("WorkForceManagement.API.Models.Employees", "employees")
                        .WithMany("softlocks")
                        .HasForeignKey("employee_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("employees");
                });

            modelBuilder.Entity("WorkForceManagement.API.Models.Employees", b =>
                {
                    b.Navigation("skillmaps");

                    b.Navigation("softlocks");
                });

            modelBuilder.Entity("WorkForceManagement.API.Models.Profiles", b =>
                {
                    b.Navigation("employees");
                });

            modelBuilder.Entity("WorkForceManagement.API.Models.Skills", b =>
                {
                    b.Navigation("skillmaps");
                });
#pragma warning restore 612, 618
        }
    }
}
