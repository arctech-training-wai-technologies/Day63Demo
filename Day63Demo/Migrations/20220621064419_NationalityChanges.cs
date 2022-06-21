using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Day63Demo.Migrations
{
    public partial class NationalityChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryPopulation",
                table: "Nationalities",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountryPopulation",
                table: "Nationalities");
        }
    }
}
