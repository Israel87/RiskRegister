using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RiskRegisterII.Migrations
{
    public partial class Initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "complaintRegisters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameofClient = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    DateReceived = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ContactPerson = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_complaintRegisters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "riskTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ViewId = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_riskTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "errorRegisters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    ErrorType = table.Column<string>(nullable: true),
                    Narration = table.Column<string>(nullable: true),
                    Officer = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    ErrorStatus = table.Column<int>(nullable: false),
                    Remark = table.Column<string>(nullable: true),
                    RiskTypeId = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_errorRegisters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_errorRegisters_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_errorRegisters_departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_errorRegisters_riskTypes_RiskTypeId",
                        column: x => x.RiskTypeId,
                        principalTable: "riskTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "riskMonitors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RiskTypeId = table.Column<int>(nullable: true),
                    ReferenceId = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_riskMonitors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_riskMonitors_riskTypes_RiskTypeId",
                        column: x => x.RiskTypeId,
                        principalTable: "riskTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "riskRegisters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Activity = table.Column<string>(nullable: true),
                    RiskTypeId = table.Column<int>(nullable: false),
                    InherentRisk = table.Column<string>(nullable: true),
                    Mitigants = table.Column<string>(nullable: true),
                    LoggedBy = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_riskRegisters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_riskRegisters_riskTypes_RiskTypeId",
                        column: x => x.RiskTypeId,
                        principalTable: "riskTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActionTaken",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    RiskMonitorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionTaken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActionTaken_riskMonitors_RiskMonitorId",
                        column: x => x.RiskMonitorId,
                        principalTable: "riskMonitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionTaken_RiskMonitorId",
                table: "ActionTaken",
                column: "RiskMonitorId");

            migrationBuilder.CreateIndex(
                name: "IX_errorRegisters_CompanyId",
                table: "errorRegisters",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_errorRegisters_DepartmentId",
                table: "errorRegisters",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_errorRegisters_RiskTypeId",
                table: "errorRegisters",
                column: "RiskTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_riskMonitors_RiskTypeId",
                table: "riskMonitors",
                column: "RiskTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_riskRegisters_RiskTypeId",
                table: "riskRegisters",
                column: "RiskTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionTaken");

            migrationBuilder.DropTable(
                name: "complaintRegisters");

            migrationBuilder.DropTable(
                name: "errorRegisters");

            migrationBuilder.DropTable(
                name: "riskRegisters");

            migrationBuilder.DropTable(
                name: "riskMonitors");

            migrationBuilder.DropTable(
                name: "companies");

            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropTable(
                name: "riskTypes");
        }
    }
}
