using Microsoft.EntityFrameworkCore.Migrations;

namespace RiskRegisterII.Migrations
{
    public partial class editedthecomplaintregistermodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContactDetails",
                table: "complaintRegisters",
                newName: "PhoneNumber");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "complaintRegisters",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "complaintRegisters");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "complaintRegisters",
                newName: "ContactDetails");
        }
    }
}
