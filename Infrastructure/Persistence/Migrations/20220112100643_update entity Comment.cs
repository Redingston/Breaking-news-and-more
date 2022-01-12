using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class updateentityComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "2f79c615-8d86-496e-a467-88a4573b6dd4", "Top news" },
                    { "cf945d56-273f-475f-9210-240095c0b8e2", "Sports" },
                    { "c1d45dc1-ee65-447e-89ea-cfbd96222262", "Science" },
                    { "055af927-c448-40f3-a6cf-9a18f92b87a9", "Technology" },
                    { "1bc9bf9d-a3cf-4b90-b39a-adf9990c1a76", "Movies" },
                    { "596a95bf-3100-4fc5-a009-bc5fecd85da4", "Game's news" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Color", "Name" },
                values: new object[,]
                {
                    { "b57261e7-3b29-451c-af3d-ca529c88c20b", "#FFD133", "Popular" },
                    { "7ea6afd4-170f-468d-9ce0-fae278c411dd", "#33BBFF", "Education" },
                    { "eed4993d-d28e-4b98-ac3c-8ddd34d79356", "#6833FF", "Unbelievable" },
                    { "1a4a90c9-43a5-4c9c-994d-0756a7c7b8f3", "#07BA1F", "Useful" },
                    { "62f57043-fc7a-4f9a-9572-40c9120abc27", "#000000", "Issue" },
                    { "1920993f-017d-4b71-af7f-0e4005b05d1c", "#FF0000", "Non Popular" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "055af927-c448-40f3-a6cf-9a18f92b87a9");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "1bc9bf9d-a3cf-4b90-b39a-adf9990c1a76");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "2f79c615-8d86-496e-a467-88a4573b6dd4");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "596a95bf-3100-4fc5-a009-bc5fecd85da4");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "c1d45dc1-ee65-447e-89ea-cfbd96222262");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "cf945d56-273f-475f-9210-240095c0b8e2");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "1920993f-017d-4b71-af7f-0e4005b05d1c");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "1a4a90c9-43a5-4c9c-994d-0756a7c7b8f3");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "62f57043-fc7a-4f9a-9572-40c9120abc27");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "7ea6afd4-170f-468d-9ce0-fae278c411dd");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "b57261e7-3b29-451c-af3d-ca529c88c20b");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "eed4993d-d28e-4b98-ac3c-8ddd34d79356");

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
                    { "a689f845-1c45-48c7-b722-88ff433b9c46", "Game news" }
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
    }
}
