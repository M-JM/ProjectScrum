using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MielsJimmyScrumProjectDAL.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "BoardUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "BoardUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "BoardUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "BoardUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "BoardUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9d17f4e4-1a9e-439b-a88d-6e994a990fe7", "e70adf0c-2631-48c5-b65c-ba0d87782b2e", "SuperAdmin", null },
                    { "b4e5c024-99c5-43b1-847f-26585777f463", "f6be40e4-8f98-4620-9133-d4d229e78497", "Admin", null },
                    { "fb4302cf-f521-4fa9-b20a-0d4e59b703a5", "455bd7e7-9807-4772-a60b-00f0a88c252c", "User", null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyId", "ConcurrencyStamp", "CreatedBy", "CreatedDate", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedBy", "UpdatedDate", "UserName" },
                values: new object[] { "da262156-18ee-4fef-b465-f2ec8d19b569", 0, null, "b4b68607-0a28-43e5-ac6f-67c8611761d8", "SuperAdmin@scrum.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "SuperAdmin@scrum.com", false, false, false, null, "SUPERADMIN@SCRUM.COM", "SUPERADMIN@SCRUM.COM", "AQAAAAEAACcQAAAAENT1GxjPRmc70nk7fFGVmVuHsEeEnjhnrHrCVUVw5E9RWHDJwsJ54amuPZ/Mbc/RIA==", null, false, "9791d93c-3c5f-47a5-878f-dee9a579bc9a", false, null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "SuperAdmin@scrum.com" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsDeleted", "Name", "PhotoPath", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "SuperAdmin@Scrum.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), false, "Asus LTD", "Asus-logo.jpg", null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified) },
                    { 2, "SuperAdmin@Scrum.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), false, "HP LTD", "hp-logo.jpg", null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "da262156-18ee-4fef-b465-f2ec8d19b569", "9d17f4e4-1a9e-439b-a88d-6e994a990fe7" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CompanyId", "ConcurrencyStamp", "CreatedBy", "CreatedDate", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UpdatedBy", "UpdatedDate", "UserName" },
                values: new object[,]
                {
                    { "44102b7c-5da3-4d08-8466-c32914e3b5b8", 0, 1, "91f6b202-66a9-4186-ad5a-cc682d78594b", "SuperAdmin@Scrum.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "Admin@Asus.com", false, false, false, null, "ADMIN@ASUS.COM", "ADMIN@ASUS.COM", "AQAAAAEAACcQAAAAEJP7tdXn5enneOXa4Mt6GlAhC6gIqwbHd4wd1N4bi0UMM8zmegJ0QV6VQHweI6LJ0w==", null, false, "c7817e45-ae28-4ec2-9db2-3ae3380d2aac", false, null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "Admin@Asus.com" },
                    { "df50bb3c-693a-4889-8bc6-c7059a20b529", 0, 1, "ee36f0eb-de73-4ba4-8c69-0a8b29fa5515", "Admin@Asus.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "User1@Asus.com", false, false, false, null, "USER1@ASUS.COM", "USER1@ASUS.COM", "AQAAAAEAACcQAAAAEJaS3syaPs38YLKXDAaC5mhiDuzBTIBVIu48TKQCAxUUB8qAyskGna3ilRyHrZLhKg==", null, false, "25f8f121-e978-4848-bb73-9b00985719f1", false, null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "User1@Asus.com" },
                    { "ccd0fb63-3173-4ab2-a80b-731d9939ee70", 0, 1, "52efd208-eb4a-4539-a520-c64fdab1c7cd", "Admin@Asus.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "User2@Asus.com", false, false, false, null, "USER2@ASUS.COM", "USER2@ASUS.COM", "AQAAAAEAACcQAAAAEGRsRe/Y/Sf+OWC7wS1sgvvARapQHgmjTnBT2as5xf08nDevSnDQzLam4Zili8y8jQ==", null, false, "8b2b5d14-5806-4963-a3d9-71f9845e44ce", false, null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "User2@Asus.com" },
                    { "e615c429-b915-4312-871d-74287869debb", 0, 1, "37e827cc-c28f-410c-ba5f-261555e649b3", "Admin@Asus.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "User3@Asus.com", false, false, false, null, "USER3@ASUS.COM", "USER3@ASUS.COM", "AQAAAAEAACcQAAAAEFJd4cwvIZQKjsg9WyHuIixiYG6hUYDbFVsqJHj7+wFVo/zSSI5tPZHq9VGrpKanTw==", null, false, "7486b414-71a2-4678-b64a-8d5188b76ecc", false, null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "User3@Asus.com" },
                    { "4fbb337df-8c68-4b09-b5ba-6f7f5046b44d", 0, 2, "95d56634-8170-4ecb-915b-cbdc6ce969a0", "SuperAdmin@Scrum.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "Admin@HP.com", false, false, false, null, "ADMIN@HP.COM", "ADMIN@HP.COM", "AQAAAAEAACcQAAAAEPf++9pUjkFQtQUj3gT3dwIs3hHiN3eLH68Rguw9RT16VZTA2OqG9/HhuV1c92KZ0g==", null, false, "4c592b83-89d6-4dad-b8f3-a9203c197271", false, null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "Admin@HP.com" },
                    { "acdbea31-d27e-41a3-bc72-d420a1faf7e0", 0, 2, "4106f2dd-aec9-44f7-9925-1fdee559093b", "Admin@HP.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "User1@HP.com", false, false, false, null, "USER1@HP.COM", "USER1@HP.COM", "AQAAAAEAACcQAAAAEEwfQB/x5CR8KybVnr6nDc+DlNN5vsOqPIPKsc6oH4v24v0dXnla91pubcsdeUlrkA==", null, false, "c44f9381-f4d8-4529-9986-881c0b7df2a8", false, null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "User1@HP.com" },
                    { "d881b27e-7b82-4a27-b02a-d277f5e245ca", 0, 2, "0656ffb6-633c-4e16-a4c6-ee3770ebb080", "Admin@HP.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "User2@HP.com", false, false, false, null, "USER2@HP.COM", "USER2@HP.COM", "AQAAAAEAACcQAAAAEBiLpIGK/61pQcXefPEfhIv4xp31TrskYKnVtmFGGoWo9UbCa0uhPvOSXFfzY5tJxg==", null, false, "2f054365-eb8f-4ae3-9182-dbb08a04eb54", false, null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "User2@HP.com" },
                    { "ff611b21-e8cf-40c9-931e-2c379163017a", 0, 2, "1be2603c-e263-4dda-a5f1-a293d5dea211", "Admin@HP.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "User3@HP.com", false, false, false, null, "USER3@HP.COM", "USER3@HP.COM", "AQAAAAEAACcQAAAAEGIc+fqRN56wuuuIfVd29ZIm7JEjPoHm9aJR49gXzN4nupnPxeaBxC1OyVNCrD1djA==", null, false, "1564e53f-d38c-4569-9d41-4a949c01b765", false, null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "User3@HP.com" }
                });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "CompanyId", "CreatedBy", "CreatedDate", "Description", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, "Admin@Asus.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), " New Design of Laptop model X", false, "Asus Laptop Design", null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified) },
                    { 2, 1, "Admin@Asus.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), " New Design of Desktop model X", false, "Asus Desktop Design", null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified) },
                    { 3, 1, "Admin@Asus.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), " New Design of Screen model X", false, "Asus Screen Design", null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified) },
                    { 4, 2, "Admin@HP.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), " New Design of Laptop model X", false, "HP Laptop Design", null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified) },
                    { 5, 2, "Admin@HP.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), " New Design of Desktop model X", false, "HP Desktop Design", null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified) },
                    { 6, 2, "Admin@HP.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), " New Design of Screen model X", false, "HP Screen Design", null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "44102b7c-5da3-4d08-8466-c32914e3b5b8", "b4e5c024-99c5-43b1-847f-26585777f463" },
                    { "df50bb3c-693a-4889-8bc6-c7059a20b529", "fb4302cf-f521-4fa9-b20a-0d4e59b703a5" },
                    { "ccd0fb63-3173-4ab2-a80b-731d9939ee70", "fb4302cf-f521-4fa9-b20a-0d4e59b703a5" },
                    { "e615c429-b915-4312-871d-74287869debb", "fb4302cf-f521-4fa9-b20a-0d4e59b703a5" },
                    { "ff611b21-e8cf-40c9-931e-2c379163017a", "fb4302cf-f521-4fa9-b20a-0d4e59b703a5" },
                    { "d881b27e-7b82-4a27-b02a-d277f5e245ca", "fb4302cf-f521-4fa9-b20a-0d4e59b703a5" },
                    { "acdbea31-d27e-41a3-bc72-d420a1faf7e0", "fb4302cf-f521-4fa9-b20a-0d4e59b703a5" },
                    { "4fbb337df-8c68-4b09-b5ba-6f7f5046b44d", "b4e5c024-99c5-43b1-847f-26585777f463" }
                });

            migrationBuilder.InsertData(
                table: "BoardUsers",
                columns: new[] { "BoardId", "ApplicationUserId", "CreatedBy", "CreatedDate", "IsDeleted", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 6, "acdbea31-d27e-41a3-bc72-d420a1faf7e0", "Admin@HP.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), false, null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified) },
                    { 5, "d881b27e-7b82-4a27-b02a-d277f5e245ca", "Admin@HP.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), false, null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified) },
                    { 5, "acdbea31-d27e-41a3-bc72-d420a1faf7e0", "Admin@HP.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), false, null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified) },
                    { 4, "acdbea31-d27e-41a3-bc72-d420a1faf7e0", "Admin@HP.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), false, null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified) },
                    { 6, "d881b27e-7b82-4a27-b02a-d277f5e245ca", "Admin@HP.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), false, null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified) },
                    { 3, "ccd0fb63-3173-4ab2-a80b-731d9939ee70", "Admin@Asus.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), false, null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified) },
                    { 3, "df50bb3c-693a-4889-8bc6-c7059a20b529", "Admin@Asus.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), false, null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified) },
                    { 3, "e615c429-b915-4312-871d-74287869debb", "Admin@Asus.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), false, null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified) },
                    { 1, "df50bb3c-693a-4889-8bc6-c7059a20b529", "Admin@Asus.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), false, null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified) },
                    { 2, "ccd0fb63-3173-4ab2-a80b-731d9939ee70", "Admin@Asus.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), false, null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified) },
                    { 2, "df50bb3c-693a-4889-8bc6-c7059a20b529", "Admin@Asus.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), false, null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified) },
                    { 6, "ff611b21-e8cf-40c9-931e-2c379163017a", "Admin@HP.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), false, null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedBy", "CreatedDate", "Description", "IsDeleted", "Status", "Title", "UpdatedBy", "UpdatedDate", "Userid" },
                values: new object[,]
                {
                    { 14, 3, "User1@Asus.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "Contact all our known wholesale distributors and open delivery channels ", false, 0, "Contact distribution list", null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "df50bb3c-693a-4889-8bc6-c7059a20b529" },
                    { 26, 5, "User2@HP.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "Contact all our known wholesale distributors and open delivery channels ", false, 0, "Contact distribution list", null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "d881b27e-7b82-4a27-b02a-d277f5e245ca" },
                    { 27, 5, "User2@HP.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "Set price point of new desktop", false, 2, "Price determination", null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "d881b27e-7b82-4a27-b02a-d277f5e245ca" },
                    { 3, 1, "Admin@Asus.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "Come up with a cool commercial name", false, 2, "new laptop name", null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "df50bb3c-693a-4889-8bc6-c7059a20b529" },
                    { 2, 1, "Admin@Asus.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "Send the specification list to the engineers", false, 0, "SEND SPEC LIST FOR REVIEW", null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "df50bb3c-693a-4889-8bc6-c7059a20b529" },
                    { 28, 6, "User3@HP.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "Draft a list of specification", false, 1, "SPEC LIST", null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "ff611b21-e8cf-40c9-931e-2c379163017a" },
                    { 29, 6, "User3@HP.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "Send the specification list to the engineers", false, 0, "SEND SPEC LIST FOR REVIEW", null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "ff611b21-e8cf-40c9-931e-2c379163017a" },
                    { 25, 5, "User2@HP.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "Start online marketing campaign", false, 1, "Marketing Campaign", null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "d881b27e-7b82-4a27-b02a-d277f5e245ca" },
                    { 30, 6, "User3@HP.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "Come up with a cool commercial name", false, 2, "new Desktop name", null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "ff611b21-e8cf-40c9-931e-2c379163017a" },
                    { 32, 6, "User1@HP.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "Contact all our known wholesale distributors and open delivery channels ", false, 0, "Contact distribution list", null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "acdbea31-d27e-41a3-bc72-d420a1faf7e0" },
                    { 33, 6, "User1@HP.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "Set price point of new Screen", false, 2, "Price determination", null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "acdbea31-d27e-41a3-bc72-d420a1faf7e0" },
                    { 34, 6, "User2@HP.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "Contact and setup meeting with assembly factory", false, 1, "Contact Assembly factory", null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "d881b27e-7b82-4a27-b02a-d277f5e245ca" },
                    { 35, 6, "User2@HP.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "Negotiate the price and sign the necessary agreements", false, 0, "Negotiate price point for manufactoring", null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "d881b27e-7b82-4a27-b02a-d277f5e245ca" },
                    { 36, 6, "User2@HP.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "Find an assembly factory who can produce the screens", false, 2, "Find Assembly factory", null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "d881b27e-7b82-4a27-b02a-d277f5e245ca" },
                    { 1, 1, "Admin@Asus.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "Draft a list of specification", false, 1, "SPEC LIST", null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "df50bb3c-693a-4889-8bc6-c7059a20b529" },
                    { 31, 6, "User1@HP.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "Start online marketing campaign", false, 1, "Marketing Campaign", null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "acdbea31-d27e-41a3-bc72-d420a1faf7e0" },
                    { 24, 5, "User1@HP.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "Come up with a cool commercial name", false, 2, "new Desktop name", null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "acdbea31-d27e-41a3-bc72-d420a1faf7e0" },
                    { 23, 5, "User1@HP.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "Send the specification list to the engineers", false, 0, "SEND SPEC LIST FOR REVIEW", null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "acdbea31-d27e-41a3-bc72-d420a1faf7e0" },
                    { 22, 5, "User1@HP.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "Draft a list of specification", false, 1, "SPEC LIST", null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "acdbea31-d27e-41a3-bc72-d420a1faf7e0" },
                    { 15, 3, "User1@Asus.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "Set price point of new Screen", false, 2, "Price determination", null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "df50bb3c-693a-4889-8bc6-c7059a20b529" },
                    { 16, 3, "User2@Asus.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "Contact and setup meeting with assembly factoru", false, 1, "Contact Assembly factory", null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "ccd0fb63-3173-4ab2-a80b-731d9939ee70" },
                    { 17, 3, "User2@Asus.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "Negotiate the price and sign the necessary agreements", false, 0, "Negotiate price point for manufactoring", null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "ccd0fb63-3173-4ab2-a80b-731d9939ee70" },
                    { 18, 3, "User2@Asus.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "Find an assembly factory who can produce the screens", false, 2, "Find Assembly factory", null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "ccd0fb63-3173-4ab2-a80b-731d9939ee70" },
                    { 12, 3, "User3@Asus.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "Come up with a cool commercial name", false, 2, "new Desktop name", null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "e615c429-b915-4312-871d-74287869debb" },
                    { 9, 2, "User2@Asus.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "Set price point of new desktop", false, 2, "Price determination", null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "ccd0fb63-3173-4ab2-a80b-731d9939ee70" },
                    { 8, 2, "User2@Asus.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "Contact all our known wholesale distributors and open delivery channels ", false, 0, "Contact distribution list", null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "ccd0fb63-3173-4ab2-a80b-731d9939ee70" },
                    { 7, 2, "User2@Asus.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "Start online marketing campaign", false, 1, "Marketing Campaign", null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "ccd0fb63-3173-4ab2-a80b-731d9939ee70" },
                    { 6, 2, "User1@Asus.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "Come up with a cool commercial name", false, 2, "new Desktop name", null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "df50bb3c-693a-4889-8bc6-c7059a20b529" },
                    { 5, 2, "User1@Asus.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "Send the specification list to the engineers", false, 0, "SEND SPEC LIST FOR REVIEW", null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "df50bb3c-693a-4889-8bc6-c7059a20b529" },
                    { 4, 2, "User1@Asus.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "Draft a list of specification", false, 1, "SPEC LIST", null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "df50bb3c-693a-4889-8bc6-c7059a20b529" },
                    { 19, 4, "Admin@HP.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "Draft a list of specification", false, 1, "SPEC LIST", null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "acdbea31-d27e-41a3-bc72-d420a1faf7e0" },
                    { 20, 4, "Admin@HP.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "Send the specification list to the engineers", false, 0, "SEND SPEC LIST FOR REVIEW", null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "acdbea31-d27e-41a3-bc72-d420a1faf7e0" },
                    { 21, 4, "Admin@HP.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "Come up with a cool commercial name", false, 2, "new laptop name", null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "acdbea31-d27e-41a3-bc72-d420a1faf7e0" },
                    { 11, 3, "User3@Asus.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "Send the specification list to the engineers", false, 0, "SEND SPEC LIST FOR REVIEW", null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "e615c429-b915-4312-871d-74287869debb" },
                    { 13, 3, "User1@Asus.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "Start online marketing campaign", false, 1, "Marketing Campaign", null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "df50bb3c-693a-4889-8bc6-c7059a20b529" },
                    { 10, 3, "User3@Asus.com", new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "Draft a list of specification", false, 1, "SPEC LIST", null, new DateTime(2020, 4, 10, 14, 15, 20, 0, DateTimeKind.Unspecified), "e615c429-b915-4312-871d-74287869debb" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "44102b7c-5da3-4d08-8466-c32914e3b5b8", "b4e5c024-99c5-43b1-847f-26585777f463" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "4fbb337df-8c68-4b09-b5ba-6f7f5046b44d", "b4e5c024-99c5-43b1-847f-26585777f463" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "acdbea31-d27e-41a3-bc72-d420a1faf7e0", "fb4302cf-f521-4fa9-b20a-0d4e59b703a5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "ccd0fb63-3173-4ab2-a80b-731d9939ee70", "fb4302cf-f521-4fa9-b20a-0d4e59b703a5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "d881b27e-7b82-4a27-b02a-d277f5e245ca", "fb4302cf-f521-4fa9-b20a-0d4e59b703a5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "da262156-18ee-4fef-b465-f2ec8d19b569", "9d17f4e4-1a9e-439b-a88d-6e994a990fe7" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "df50bb3c-693a-4889-8bc6-c7059a20b529", "fb4302cf-f521-4fa9-b20a-0d4e59b703a5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "e615c429-b915-4312-871d-74287869debb", "fb4302cf-f521-4fa9-b20a-0d4e59b703a5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "ff611b21-e8cf-40c9-931e-2c379163017a", "fb4302cf-f521-4fa9-b20a-0d4e59b703a5" });

            migrationBuilder.DeleteData(
                table: "BoardUsers",
                keyColumns: new[] { "BoardId", "ApplicationUserId" },
                keyValues: new object[] { 1, "df50bb3c-693a-4889-8bc6-c7059a20b529" });

            migrationBuilder.DeleteData(
                table: "BoardUsers",
                keyColumns: new[] { "BoardId", "ApplicationUserId" },
                keyValues: new object[] { 2, "ccd0fb63-3173-4ab2-a80b-731d9939ee70" });

            migrationBuilder.DeleteData(
                table: "BoardUsers",
                keyColumns: new[] { "BoardId", "ApplicationUserId" },
                keyValues: new object[] { 2, "df50bb3c-693a-4889-8bc6-c7059a20b529" });

            migrationBuilder.DeleteData(
                table: "BoardUsers",
                keyColumns: new[] { "BoardId", "ApplicationUserId" },
                keyValues: new object[] { 3, "ccd0fb63-3173-4ab2-a80b-731d9939ee70" });

            migrationBuilder.DeleteData(
                table: "BoardUsers",
                keyColumns: new[] { "BoardId", "ApplicationUserId" },
                keyValues: new object[] { 3, "df50bb3c-693a-4889-8bc6-c7059a20b529" });

            migrationBuilder.DeleteData(
                table: "BoardUsers",
                keyColumns: new[] { "BoardId", "ApplicationUserId" },
                keyValues: new object[] { 3, "e615c429-b915-4312-871d-74287869debb" });

            migrationBuilder.DeleteData(
                table: "BoardUsers",
                keyColumns: new[] { "BoardId", "ApplicationUserId" },
                keyValues: new object[] { 4, "acdbea31-d27e-41a3-bc72-d420a1faf7e0" });

            migrationBuilder.DeleteData(
                table: "BoardUsers",
                keyColumns: new[] { "BoardId", "ApplicationUserId" },
                keyValues: new object[] { 5, "acdbea31-d27e-41a3-bc72-d420a1faf7e0" });

            migrationBuilder.DeleteData(
                table: "BoardUsers",
                keyColumns: new[] { "BoardId", "ApplicationUserId" },
                keyValues: new object[] { 5, "d881b27e-7b82-4a27-b02a-d277f5e245ca" });

            migrationBuilder.DeleteData(
                table: "BoardUsers",
                keyColumns: new[] { "BoardId", "ApplicationUserId" },
                keyValues: new object[] { 6, "acdbea31-d27e-41a3-bc72-d420a1faf7e0" });

            migrationBuilder.DeleteData(
                table: "BoardUsers",
                keyColumns: new[] { "BoardId", "ApplicationUserId" },
                keyValues: new object[] { 6, "d881b27e-7b82-4a27-b02a-d277f5e245ca" });

            migrationBuilder.DeleteData(
                table: "BoardUsers",
                keyColumns: new[] { "BoardId", "ApplicationUserId" },
                keyValues: new object[] { 6, "ff611b21-e8cf-40c9-931e-2c379163017a" });

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d17f4e4-1a9e-439b-a88d-6e994a990fe7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4e5c024-99c5-43b1-847f-26585777f463");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb4302cf-f521-4fa9-b20a-0d4e59b703a5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "44102b7c-5da3-4d08-8466-c32914e3b5b8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4fbb337df-8c68-4b09-b5ba-6f7f5046b44d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "acdbea31-d27e-41a3-bc72-d420a1faf7e0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ccd0fb63-3173-4ab2-a80b-731d9939ee70");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d881b27e-7b82-4a27-b02a-d277f5e245ca");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "da262156-18ee-4fef-b465-f2ec8d19b569");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "df50bb3c-693a-4889-8bc6-c7059a20b529");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e615c429-b915-4312-871d-74287869debb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff611b21-e8cf-40c9-931e-2c379163017a");

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Boards",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BoardUsers");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "BoardUsers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "BoardUsers");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "BoardUsers");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "BoardUsers");
        }
    }
}
