using Microsoft.AspNetCore.SignalR;
using SportsScoreboard.Models;
using SportsScoreboard.Data;
using System.Threading.Tasks;

namespace SportsScoreboard.Hubs
{
    public class ScoreHub : Hub
    {
        public async Task SendScoreUpdate(string team1, string team2, int score1, int score2)
        {
            // Save the score to the database
            using (var context = new ScoreboardContext())
            {
                var score = new Score
                {
                    Team1 = team1,
                    Team2 = team2,
                    Score1 = score1,
                    Score2 = score2
                };
                
                context.Scores.Add(score);
                await context.SaveChangesAsync();
            }

            // Send score update to all clients
            await Clients.All.SendAsync("ReceiveScoreUpdate", team1, team2, score1, score2);
        }
    }
}