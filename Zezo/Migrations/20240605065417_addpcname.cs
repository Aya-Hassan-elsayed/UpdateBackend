using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zezo.Migrations
{
    public partial class addpcname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PcName",
                table: "ExcelUpdateLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9b6ca85-2a2e-4db6-9220-81b90be53a6b", "AQAAAAEAACcQAAAAEEeh/M0jl/Pn5SGzDKz14eeaM6evxgoPihrA7kyZqz072LKH3r809ulOLAjUeX9mZw==", "332e402f-8393-460d-b5c8-27496338b464" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bf97a3c1-5e1c-4ebc-b314-348713868513", "AQAAAAEAACcQAAAAEKDT6dtbsbeh+ScPIfRYUyfdFl9bdM1WG1EbHv4bmYS5zhK8YVk96RSdH95DwF3QGw==", "bd53701d-3e0d-45f2-9a03-176b05446487" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "700d9884-d238-4aea-8a47-f1eb81165fd2", "AQAAAAEAACcQAAAAEJFJ1MUUYFHXzSrcjY8uG2kvdG2BvMztWnVWimuD22PioJKS2hLSYW5bYRw5XI/nog==", "fd4f275e-df04-4c9c-a529-2fb4e3f3ed6c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "137b29aa-c838-4dac-9d94-6f01dfc6136f", "AQAAAAEAACcQAAAAEEeULUE9qJ+urwZgdIoIn4b8TjYeriqBU5L/JEFnPHydTpYDIgRXawnj6HhfonBVPA==", "f0d5051f-279e-4059-991b-8d8aaf0883fc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d0434bec-82a6-46ab-ae74-f11a5a9afc7e", "AQAAAAEAACcQAAAAEJsccJacZrI/2JytsI8jiNxM+ZPqUTOl0HVyqiSzz7mu28EFw2CizabPCFISgNOb4g==", "594cd2c3-161c-4def-900c-24c436f18795" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PcName",
                table: "ExcelUpdateLogs");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b650f9a7-afdb-4d1d-8c0e-04b27f4c0440", "AQAAAAEAACcQAAAAEOKG0yRQAf7FEdt0LH5k3nO78ogpJ8vd8e8KtqU3cq/FlhIGoaZJLmt9suBZV5S3mg==", "587d8c38-8fc6-4e9e-ab6b-4d03a0e14bcd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d91013b-fa8b-458f-8e17-5ee6ef125a2d", "AQAAAAEAACcQAAAAEH+qfCV32XmOuC/HOdbjX4d6ujXOBDznJ+QwJkOkfH5c3PwCr0oZpprLWK2twrCF6Q==", "da1de5f9-7e3f-470c-841f-00e7efb15c54" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f2263a98-8d1b-4a9f-9fe0-c165014353cd", "AQAAAAEAACcQAAAAEJ0Yu576bIu3RK238HPrd2X9bCzA5QO1Iqkf7FWWyi2Fb51jF2+rqeoGnj7XJMknSA==", "7d9dac61-cbb6-4505-bffd-d5a4add1061f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b42e92f-b735-4b9c-8a17-cb3ae8104dd3", "AQAAAAEAACcQAAAAELQvw+QnoknAUnRQeYT2ec7a/kW+LP+Cwt79FveuD6JcQIQm7fNqCM0RHSL7AYka2A==", "facc25c3-a28c-4b95-bcf7-81fe8d933be5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "30aaa1bc-d961-443b-aaed-616c8c596335", "AQAAAAEAACcQAAAAEElqZ7X9zpKZtkl7rOlLLzqSj2YUM/kqBP94jQsOanJb5kX9oMMrVoVHB6gZNPNAZQ==", "134fb97c-2b4a-40f0-ab40-3e6c54615f0a" });
        }
    }
}
