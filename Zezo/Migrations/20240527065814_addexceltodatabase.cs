using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zezo.Migrations
{
    public partial class addexceltodatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileContent",
                table: "ExcelUpdateLogs");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5fa3c487-e540-4864-837c-8f7d2a8a45a4", "AQAAAAEAACcQAAAAEGYioCP0h3KWPWXax1riH1qcC/p9Sewor30mI/l9Qk+MnG2zD0xafPV7EGgfcIn8AA==", "3f21dc59-d115-4922-bd9c-f4a5f12f3eec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "86ceb1d7-e924-4a52-a64f-bfa651624437", "AQAAAAEAACcQAAAAEAUcRGDZh6Tr4CxkyvJhsHkEFM3blTongsOg4MJnmb/oP4HfJ6e41j2KbKeMQP3v2w==", "1bfa5ff3-7349-4049-9b31-053958208e29" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0f6fdd9e-f748-4b3b-8b70-04ff9134bf93", "AQAAAAEAACcQAAAAELeaKmHPkcETvmSmva19lhcx/2eJXmKRel7ImvSS7U/cEdakOPGpsWL2r9OJZ+UMJg==", "7448b652-a5e1-4fd8-834d-f6ef76ecf79b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54e901a3-cd15-4530-9cfa-2a53e40ea410", "AQAAAAEAACcQAAAAEH0C2fXX/aqR4Jhex9t9BcCeUpD2EV6snIzVsCt9EaidjV7Xg8NbRlVH+1LA+WzSsg==", "8a82f3b3-671a-42da-aa4a-fb20bd7ce17b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d9ff2ef9-f3cc-4c4f-a7a0-490291ccefd4", "AQAAAAEAACcQAAAAELtHrjod5nMHmJfffY8ANpYunM5Dt2l7EFrnbR5tDgUPCtSu+Ceicqi40xzH5jQheg==", "c9e3bd61-132d-411e-a3cb-33dfa7e74f11" });
        }
    }
}
