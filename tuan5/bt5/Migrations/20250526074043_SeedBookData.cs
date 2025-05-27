using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace buoi5.Migrations
{
    /// <inheritdoc />
    public partial class SeedBookData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Lập trình" },
                    { 2, "Kỹ năng sống" },
                    { 3, "Thiếu nhi" },
                    { 4, "Tâm lý - Giáo dục" },
                    { 5, "Khoa học phổ thông" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "CategoryId", "Image", "Price", "Title" },
                values: new object[,]
                {
                    { "B00001", "Nguyễn Văn A", 1, "csharpcanban.jpg", 85000m, "C# căn bản cho người mới bắt đầu" },
                    { "B00002", "Trần Thị B", 1, "aspnetcoremvc.jpg", 110000m, "ASP.NET Core MVC thực chiến" },
                    { "B00003", "Robert Kiyosaki", 2, "dayconlamgiau.jpg", 99000m, "Dạy con làm giàu" },
                    { "B00004", "Nguyễn Nhật Ánh", 3, "tohoclaptrinh.jpg", 75000m, "Tớ học lập trình" },
                    { "B00005", "Gary Chapman", 4, "5ngonngutinhyeu.jpg", 105000m, "5 ngôn ngữ tình yêu" },
                    { "B00006", "Stephen Hawking", 5, "vutrutrongvo.jpg", 120000m, "Vũ trụ trong vỏ hạt dẻ" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: "B00001");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: "B00002");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: "B00003");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: "B00004");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: "B00005");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: "B00006");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5);
        }
    }
}
