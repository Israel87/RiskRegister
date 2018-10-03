using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RiskRegisterII.Migrations
{
    public partial class editedcomplaintregister : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "complaintRegisters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NameofClient = table.Column<string>(nullable: true),
                    ContactDetails = table.Column<string>(nullable: true),
                    DateReceived = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ContactPerson = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_complaintRegisters", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "complaintRegisters");
        }
    }
}
