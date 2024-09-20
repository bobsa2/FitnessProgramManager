using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessProgramManager.Migrations
{
    /// <inheritdoc />
    public partial class Rating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RatingCount",
                table: "FitnessProgram",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalRating",
                table: "FitnessProgram",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RatingCount",
                table: "FitnessProgram");

            migrationBuilder.DropColumn(
                name: "TotalRating",
                table: "FitnessProgram");
        }
    }
}
