﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RiskRegisterII.Data;

namespace RiskRegisterII.Migrations
{
    [DbContext(typeof(RiskRegisterDbContext))]
    partial class RiskRegisterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RiskRegister.Models.ActionTaken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Description");

                    b.Property<DateTime?>("LastUpdated");

                    b.Property<int?>("RiskMonitorId");

                    b.Property<int>("Status");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("RiskMonitorId");

                    b.ToTable("ActionTaken");
                });

            modelBuilder.Entity("RiskRegister.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Name");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("RiskRegister.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Name");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("RiskRegister.Models.RiskMonitor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("LastUpdated");

                    b.Property<string>("ReferenceId");

                    b.Property<int?>("RiskTypeId");

                    b.Property<int>("Status");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("RiskTypeId");

                    b.ToTable("RiskMonitors");
                });

            modelBuilder.Entity("RiskRegister.Models.RiskType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Name");

                    b.Property<int>("Status");

                    b.Property<string>("ViewId");

                    b.HasKey("Id");

                    b.ToTable("RiskTypes");
                });

            modelBuilder.Entity("RiskRegisterII.Models.ComplaintRegister", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactPerson");

                    b.Property<DateTime>("DateReceived");

                    b.Property<string>("Description");

                    b.Property<string>("EmailAddress");

                    b.Property<string>("NameofClient");

                    b.Property<string>("PhoneNumber");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("ComplaintRegisters");
                });

            modelBuilder.Entity("RiskRegisterII.Models.ErrorRegisterModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime?>("DateUpdated");

                    b.Property<int>("DepartmentId");

                    b.Property<int>("ErrorStatus");

                    b.Property<string>("ErrorType");

                    b.Property<string>("Narration");

                    b.Property<string>("Officer");

                    b.Property<string>("Remark");

                    b.Property<int>("RiskTypeId");

                    b.Property<int>("Status");

                    b.Property<string>("UpdatedBy");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("RiskTypeId");

                    b.ToTable("ErrorRegisters");
                });

            modelBuilder.Entity("RiskRegisterII.Models.RegisterRisk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Activity");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("InherentRisk");

                    b.Property<string>("LoggedBy");

                    b.Property<string>("Mitigants");

                    b.Property<int>("RiskTypeId");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.HasIndex("RiskTypeId");

                    b.ToTable("RiskRegisters");
                });

            modelBuilder.Entity("RiskRegisterII.Models.Role", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("EnteredBy");

                    b.Property<DateTime>("EntryDate");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("RiskRegisterII.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConfirmationToken");

                    b.Property<string>("EnteredBy");

                    b.Property<DateTime>("EntryDate");

                    b.Property<bool>("IsBlocked");

                    b.Property<bool>("IsConfirm");

                    b.Property<string>("Password");

                    b.Property<string>("PasswordRecovery");

                    b.Property<string>("Username");

                    b.HasKey("ID");

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasFilter("[Username] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RiskRegisterII.Models.UserDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("EnteredBy");

                    b.Property<DateTime>("EntryDate");

                    b.Property<string>("FirstName");

                    b.Property<int>("Gender");

                    b.Property<string>("Lastname");

                    b.Property<string>("MiddleName");

                    b.Property<string>("Phone");

                    b.Property<int>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("UserDetails");
                });

            modelBuilder.Entity("RiskRegisterII.Models.UserRole", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EnteredBy");

                    b.Property<DateTime>("EntryDate");

                    b.Property<int>("RoleID");

                    b.Property<int>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("RoleID");

                    b.HasIndex("UserID");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("RiskRegister.Models.ActionTaken", b =>
                {
                    b.HasOne("RiskRegister.Models.RiskMonitor")
                        .WithMany("ActionsTaken")
                        .HasForeignKey("RiskMonitorId");
                });

            modelBuilder.Entity("RiskRegister.Models.RiskMonitor", b =>
                {
                    b.HasOne("RiskRegister.Models.RiskType", "RiskType")
                        .WithMany()
                        .HasForeignKey("RiskTypeId");
                });

            modelBuilder.Entity("RiskRegisterII.Models.ErrorRegisterModel", b =>
                {
                    b.HasOne("RiskRegister.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RiskRegister.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RiskRegister.Models.RiskType", "RiskType")
                        .WithMany()
                        .HasForeignKey("RiskTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RiskRegisterII.Models.RegisterRisk", b =>
                {
                    b.HasOne("RiskRegister.Models.RiskType", "RiskType")
                        .WithMany()
                        .HasForeignKey("RiskTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RiskRegisterII.Models.UserDetail", b =>
                {
                    b.HasOne("RiskRegisterII.Models.User", "User")
                        .WithOne("UserDetail")
                        .HasForeignKey("RiskRegisterII.Models.UserDetail", "UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RiskRegisterII.Models.UserRole", b =>
                {
                    b.HasOne("RiskRegisterII.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RiskRegisterII.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
