using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zezo.Migrations
{
    public partial class AddecxelpathMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileContent",
                table: "ExcelUpdateLogs");

            migrationBuilder.AddColumn<string>(
                name: "FileContentpath",
                table: "ExcelUpdateLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileContentpath",
                table: "ExcelUpdateLogs");

            migrationBuilder.AddColumn<byte[]>(
                name: "FileContent",
                table: "ExcelUpdateLogs",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b4e2365b-c809-4daf-9466-f6b1ea12f8b2", "AQAAAAEAACcQAAAAEOXs1Ytrl30BOQdk1ZiyfzNxNBZPaF94cnatjs6ymNcr9Ve+IHKgoPUYNokgbD3u+w==", "43488f42-096d-4d3c-be43-3052534643a4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d0d9dfa5-e4fe-449a-951c-a6124843d3c6", "AQAAAAEAACcQAAAAEEBQP/1L9k5OhP4ZZgAB+odfn+d3g+oriiSh67m1kVSO/T4V1Vj5s0cON7mqq6+Ohw==", "247bd466-cf59-4a1b-8494-951aeb6b8575" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5190a6e8-f8c8-47af-b5eb-eca09d56246e", "AQAAAAEAACcQAAAAEB4RfobljAfEFj7BnsMG+CEsFlKrJ1xgioYcwMsRttpfVpu0R5w/+y/JgGtfC0lqiA==", "6c83b8e4-a095-4050-975f-da07c8e32b30" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2efe4fc5-bef2-46f0-8d7b-af34e972229d", "AQAAAAEAACcQAAAAEBTgUI+fHbz4sXrqkLI6H9KA11KLFRM5B/tjZONyHw8pLxLG61S/1OFtdNVQ6j8jaw==", "d9502ae0-f8ad-43f1-aa5b-527f81035a7d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d62d4f79-97f5-4abe-b285-3954279e82a2", "AQAAAAEAACcQAAAAEM8FnZnumw6hHvyncebvBd5/EadmP4DoecgIncNGKZfsoPiOyr/gPdkF1gu22AL9qw==", "4ce11ca0-1921-4517-be28-b56c9589b3da" });
        }
    }
}
