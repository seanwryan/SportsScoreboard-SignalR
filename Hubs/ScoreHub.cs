using Microsoft.AspNetCore.SignalR;
using SportsScoreboard.Models;
using SportsScoreboard.Data;
using System.Threading.Tasks;
using System.Linq;

namespace SportsScoreboard.Hubs
{
    public class ScoreHub : Hub
    {
        // Method for sending score updates
        public async Task SendScoreUpdate(string team1, string team2, int score1, int score2, string dateSubmitted, string location, string gameType, string playerOfTheGame)
        {
            // Parse the submitted date
            var parsedDate = DateTime.TryParse(dateSubmitted, out var date) ? date : DateTime.Now;

            // Save the score to the database
            using (var context = new ScoreboardContext())
            {
                var score = new Score
                {
                    Team1 = team1,
                    Team2 = team2,
                    Score1 = score1,
                    Score2 = score2,
                    DateSubmitted = parsedDate, // Save the parsed date or current date if parsing fails
                    Location = location,
                    GameType = gameType,
                    PlayerOfTheGame = playerOfTheGame
                };

                context.Scores.Add(score);
                await context.SaveChangesAsync();
            }

            // Send score update to all clients
            await Clients.All.SendAsync("ReceiveScoreUpdate", team1, team2, score1, score2);

            // Send past games update to all clients
            using (var context = new ScoreboardContext())
            {
                var pastScores = context.Scores.OrderBy(s => s.DateSubmitted).ToList();
                await Clients.All.SendAsync("ReceivePastGamesUpdate", pastScores);
            }
        }
    }
}