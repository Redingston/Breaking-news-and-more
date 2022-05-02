using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "33e9dd36-73ec-483d-8ff5-6d9c9755d5c6", "Top news" },
                    { "45d9492c-a836-45ce-8674-d0dbe63c981c", "Sports" },
                    { "268e0814-6b67-4819-adbe-31ea56c8f759", "Science" },
                    { "c9fc7507-93a2-4009-9c5d-5765fef44ad1", "Technology" },
                    { "aebdabee-82b6-4df9-9245-d238c70458a5", "Movies" },
                    { "60fd95a4-ea62-450a-a522-9e6df15c3e47", "Game's news" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Color", "Name" },
                values: new object[,]
                {
                    { "57552b13-3540-40a4-bfa4-2f363b29eebf", "#FFD133", "Popular" },
                    { "ba3b82d0-dc8f-4adb-8875-88e25e9f54f3", "#33BBFF", "Education" },
                    { "0ef6f27d-0ee4-4c09-8bb9-a8d23b508b10", "#6833FF", "Unbelievable" },
                    { "01d0a7f4-0ab1-464c-a0f9-090bee721382", "#07BA1F", "Useful" },
                    { "e33faea2-7b10-4ebf-abfb-71d6aa9941f9", "#000000", "Issue" },
                    { "9955fd85-cc2e-48ab-b847-b40400bef989", "#FF0000", "Non Popular" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "268e0814-6b67-4819-adbe-31ea56c8f759");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "33e9dd36-73ec-483d-8ff5-6d9c9755d5c6");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "45d9492c-a836-45ce-8674-d0dbe63c981c");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "60fd95a4-ea62-450a-a522-9e6df15c3e47");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "aebdabee-82b6-4df9-9245-d238c70458a5");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "c9fc7507-93a2-4009-9c5d-5765fef44ad1");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "01d0a7f4-0ab1-464c-a0f9-090bee721382");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "0ef6f27d-0ee4-4c09-8bb9-a8d23b508b10");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "57552b13-3540-40a4-bfa4-2f363b29eebf");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "9955fd85-cc2e-48ab-b847-b40400bef989");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "ba3b82d0-dc8f-4adb-8875-88e25e9f54f3");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "e33faea2-7b10-4ebf-abfb-71d6aa9941f9");

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
    }
}
