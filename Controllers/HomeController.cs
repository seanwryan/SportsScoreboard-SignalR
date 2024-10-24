using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SportsScoreboard.Models;
using SportsScoreboard.Data;
using Microsoft.AspNetCore.SignalR;
using SportsScoreboard.Hubs;
using System.Collections.Generic;
using System.Linq;

namespace SportsScoreboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHubContext<ScoreHub> _hubContext;

        public HomeController(ILogger<HomeController> logger, IHubContext<ScoreHub> hubContext)
        {
            _logger = logger;
            _hubContext = hubContext;
        }

        // Index method for filtering and displaying past games by date and team
        public IActionResult Index(DateTime? gameDate, string team)
        {
            using (var context = new ScoreboardContext())
            {
                var scoresQuery = context.Scores.AsQueryable();

                // Apply date filter if provided
                if (gameDate.HasValue)
                {
                    scoresQuery = scoresQuery.Where(s => s.DateSubmitted.Date == gameDate.Value.Date);
                }

                // Apply team filter if provided
                if (!string.IsNullOrEmpty(team))
                {
                    scoresQuery = scoresQuery.Where(s => s.Team1.Contains(team) || s.Team2.Contains(team));
                }

                var pastScores = scoresQuery.OrderByDescending(s => s.DateSubmitted).ToList();
                ViewBag.PastScores = pastScores;
            }
            return View();
        }

        // Method to handle score submissions, including new fields
        [HttpPost]
        public async Task<IActionResult> SubmitScore(string team1, string team2, int score1, int score2, DateTime dateSubmitted, string location, string gameType, string playerOfTheGame)
        {
            // Logging form data for troubleshooting
            Console.WriteLine($"Form Data: {team1}, {team2}, {score1}-{score2}, {dateSubmitted}, {location}, {gameType}, {playerOfTheGame}");

            using (var context = new ScoreboardContext())
            {
                var newScore = new Score
                {
                    Team1 = team1,
                    Team2 = team2,
                    Score1 = score1,
                    Score2 = score2,
                    DateSubmitted = dateSubmitted,
                    Location = location,
                    GameType = gameType,
                    PlayerOfTheGame = playerOfTheGame
                };
                context.Scores.Add(newScore);
                context.SaveChanges();
                
                // Logging for successful database save
                Console.WriteLine("New score saved successfully");
            }

            // Update past games via SignalR
            await _hubContext.Clients.All.SendAsync("ReceivePastGamesUpdate", GetPastGames());
            return RedirectToAction("Index");
        }

        // Helper method to retrieve the past games list
        private List<Score> GetPastGames()
        {
            using (var context = new ScoreboardContext())
            {
                return context.Scores.OrderBy(s => s.DateSubmitted).ToList();
            }
        }

        // Edit view - updated to include the new fields (Location, GameType, PlayerOfTheGame)
        public IActionResult Edit(int id)
        {
            using (var context = new ScoreboardContext())
            {
                var score = context.Scores.FirstOrDefault(s => s.Id == id);
                return View(score);
            }
        }

        [HttpPost]
        public IActionResult Edit(Score updatedScore)
        {
            using (var context = new ScoreboardContext())
            {
                var existingScore = context.Scores.FirstOrDefault(s => s.Id == updatedScore.Id);
                if (existingScore != null)
                {
                    existingScore.Team1 = updatedScore.Team1;
                    existingScore.Team2 = updatedScore.Team2;
                    existingScore.Score1 = updatedScore.Score1;
                    existingScore.Score2 = updatedScore.Score2;
                    existingScore.DateSubmitted = updatedScore.DateSubmitted;
                    existingScore.Location = updatedScore.Location;
                    existingScore.GameType = updatedScore.GameType;
                    existingScore.PlayerOfTheGame = updatedScore.PlayerOfTheGame;
                    context.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        // Delete action
        public IActionResult Delete(int id)
        {
            using (var context = new ScoreboardContext())
            {
                var score = context.Scores.FirstOrDefault(s => s.Id == id);
                if (score != null)
                {
                    context.Scores.Remove(score);
                    context.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}