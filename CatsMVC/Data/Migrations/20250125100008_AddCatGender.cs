using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatsMVC.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCatGender : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Cat",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Cat");
        }
    }
}
