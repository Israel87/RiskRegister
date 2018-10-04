using Microsoft.EntityFrameworkCore.Migrations;

namespace RiskRegisterII.Migrations
{
    public partial class adjustedtheregisterriskmodelwithariskbucketproperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_riskTypes_riskRegisters_RegisterRiskId",
                table: "riskTypes");

            migrationBuilder.DropIndex(
                name: "IX_riskTypes_RegisterRiskId",
                table: "riskTypes");

            migrationBuilder.DropColumn(
                name: "RegisterRiskId",
                table: "riskTypes");

            migrationBuilder.AddColumn<string>(
                name: "RiskBucket",
                table: "riskRegisters",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RiskBucket",
                table: "riskRegisters");

            migrationBuilder.AddColumn<int>(
                name: "RegisterRiskId",
                table: "riskTypes",
                nullable: true);

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
    }
}
