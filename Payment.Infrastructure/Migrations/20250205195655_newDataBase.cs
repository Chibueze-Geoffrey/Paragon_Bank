using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Payment.Infrastructure.Migrations
{
    public partial class newDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19357fc8-9556-4491-be37-03858c43b295");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b704aa7-dea4-4a0f-a07c-aba9023f071a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be478439-a81b-4880-bbcc-491343a11c4c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "008a448e-e4ea-4e1e-9fd6-fb38079789c9", "efea64c0-5845-4ea8-810f-d72a2bf3c63b", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7b1af8c7-6fc3-445b-b4d8-758ecfbda7b1", "d9c00b23-0420-4080-9b5a-764122c427f7", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "be4ae09d-5759-411f-ac8f-0986ab96de48", "a96a5931-fb77-4f68-9445-f304ff5d7785", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "008a448e-e4ea-4e1e-9fd6-fb38079789c9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b1af8c7-6fc3-445b-b4d8-758ecfbda7b1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "be4ae09d-5759-411f-ac8f-0986ab96de48");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "19357fc8-9556-4491-be37-03858c43b295", "87473a26-d96e-41e6-80c5-2d55021ff529", "Customer", "CUSTOMER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9b704aa7-dea4-4a0f-a07c-aba9023f071a", "c9aeca43-849b-452f-ac6f-6a73680a0df0", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "be478439-a81b-4880-bbcc-491343a11c4c", "d5c0cd23-1a3b-440f-b237-9361a0af2cb2", "Administrator", "ADMINISTRATOR" });
        }
    }
}
