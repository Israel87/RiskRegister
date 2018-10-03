using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RiskRegisterII.Migrations
{
    public partial class addeddateupdatedtotheerrorregistermodule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateUpdated",
                table: "errorRegisters",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "errorRegisters",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateUpdated",
                table: "errorRegisters");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "errorRegisters");
        }
    }
}
