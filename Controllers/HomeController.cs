using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SportsScoreboard.Models;
using SportsScoreboard.Services;
using Microsoft.AspNetCore.SignalR;
using SportsScoreboard.Hubs;

namespace SportsScoreboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHubContext<ScoreHub> _hubContext;
        private readonly ScoreService _scoreService;

        // Constructor to include ScoreService as a dependency
        public HomeController(ILogger<HomeController> logger, IHubContext<ScoreHub> hubContext, ScoreService scoreService)
        {
            _logger = logger;
            _hubContext = hubContext;
            _scoreService = scoreService;
        }

        // Display index page with optional filtering by game date and team
        public IActionResult Index(DateTime? gameDate, string team)
        {
            var pastScores = _scoreService.GetPastGames(gameDate, team);
            ViewBag.PastScores = pastScores;
            return View();
        }

        // Display Create view to add a new game
        public IActionResult Create()
        {
            return View();
        }

        // Handle score submission including new fields and notify clients with SignalR
        [HttpPost]
        public async Task<IActionResult> SubmitScore(string sport, string homeTeam, string awayTeam, int homeTeamScore, int awayTeamScore, DateTime dateSubmitted, string location, string gameType)
        {
            dateSubmitted = DateTime.SpecifyKind(dateSubmitted, DateTimeKind.Utc);
            _logger.LogInformation($"Form Data: {sport}, {homeTeam}, {awayTeam}, {homeTeamScore}-{awayTeamScore}, {dateSubmitted}, {location}, {gameType}");

            try
            {
                _scoreService.SubmitScore(sport, homeTeam, awayTeam, homeTeamScore, awayTeamScore, dateSubmitted, location, gameType);
                var updatedPastScores = _scoreService.GetPastGames(null, null);
                await _hubContext.Clients.All.SendAsync("ReceivePastGamesUpdate", updatedPastScores);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error submitting score: {ex.Message}");
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

            return RedirectToAction("Index");
        }

        // Display edit view for a specific game
        public IActionResult Edit(int id)
        {
            var pastScore = _scoreService.GetPastGames(null, null).FirstOrDefault(s => s.Id == id);
            if (pastScore == null)
            {
                _logger.LogWarning($"Game with ID {id} not found.");
                return NotFound();
            }
            return View(pastScore);
        }

        // Handle form submission for editing a game score
        [HttpPost]
        public IActionResult Edit(Score updatedScore)
        {
            try
            {
                _scoreService.EditScore(updatedScore);  // Pass updatedScore with new Sport value
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error editing score: {ex.Message}");
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

            return RedirectToAction("Index");
        }

        // Delete a game by ID
        public IActionResult Delete(int id)
        {
            try
            {
                // Delete score via ScoreService
                _scoreService.DeleteScore(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting score: {ex.Message}");
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }

            return RedirectToAction("Index");
        }

        // Privacy policy page
        public IActionResult Privacy()
        {
            return View();
        }

        // Error handling view
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}