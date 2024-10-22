using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SportsScoreboard.Models;
using SportsScoreboard.Data;
using SportsScoreboard.Models;

namespace SportsScoreboard.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        using (var context = new ScoreboardContext())
        {
            var pastScores = context.Scores.ToList();
            ViewBag.PastScores = pastScores;
        }
        return View();
    }

    [HttpPost]
    public IActionResult SubmitScore(string team1, string team2, int score1, int score2)
    {
        using (var context = new ScoreboardContext())
        {
            // Create a new Score object with form data
            var score = new Score
            {
                Team1 = team1,
                Team2 = team2,
                Score1 = score1,
                Score2 = score2
            };

            // Add the score to the database
            context.Scores.Add(score);
            context.SaveChanges();  // Save the changes to the database
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