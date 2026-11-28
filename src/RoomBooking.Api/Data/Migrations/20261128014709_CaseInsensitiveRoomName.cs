using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoomBooking.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class CaseInsensitiveRoomName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_rooms_Name",
                table: "rooms");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_rooms_Name",
                table: "rooms",
                column: "Name",
                unique: true);
        }
    }
}
