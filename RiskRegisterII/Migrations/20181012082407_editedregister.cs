using Microsoft.EntityFrameworkCore.Migrations;

namespace RiskRegisterII.Migrations
{
    public partial class editedregister : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RiskRegisters_RiskTypes_RiskTypeId",
                table: "RiskRegisters");

            migrationBuilder.DropIndex(
                name: "IX_RiskRegisters_RiskTypeId",
                table: "RiskRegisters");

            migrationBuilder.AddColumn<string>(
                name: "RiskName",
                table: "RiskRegisters",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RiskName",
                table: "RiskRegisters");

            migrationBuilder.CreateIndex(
                name: "IX_RiskRegisters_RiskTypeId",
                table: "RiskRegisters",
                column: "RiskTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RiskRegisters_RiskTypes_RiskTypeId",
                table: "RiskRegisters",
                column: "RiskTypeId",
                principalTable: "RiskTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
