using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherAPI.Data.Migrations
{
    public partial class AddedFirstNameAndLastNameToAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add460ccbbe",
                column: "ConcurrencyStamp",
                value: "c3d7333f-96e1-4143-910b-927e18f08657");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add460ccbbe",
                column: "ConcurrencyStamp",
                value: "c5948e1a-99c1-4f69-a113-5cbb5a3302bc");
        }
    }
}
