using Microsoft.EntityFrameworkCore.Migrations;

namespace MielsJimmyScrumProjectDAL.Migrations
{
    public partial class NormalizedRolesSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d17f4e4-1a9e-439b-a88d-6e994a990fe7",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "f7e73a10-2237-4c11-a1e5-33e2d58a30ec", "SUPERADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4e5c024-99c5-43b1-847f-26585777f463",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "9b2fd355-e828-42c0-9683-b8f1ea6ec2ef", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb4302cf-f521-4fa9-b20a-0d4e59b703a5",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "5b9df086-17fd-4c12-a6e8-587e323137f0", "USER" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44102b7c-5da3-4d08-8466-c32914e3b5b8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "30077837-96d1-4ad3-a182-867221dd3ce1", "AQAAAAEAACcQAAAAEG+AyrHndwm+bI7Prz0DJKCZkpuodrWOj+IJlLZqNzCol6G2rvKqfsldCwUUY+zhJA==", "06ed472d-9b06-45b5-b941-c6247ac1b8dc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4fbb337df-8c68-4b09-b5ba-6f7f5046b44d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "483710d2-1696-4131-a6d9-d79afa30bc8d", "AQAAAAEAACcQAAAAEK7ytiunYJxaWDfqJk1EA8b4/jo/O+CnPEFX6WZFhmytq+2Wu2w6BEgwZDfzupn9lg==", "8f4c7b32-c261-47f3-8df6-a0e9d1409539" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "acdbea31-d27e-41a3-bc72-d420a1faf7e0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3108cbb5-2a95-4190-9494-3f1a86e9cad4", "AQAAAAEAACcQAAAAEM7JEXVOWTAEu5dLbeELFxDyVmtSILgEi4qU9KKxdJ9Poyt6H9bsrZdK5JzADfcegA==", "0ba828b4-351f-4266-ae81-892499cc5de7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ccd0fb63-3173-4ab2-a80b-731d9939ee70",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "766ac3a1-d3c1-48b4-a94d-0cad92cb6e0a", "AQAAAAEAACcQAAAAEJ84iNO2sTOLunCrRbyBQLJArAOd/OxS1QAFzKQ7fpEINWOll/74GNsUfFylVePYlw==", "a4eba6a7-9657-4e6d-9faf-09035ab947b7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d881b27e-7b82-4a27-b02a-d277f5e245ca",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9bcd2c97-47c9-44b0-a699-a39b69901527", "AQAAAAEAACcQAAAAEKIja5FqbW13r/y52NcW0EtljGd+FhNPmIoZ7zaOKWoZa5Dbp6oP2tqCJGHbxTa1IA==", "0e95c589-c603-4899-8b21-c80565a85e0b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "da262156-18ee-4fef-b465-f2ec8d19b569",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "26d61f5e-3ae5-482d-85ee-1ce4f6a31807", "AQAAAAEAACcQAAAAEGAymq2s6Z8QQAENcHyGGBqJqjPOu7k1WVK/ZeM83Cnr96o4mOFZy9iatQgaeOREHQ==", "1ec27899-4edc-44d4-aac1-71e19e044a70" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "df50bb3c-693a-4889-8bc6-c7059a20b529",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d7def929-934e-4d21-a36c-69975d9762f9", "AQAAAAEAACcQAAAAECIOIfz4k5p1b1TJn4CdjcatGB157K83zYNYSSLwjadsQkotVqaRde8CcURdAu22CQ==", "2362e048-ea84-4657-a5ad-178757a0516e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e615c429-b915-4312-871d-74287869debb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6d43fb80-d47b-40bd-80d1-7ea1adf4fe4b", "AQAAAAEAACcQAAAAEEG4S+3spvIldNewKfDe/LopbT+eaRcMDkbkeMtoFIXgcCicQ1jZi0uDnW4YYPfgQw==", "7e027ac9-4d02-4579-86c4-a19a57f11369" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff611b21-e8cf-40c9-931e-2c379163017a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2b34c13-9c90-45c0-9acd-1b8ca470fcea", "AQAAAAEAACcQAAAAEIFeC5GNv0o8baQDC+49oBMhvFt8TzXfTIela5OqEZ+k2xEQLyZwLoRRVrNJ0CxX7Q==", "7b5554ac-1f35-4088-8ed8-1b6785022837" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d17f4e4-1a9e-439b-a88d-6e994a990fe7",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "e70adf0c-2631-48c5-b65c-ba0d87782b2e", null });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4e5c024-99c5-43b1-847f-26585777f463",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "f6be40e4-8f98-4620-9133-d4d229e78497", null });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb4302cf-f521-4fa9-b20a-0d4e59b703a5",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "455bd7e7-9807-4772-a60b-00f0a88c252c", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44102b7c-5da3-4d08-8466-c32914e3b5b8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "91f6b202-66a9-4186-ad5a-cc682d78594b", "AQAAAAEAACcQAAAAEJP7tdXn5enneOXa4Mt6GlAhC6gIqwbHd4wd1N4bi0UMM8zmegJ0QV6VQHweI6LJ0w==", "c7817e45-ae28-4ec2-9db2-3ae3380d2aac" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4fbb337df-8c68-4b09-b5ba-6f7f5046b44d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "95d56634-8170-4ecb-915b-cbdc6ce969a0", "AQAAAAEAACcQAAAAEPf++9pUjkFQtQUj3gT3dwIs3hHiN3eLH68Rguw9RT16VZTA2OqG9/HhuV1c92KZ0g==", "4c592b83-89d6-4dad-b8f3-a9203c197271" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "acdbea31-d27e-41a3-bc72-d420a1faf7e0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4106f2dd-aec9-44f7-9925-1fdee559093b", "AQAAAAEAACcQAAAAEEwfQB/x5CR8KybVnr6nDc+DlNN5vsOqPIPKsc6oH4v24v0dXnla91pubcsdeUlrkA==", "c44f9381-f4d8-4529-9986-881c0b7df2a8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ccd0fb63-3173-4ab2-a80b-731d9939ee70",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52efd208-eb4a-4539-a520-c64fdab1c7cd", "AQAAAAEAACcQAAAAEGRsRe/Y/Sf+OWC7wS1sgvvARapQHgmjTnBT2as5xf08nDevSnDQzLam4Zili8y8jQ==", "8b2b5d14-5806-4963-a3d9-71f9845e44ce" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d881b27e-7b82-4a27-b02a-d277f5e245ca",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0656ffb6-633c-4e16-a4c6-ee3770ebb080", "AQAAAAEAACcQAAAAEBiLpIGK/61pQcXefPEfhIv4xp31TrskYKnVtmFGGoWo9UbCa0uhPvOSXFfzY5tJxg==", "2f054365-eb8f-4ae3-9182-dbb08a04eb54" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "da262156-18ee-4fef-b465-f2ec8d19b569",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4b68607-0a28-43e5-ac6f-67c8611761d8", "AQAAAAEAACcQAAAAENT1GxjPRmc70nk7fFGVmVuHsEeEnjhnrHrCVUVw5E9RWHDJwsJ54amuPZ/Mbc/RIA==", "9791d93c-3c5f-47a5-878f-dee9a579bc9a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "df50bb3c-693a-4889-8bc6-c7059a20b529",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ee36f0eb-de73-4ba4-8c69-0a8b29fa5515", "AQAAAAEAACcQAAAAEJaS3syaPs38YLKXDAaC5mhiDuzBTIBVIu48TKQCAxUUB8qAyskGna3ilRyHrZLhKg==", "25f8f121-e978-4848-bb73-9b00985719f1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e615c429-b915-4312-871d-74287869debb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "37e827cc-c28f-410c-ba5f-261555e649b3", "AQAAAAEAACcQAAAAEFJd4cwvIZQKjsg9WyHuIixiYG6hUYDbFVsqJHj7+wFVo/zSSI5tPZHq9VGrpKanTw==", "7486b414-71a2-4678-b64a-8d5188b76ecc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff611b21-e8cf-40c9-931e-2c379163017a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1be2603c-e263-4dda-a5f1-a293d5dea211", "AQAAAAEAACcQAAAAEGIc+fqRN56wuuuIfVd29ZIm7JEjPoHm9aJR49gXzN4nupnPxeaBxC1OyVNCrD1djA==", "1564e53f-d38c-4569-9d41-4a949c01b765" });
        }
    }
}
