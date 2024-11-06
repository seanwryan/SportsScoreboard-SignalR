using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsScoreboard.Migrations
{
    /// <inheritdoc />
    public partial class UpdateScoreFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlayerOfTheGame",
                table: "Scores");

            migrationBuilder.RenameColumn(
                name: "Team2",
                table: "Scores",
                newName: "HomeTeam");

            migrationBuilder.RenameColumn(
                name: "Team1",
                table: "Scores",
                newName: "AwayTeam");

            migrationBuilder.RenameColumn(
                name: "Score2",
                table: "Scores",
                newName: "HomeTeamScore");

            migrationBuilder.RenameColumn(
                name: "Score1",
                table: "Scores",
                newName: "AwayTeamScore");

            migrationBuilder.AddColumn<string>(
                name: "Sport",
                table: "Scores",
                type: "TEXT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sport",
                table: "Scores");

            migrationBuilder.RenameColumn(
                name: "HomeTeamScore",
                table: "Scores",
                newName: "Score2");

            migrationBuilder.RenameColumn(
                name: "HomeTeam",
                table: "Scores",
                newName: "Team2");

            migrationBuilder.RenameColumn(
                name: "AwayTeamScore",
                table: "Scores",
                newName: "Score1");

            migrationBuilder.RenameColumn(
                name: "AwayTeam",
                table: "Scores",
                newName: "Team1");

            migrationBuilder.AddColumn<string>(
                name: "PlayerOfTheGame",
                table: "Scores",
                type: "TEXT",
                maxLength: 100,
                nullable: true);
        }
    }
}
