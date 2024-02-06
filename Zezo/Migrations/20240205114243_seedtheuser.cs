using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zezo.Migrations
{
    public partial class seedtheuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2485b228-0135-4530-9c42-40b7cb95358d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69801999-5c8c-4d10-ba1f-a74316559c4f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e07cb23-f196-4687-bcd2-df7ab65935b1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "1", "Kamel", "Lara" },
                    { "2", "2", "Lara", "Kamel" },
                    { "3", "3", "Islam", "Islam" },
                    { "4", "3", "Hatem", "Hatem" },
                    { "5", "3", "basiune", "basiune" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "60fa12d8-cc59-4006-8ffd-abde3713620b", "kamel@gmail.com", true, false, null, "KAMEL@GMAIL.COM", "KAMEL", "AQAAAAEAACcQAAAAEDy+dxGgfonuhRsYJsdgP6aBIWvkO2e2XW/xbQsHzEJXZBvID7/kHS7MKaV/WDFtRQ==", null, false, "eaba18d8-e732-46c8-8487-2dfd73d83949", false, "Kamel" },
                    { "2", 0, "3d54cfaf-32b4-4424-afac-73e191b93f22", "Lara@gmail.com", true, false, null, "Lara@GMAIL.COM", "Lara", "AQAAAAEAACcQAAAAEIecpVpfftRpIX2nbpfhWQoWRsAVX+MZ0gLD9+1s3BsG8LcV5fyOHU5rktse7m8acg==", null, false, "10708f34-80ee-4346-bf93-55a10599e718", false, "Lara" },
                    { "3", 0, "9ed5be44-6006-4cd9-8237-c0654dd99ce4", "islam@gmail.com", true, false, null, "islam@GMAIL.COM", "islam", "AQAAAAEAACcQAAAAEON+dNJ/XnnSeutkLxmjqLaxxIkDKiXukOAdWIVGrMs7V8g8UATdX0A/ZVQ7e12Cjw==", null, false, "5ed354ac-ecb6-4f36-a2c8-a735a0d3f036", false, "islam" },
                    { "4", 0, "22218d0d-50e8-462c-9f09-23755b30a1a7", "caphatem@gmail.com", true, false, null, "caphatem@GMAIL.COM", "caphatem", "AQAAAAEAACcQAAAAEKfJh7+E7u0IkOS9IZ6KHvKUOMVa/Nu6+B0R2vUcVLZuGEMp0mHIM4/3Ip1KIkX3Yg==", null, false, "a83d46ae-dc5c-4588-92dd-b31c23ec0477", false, "caphatem" },
                    { "5", 0, "dd609263-64d4-4cd7-bdf3-e7f31d96374c", "capbasuoni@gmail.com", true, false, null, "capbasuoni@GMAIL.COM", "capbasuoni", "AQAAAAEAACcQAAAAEJMmwb0y4fmerMp4RB50rKO5Bra9n3QTYWhSFoNlJRWgBpov9LJOkKVzptigwZqlFQ==", null, false, "ae2a9cb0-1fc0-4977-a3f7-3b595275ac23", false, "capbasuoni" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "1", "1" },
                    { "2", "2" },
                    { "3", "3" },
                    { "4", "4" },
                    { "5", "5" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2", "2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3", "3" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4", "4" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5", "5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2485b228-0135-4530-9c42-40b7cb95358d", "1", "User", "User" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "69801999-5c8c-4d10-ba1f-a74316559c4f", "3", "Manger", "Manger" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6e07cb23-f196-4687-bcd2-df7ab65935b1", "2", "Admin", "Admin" });
        }
    }
}
