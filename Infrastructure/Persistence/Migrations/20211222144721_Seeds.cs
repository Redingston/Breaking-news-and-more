using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class Seeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LastTimeUpdated",
                table: "BreakingNews",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TimeCreated",
                table: "BreakingNews",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "698dbc20-62b4-404d-a926-ad2d2b818b40", "Top news" },
                    { "8c4d5578-02c6-4ed3-bc0a-3e50bdc09f58", "Sports" },
                    { "38c2c698-2f7b-4e23-a8b5-b8928b26ec4b", "Science" },
                    { "2dc96826-9160-4c98-8ee2-99eda37aa3df", "Technology" },
                    { "52c86005-cf02-41af-b3e8-a517837faf89", "Movies" },
                    { "a689f845-1c45-48c7-b722-88ff433b9c46", "Game's news" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Color", "Name" },
                values: new object[,]
                {
                    { "daa2143b-f2d0-4118-a11d-902d033d2ed8", "#FFD133", "Popular" },
                    { "4379bc33-9bd8-4853-afd1-ea192caefbe0", "#33BBFF", "Education" },
                    { "941fbf5a-f3eb-4788-ba8f-4abcacade5a3", "#6833FF", "Unbelievable" },
                    { "9007ab1b-f5b9-458b-ac3b-3b101672f9e3", "#07BA1F", "Useful" },
                    { "b4438afb-9770-4fc0-8efa-6dd506adcf18", "#000000", "Issue" },
                    { "e7d8aba5-696f-414a-b922-c2bfbdeb72d8", "#FF0000", "Non Popular" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "2dc96826-9160-4c98-8ee2-99eda37aa3df");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "38c2c698-2f7b-4e23-a8b5-b8928b26ec4b");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "52c86005-cf02-41af-b3e8-a517837faf89");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "698dbc20-62b4-404d-a926-ad2d2b818b40");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "8c4d5578-02c6-4ed3-bc0a-3e50bdc09f58");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "a689f845-1c45-48c7-b722-88ff433b9c46");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "4379bc33-9bd8-4853-afd1-ea192caefbe0");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "9007ab1b-f5b9-458b-ac3b-3b101672f9e3");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "941fbf5a-f3eb-4788-ba8f-4abcacade5a3");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "b4438afb-9770-4fc0-8efa-6dd506adcf18");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "daa2143b-f2d0-4118-a11d-902d033d2ed8");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "e7d8aba5-696f-414a-b922-c2bfbdeb72d8");

            migrationBuilder.DropColumn(
                name: "LastTimeUpdated",
                table: "BreakingNews");

            migrationBuilder.DropColumn(
                name: "TimeCreated",
                table: "BreakingNews");
        }
    }
}
