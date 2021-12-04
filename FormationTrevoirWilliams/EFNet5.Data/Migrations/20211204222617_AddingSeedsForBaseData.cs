using Microsoft.EntityFrameworkCore.Migrations;

namespace EFNet5.Data.Migrations
{
    public partial class AddingSeedsForBaseData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Coaches",
                columns: new[] { "Id", "Name", "TeamId" },
                values: new object[] { 20, "Columbus Bears", null });

            migrationBuilder.InsertData(
                table: "Coaches",
                columns: new[] { "Id", "Name", "TeamId" },
                values: new object[] { 21, "Doggo's Fangs", null });

            migrationBuilder.InsertData(
                table: "Leagues",
                columns: new[] { "Id", "Name" },
                values: new object[] { 21, "Animals" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "LeagueId", "Name" },
                values: new object[] { 20, 21, "Columbus Bears" });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "LeagueId", "Name" },
                values: new object[] { 21, 21, "Doggo's Fangs" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Coaches",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Leagues",
                keyColumn: "Id",
                keyValue: 21);
        }
    }
}
