using Microsoft.EntityFrameworkCore.Migrations;

namespace RiskRegisterII.Migrations
{
    public partial class testingtheregisterriskmodel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_riskRegisters_riskTypes_RiskTypeId",
                table: "riskRegisters");

            migrationBuilder.DropColumn(
                name: "RiskTypeName",
                table: "riskRegisters");

            migrationBuilder.AlterColumn<int>(
                name: "RiskTypeId",
                table: "riskRegisters",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_riskRegisters_riskTypes_RiskTypeId",
                table: "riskRegisters",
                column: "RiskTypeId",
                principalTable: "riskTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_riskRegisters_riskTypes_RiskTypeId",
                table: "riskRegisters");

            migrationBuilder.AlterColumn<int>(
                name: "RiskTypeId",
                table: "riskRegisters",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "RiskTypeName",
                table: "riskRegisters",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_riskRegisters_riskTypes_RiskTypeId",
                table: "riskRegisters",
                column: "RiskTypeId",
                principalTable: "riskTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
