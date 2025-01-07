using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodMenu.Migrations
{
    /// <inheritdoc />
    public partial class Updatingpictures : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://www.kulinar.cz/uploads/media/default/0001/01/thumb_676_default_big.jpeg");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://1884403144.rsc.cdn77.org/foto/smazak-syr/NDk4eDI4OC9jZW50ZXIvbWlkZGxlL3NtYXJ0L2ZpbHRlcnM6cXVhbGl0eSg4NSkvaW1n/3433384.jpg?v=0&st=FdPWU4F-PU22Qj8j33mYOEtoB67hEQg9Hlf7t9N7c-s&ts=1600812000&e=0");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://assets.tmecosys.com/image/upload/t_web767x639/img/recipe/ras/Assets/69EE02DA-213D-44A2-8B08-A590225B221B/Derivates/F40AD961-73B3-4E31-BC0F-A173E296F841.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://sl.bing.net/hU2GbJ0bHZk");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://sl.bing.net/icCY8QK8c1c");

            migrationBuilder.UpdateData(
                table: "Dishes",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://sl.bing.net/h7PZLOZ90LY");
        }
    }
}
