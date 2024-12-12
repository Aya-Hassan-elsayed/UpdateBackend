using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zezo.Migrations
{
    public partial class addmaxlength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PcName",
                table: "ExcelUpdateLogs",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52043f3d-26e4-4d6a-ac9d-93c10b3f6e95", "AQAAAAEAACcQAAAAEAnJ+i9+hm/BCqa3bMCR2m0K42qpu8RTO59scTs5bqkqXaTyCvu02UL5wJTGNwkI+A==", "f3a62df0-c30e-44bb-a99b-b33d0d9760c7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12e85260-d383-487b-b766-b9158b83f8e0", "AQAAAAEAACcQAAAAEMHrmXDq5EbzMc4fV8a4yU3tKcpnGkv0FwWhklkhBc50Fm8/IwOxZzHM3WPVJlzRQA==", "99a00693-14a8-4a97-94fc-96c3e170338e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c628fb73-83e1-40f0-a8d5-f22bc7ed83c9", "AQAAAAEAACcQAAAAEJwsasDla0M5dUxO2nh+X9psQqGE4z0pYqR41qyjwLWuFTTVwXXXL3bDbqS7AvCoXQ==", "fc04320c-580c-4651-8cee-31b99223963f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1dee5734-e1fe-4b9f-ab33-63a0110e788f", "AQAAAAEAACcQAAAAENAhnGv++cY+oyNYFHjxGvsNsFuC7c7M61QvjI0+YzNnsBAPGR6A6JqwmcE2SXdhVA==", "fbe11ca6-c3b1-4ec4-baad-8cd811076525" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fd2c3827-726a-4f88-99fe-485d684c8c79", "AQAAAAEAACcQAAAAEB6kf+Fc7dHgz0ld0htwbvSbBtbDMUxVc1wTDE/2W29s964CiJBtP+VsC/OIEw1u9w==", "fc40e14a-9e46-4b9b-b45a-f2d78b3c3fb9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PcName",
                table: "ExcelUpdateLogs",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

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
    }
}
