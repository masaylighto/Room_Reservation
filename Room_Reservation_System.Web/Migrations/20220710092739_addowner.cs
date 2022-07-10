using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Room_Reservation_System.Web.Migrations
{
    public partial class addowner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Reservations");
        }
    }
}
