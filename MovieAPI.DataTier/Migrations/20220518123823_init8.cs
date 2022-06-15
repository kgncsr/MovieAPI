using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieAPI.DataTier.Migrations
{
    public partial class init8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateOfBirth",
                table: "Users",
                newName: "BirthDate");

            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "Users",
                newName: "Token");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "TokenExpireDate",
                table: "Users",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TokenExpireDate",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Token",
                table: "Users",
                newName: "Adress");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "Users",
                newName: "DateOfBirth");
        }
    }
}
