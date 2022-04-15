using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeloCity.Data.Migrations
{
    public partial class AddLastParkedAtForBikes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "631a16b5-cd46-4627-afe5-153c78c79b08");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "828adbb1-2ece-42da-8ddc-8a9df7cc2820");

            migrationBuilder.AddColumn<int>(
                name: "LastParkedAt",
                table: "Bikes",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "91d6e213-316d-4306-9d8b-00ef92aaf087", "b1cd2874-dfbf-4274-aae8-476afb74e5d0", "Renter", null },
                    { "cf617141-1e86-49fe-bc4f-9bcb3ebfe85d", "a8d0b8d1-b09d-4366-913c-4c57faabc46e", "Admin", null }
                });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 14, 22, 37, 7, 948, DateTimeKind.Local).AddTicks(458));

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 14, 22, 37, 7, 948, DateTimeKind.Local).AddTicks(494));

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 14, 22, 37, 7, 948, DateTimeKind.Local).AddTicks(496));

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 14, 22, 37, 7, 948, DateTimeKind.Local).AddTicks(499));

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 14, 22, 37, 7, 948, DateTimeKind.Local).AddTicks(501));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91d6e213-316d-4306-9d8b-00ef92aaf087");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf617141-1e86-49fe-bc4f-9bcb3ebfe85d");

            migrationBuilder.DropColumn(
                name: "LastParkedAt",
                table: "Bikes");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "631a16b5-cd46-4627-afe5-153c78c79b08", "d46ad442-c6d9-4131-90dc-1131cba8ec8a", "Admin", null },
                    { "828adbb1-2ece-42da-8ddc-8a9df7cc2820", "55c0d1ee-3aa0-45a2-b4e7-b2b141014e55", "Renter", null }
                });

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 12, 21, 17, 17, 737, DateTimeKind.Local).AddTicks(4659));

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 12, 21, 17, 17, 737, DateTimeKind.Local).AddTicks(4699));

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 12, 21, 17, 17, 737, DateTimeKind.Local).AddTicks(4701));

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 12, 21, 17, 17, 737, DateTimeKind.Local).AddTicks(4703));

            migrationBuilder.UpdateData(
                table: "Stations",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2022, 4, 12, 21, 17, 17, 737, DateTimeKind.Local).AddTicks(4706));
        }
    }
}
