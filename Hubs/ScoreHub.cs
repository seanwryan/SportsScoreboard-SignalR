using Microsoft.AspNetCore.SignalR;
using SportsScoreboard.Models;
using SportsScoreboard.Data;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace SportsScoreboard.Hubs
{
    public class ScoreHub : Hub
    {
        // Method for sending score updates
        public async Task SendScoreUpdate(string homeTeam, string awayTeam, int homeTeamScore, int awayTeamScore, string dateSubmitted, string location, string gameType)
        {
            // Parse the submitted date
            var parsedDate = DateTime.TryParse(dateSubmitted, out var date) ? date : DateTime.Now;

            // Save the score to the database
            using (var context = new ScoreboardContext())
            {
                var score = new Score
                {
                    HomeTeam = homeTeam,
                    AwayTeam = awayTeam,
                    HomeTeamScore = homeTeamScore,
                    AwayTeamScore = awayTeamScore,
                    DateSubmitted = parsedDate, // Save the parsed date or current date if parsing fails
                    Location = location,
                    GameType = gameType
                };

                context.Scores.Add(score);
                await context.SaveChangesAsync();
            }

            // Send score update to all clients
            await Clients.All.SendAsync("ReceiveScoreUpdate", homeTeam, awayTeam, homeTeamScore, awayTeamScore);

            // Send past games update to all clients
            using (var context = new ScoreboardContext())
            {
                var pastScores = context.Scores.OrderBy(s => s.DateSubmitted).ToList();
                await Clients.All.SendAsync("ReceivePastGamesUpdate", pastScores);
            }
        }
    }
}