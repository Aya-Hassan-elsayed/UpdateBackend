using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zezo.Migrations
{
    public partial class changenameofrole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "user", "user" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "admin", "admin" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "teamleader", "teamleader" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "manger", "manger" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "bigmanger", "bigmanger" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3edd48a4-b7cb-4873-b8b5-045a5b1fd706", "AQAAAAEAACcQAAAAEIY5zq8AfCuw+TeENdeso5EYEeHtQ4yxBuyV9Ye+I9s5pBbs1QfqPpwScgEQpkeloA==", "82c2c170-deef-46dc-99fc-fe8fd9f13e30" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "24f27ac2-b575-4821-90b7-394adb30b9f5", "AQAAAAEAACcQAAAAEFGwgVg6bzDGbFd5UIUC3hm55oyBt45creDy/foTuNUQ/aUaP2tkfsdr7JmBilHrvw==", "8ae7cf63-f7a5-4303-9ffd-ae42ec17df89" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd90d73b-c798-4805-b6ae-2f4463c48e28", "AQAAAAEAACcQAAAAELKFN/V3gPAZc567O6bWxOysuOvVddrK5qBMSdYZGkv9NGK6EWkxby8q8JAUYWRHow==", "265f7b6e-e7a2-4855-b54a-d0832ec1760d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5aeb6882-6f17-45dd-aa62-275d042a7624", "AQAAAAEAACcQAAAAEKEfyhaB4PEdSUtExTkyWjoAEfS3sLyYpmGLncrQNTgM5UMpYqrjwEHkXjfLdP8tLA==", "ce9ed7fc-1d6d-41a0-9a5e-8d84986c5f0b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c928b3ac-9b26-4dbb-8f6b-a62342de3b27", "AQAAAAEAACcQAAAAEMOdDmVbIeIKKoRcDgckcSS/8ogDNIuEOsPR6EB2am6YF29J3QyyT7MCO7ktma395A==", "9e89c29b-c588-40d2-82a4-372f90521e46" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Kamel", "Lara" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Lara", "Kamel" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Islam", "Islam" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "Hatem", "Hatem" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "basiune", "basiune" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "60fa12d8-cc59-4006-8ffd-abde3713620b", "AQAAAAEAACcQAAAAEDy+dxGgfonuhRsYJsdgP6aBIWvkO2e2XW/xbQsHzEJXZBvID7/kHS7MKaV/WDFtRQ==", "eaba18d8-e732-46c8-8487-2dfd73d83949" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d54cfaf-32b4-4424-afac-73e191b93f22", "AQAAAAEAACcQAAAAEIecpVpfftRpIX2nbpfhWQoWRsAVX+MZ0gLD9+1s3BsG8LcV5fyOHU5rktse7m8acg==", "10708f34-80ee-4346-bf93-55a10599e718" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9ed5be44-6006-4cd9-8237-c0654dd99ce4", "AQAAAAEAACcQAAAAEON+dNJ/XnnSeutkLxmjqLaxxIkDKiXukOAdWIVGrMs7V8g8UATdX0A/ZVQ7e12Cjw==", "5ed354ac-ecb6-4f36-a2c8-a735a0d3f036" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "22218d0d-50e8-462c-9f09-23755b30a1a7", "AQAAAAEAACcQAAAAEKfJh7+E7u0IkOS9IZ6KHvKUOMVa/Nu6+B0R2vUcVLZuGEMp0mHIM4/3Ip1KIkX3Yg==", "a83d46ae-dc5c-4588-92dd-b31c23ec0477" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dd609263-64d4-4cd7-bdf3-e7f31d96374c", "AQAAAAEAACcQAAAAEJMmwb0y4fmerMp4RB50rKO5Bra9n3QTYWhSFoNlJRWgBpov9LJOkKVzptigwZqlFQ==", "ae2a9cb0-1fc0-4977-a3f7-3b595275ac23" });
        }
    }
}
