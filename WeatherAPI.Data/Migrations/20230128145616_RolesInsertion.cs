using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherAPI.Data.Migrations
{
    public partial class RolesInsertion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cac43a6e-f7bb-4448-baaf-1add460ccbbe", "c5948e1a-99c1-4f69-a113-5cbb5a3302bc", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac43a6e-f7bb-4448-baaf-1add460ccbbe");
        }
    }
}
