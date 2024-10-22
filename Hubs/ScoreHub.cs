using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SportsScoreboard.Hubs
{
    public class ScoreHub : Hub
    {
        public async Task SendScoreUpdate(string team1, string team2, int score1, int score2)
        {
            await Clients.All.SendAsync("ReceiveScoreUpdate", team1, team2, score1, score2);
        }
    }
}