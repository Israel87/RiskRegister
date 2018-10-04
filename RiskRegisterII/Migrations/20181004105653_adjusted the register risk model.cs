using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RiskRegisterII.Migrations
{
    public partial class adjustedtheregisterriskmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RegisterRiskId",
                table: "riskTypes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "riskRegisters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Activity = table.Column<string>(nullable: true),
                    InherentRisk = table.Column<string>(nullable: true),
                    Mitigants = table.Column<string>(nullable: true),
                    LoggedBy = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_riskRegisters", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_riskTypes_RegisterRiskId",
                table: "riskTypes",
                column: "RegisterRiskId");

            migrationBuilder.AddForeignKey(
                name: "FK_riskTypes_riskRegisters_RegisterRiskId",
                table: "riskTypes",
                column: "RegisterRiskId",
                principalTable: "riskRegisters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_riskTypes_riskRegisters_RegisterRiskId",
                table: "riskTypes");

            migrationBuilder.DropTable(
                name: "riskRegisters");

            migrationBuilder.DropIndex(
                name: "IX_riskTypes_RegisterRiskId",
                table: "riskTypes");

            migrationBuilder.DropColumn(
                name: "RegisterRiskId",
                table: "riskTypes");
        }
    }
}
