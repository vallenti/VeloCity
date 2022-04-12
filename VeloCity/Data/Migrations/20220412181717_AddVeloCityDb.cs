using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VeloCity.Data.Migrations
{
    public partial class AddVeloCityDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BikeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PricePerMinute = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BikeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    BikeTypeId = table.Column<int>(type: "int", nullable: false),
                    ParkedAtId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bikes_BikeTypes_BikeTypeId",
                        column: x => x.BikeTypeId,
                        principalTable: "BikeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bikes_Stations_ParkedAtId",
                        column: x => x.ParkedAtId,
                        principalTable: "Stations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BikeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trips_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trips_Bikes_BikeId",
                        column: x => x.BikeId,
                        principalTable: "Bikes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "631a16b5-cd46-4627-afe5-153c78c79b08", "d46ad442-c6d9-4131-90dc-1131cba8ec8a", "Admin", null },
                    { "828adbb1-2ece-42da-8ddc-8a9df7cc2820", "55c0d1ee-3aa0-45a2-b4e7-b2b141014e55", "Renter", null }
                });

            migrationBuilder.InsertData(
                table: "BikeTypes",
                columns: new[] { "Id", "Name", "PricePerMinute" },
                values: new object[,]
                {
                    { 1, "Classic", 0.10000000000000001 },
                    { 2, "Road", 0.20000000000000001 },
                    { 3, "Mountain", 0.29999999999999999 },
                    { 4, "Electric", 0.40000000000000002 }
                });

            migrationBuilder.InsertData(
                table: "Stations",
                columns: new[] { "Id", "Capacity", "CreatedAt", "Latitude", "Longitude", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 10, new DateTime(2022, 4, 12, 21, 17, 17, 737, DateTimeKind.Local).AddTicks(4659), 42.496335000000002, 27.465771, "Младежки културен център", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 10, new DateTime(2022, 4, 12, 21, 17, 17, 737, DateTimeKind.Local).AddTicks(4699), 42.520085000000002, 27.451919, "Парк Славейков", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 10, new DateTime(2022, 4, 12, 21, 17, 17, 737, DateTimeKind.Local).AddTicks(4701), 42.488880000000002, 27.480485000000002, "Морска Гара", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 10, new DateTime(2022, 4, 12, 21, 17, 17, 737, DateTimeKind.Local).AddTicks(4703), 42.501440000000002, 27.482109999999999, "Пантеон", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 10, new DateTime(2022, 4, 12, 21, 17, 17, 737, DateTimeKind.Local).AddTicks(4706), 42.494916000000003, 27.482633, "Морско Казино", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Bikes",
                columns: new[] { "Id", "BikeTypeId", "ParkedAtId", "Status" },
                values: new object[,]
                {
                    { 1, 1, 1, 0 },
                    { 2, 2, 1, 0 },
                    { 3, 3, 2, 0 },
                    { 4, 4, 2, 0 },
                    { 5, 1, 3, 0 },
                    { 6, 2, 3, 0 },
                    { 7, 3, 3, 0 },
                    { 8, 3, 3, 0 },
                    { 9, 4, 4, 0 },
                    { 10, 2, 4, 0 },
                    { 11, 3, 5, 0 },
                    { 12, 1, 5, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bikes_BikeTypeId",
                table: "Bikes",
                column: "BikeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Bikes_ParkedAtId",
                table: "Bikes",
                column: "ParkedAtId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_BikeId",
                table: "Trips",
                column: "BikeId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_UserId",
                table: "Trips",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "Bikes");

            migrationBuilder.DropTable(
                name: "BikeTypes");

            migrationBuilder.DropTable(
                name: "Stations");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "631a16b5-cd46-4627-afe5-153c78c79b08");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "828adbb1-2ece-42da-8ddc-8a9df7cc2820");
        }
    }
}
