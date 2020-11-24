using Microsoft.EntityFrameworkCore.Migrations;

namespace ApartmentPosts.Migrations
{
    public partial class AddSqmToApartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>("Sqm", "ApartmentPost", "int", defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("Sqm", "ApartmentPost");
        }
    }
}
