using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Persistence.Migrations
{
    public partial class adduserrolesseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetRoles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d0206ed4-6471-4147-98fc-845c2fc68357", "6b518f73-f2f0-4551-a1f3-9fb45c946001", "admin", "ADMIN" },
                    { "a6d64e82-dc6c-49c5-aa9a-c1d115bf883e", "4450cef9-d7b4-4118-a571-21a3d09a3ded", "authorizedUser", "AUTHORIZEDUSER" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "b717f837-7751-4d08-b9c9-8ce854a0eadc", "Top news" },
                    { "92afd8a8-5e75-494d-86b9-7ff166907a16", "Sports" },
                    { "fbd50568-b3a0-49fb-a3fe-b9dd787606fa", "Science" },
                    { "f9192ce5-762b-4089-af58-c781ba9a7a14", "Technology" },
                    { "211ec497-e299-4194-bc2b-fea6295aec08", "Movies" },
                    { "899ad7ac-acc2-4a05-9abc-577bed4a8c55", "Game's news" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Color", "Name" },
                values: new object[,]
                {
                    { "d4a81c80-db0c-4136-ac05-a91ff6f20ef5", "#FFD133", "Popular" },
                    { "e74d9651-bd1f-4b0c-80ee-ff25be5843e8", "#33BBFF", "Education" },
                    { "2097cf69-8b69-4c61-82a3-49bc4b29c96f", "#6833FF", "Unbelievable" },
                    { "2dee6497-f15a-4976-829e-fedcd00ec03b", "#07BA1F", "Useful" },
                    { "1c9c0cb9-f166-4b7e-bb0b-8bac949a4f8d", "#000000", "Issue" },
                    { "ede05c92-1b55-400b-b0db-e6d5d6cfea62", "#FF0000", "Non Popular" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6d64e82-dc6c-49c5-aa9a-c1d115bf883e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d0206ed4-6471-4147-98fc-845c2fc68357");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "211ec497-e299-4194-bc2b-fea6295aec08");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "899ad7ac-acc2-4a05-9abc-577bed4a8c55");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "92afd8a8-5e75-494d-86b9-7ff166907a16");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "b717f837-7751-4d08-b9c9-8ce854a0eadc");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "f9192ce5-762b-4089-af58-c781ba9a7a14");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "fbd50568-b3a0-49fb-a3fe-b9dd787606fa");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "1c9c0cb9-f166-4b7e-bb0b-8bac949a4f8d");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "2097cf69-8b69-4c61-82a3-49bc4b29c96f");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "2dee6497-f15a-4976-829e-fedcd00ec03b");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "d4a81c80-db0c-4136-ac05-a91ff6f20ef5");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "e74d9651-bd1f-4b0c-80ee-ff25be5843e8");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: "ede05c92-1b55-400b-b0db-e6d5d6cfea62");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetRoles",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

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
        }
    }
}
