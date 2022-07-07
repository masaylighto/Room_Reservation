using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Room_Reservation_System.Web.Migrations
{
    public partial class inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Begin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.id);
                    table.ForeignKey(
                        name: "FK_Reservations_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Counts = table.Column<long>(type: "bigint", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resources_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Capacity", "Location", "RoomNumber", "Type" },
                values: new object[] { new Guid("0022b957-3413-4f87-9a03-7a7a4505ac9f"), 50, "Berlin", 542, 1 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Capacity", "Location", "RoomNumber", "Type" },
                values: new object[] { new Guid("1faa2016-8d9d-4493-a7ce-4b2c9b0695b3"), 50, "Amsterdam", 522, 1 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Capacity", "Location", "RoomNumber", "Type" },
                values: new object[] { new Guid("792ba6aa-1416-482a-8f40-2557eb6a6368"), 50, "Berlin", 512, 0 });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "Counts", "Name", "RoomId", "Type" },
                values: new object[] { new Guid("152b0678-a3d4-4813-a30e-6ff1883519ed"), 50L, "Table", new Guid("0022b957-3413-4f87-9a03-7a7a4505ac9f"), 0 });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "Counts", "Name", "RoomId", "Type" },
                values: new object[] { new Guid("62fa0598-a9bc-4840-ac26-8c45b25fabb0"), 50L, "Chairs", new Guid("1faa2016-8d9d-4493-a7ce-4b2c9b0695b3"), 0 });

            migrationBuilder.InsertData(
                table: "Resources",
                columns: new[] { "Id", "Counts", "Name", "RoomId", "Type" },
                values: new object[] { new Guid("6b10d231-a14e-42ae-89ce-d0e9308af831"), 10L, "Tv", new Guid("792ba6aa-1416-482a-8f40-2557eb6a6368"), 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RoomId",
                table: "Reservations",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Resources_RoomId",
                table: "Resources",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
