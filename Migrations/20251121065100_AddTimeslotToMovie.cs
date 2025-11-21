using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RazorPagesMovie.Migrations
{
    /// <inheritdoc />
    public partial class AddTimeslotToMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Timeslot_TimeslotId",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Movie_TimeslotId",
                table: "Movie");

            migrationBuilder.AddColumn<string>(
                name: "Timeslot",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Timeslot",
                table: "Movie");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_TimeslotId",
                table: "Movie",
                column: "TimeslotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Timeslot_TimeslotId",
                table: "Movie",
                column: "TimeslotId",
                principalTable: "Timeslot",
                principalColumn: "Id");
        }
    }
}
