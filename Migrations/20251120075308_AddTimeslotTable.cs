using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RazorPagesMovie.Migrations
{
    /// <inheritdoc />
    public partial class AddTimeslotTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TimeslotId",
                table: "Movie",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Timeslot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timeslot", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Timeslot_TimeslotId",
                table: "Movie");

            migrationBuilder.DropTable(
                name: "Timeslot");

            migrationBuilder.DropIndex(
                name: "IX_Movie_TimeslotId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "TimeslotId",
                table: "Movie");
        }
    }
}
