using Microsoft.EntityFrameworkCore.Migrations;

namespace ApartmentPosts.Migrations
{
    public partial class AddNumberOfRoomsToApartmentPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfRooms",
                table: "ApartmentPost",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfRooms",
                table: "ApartmentPost");
        }
    }
}
