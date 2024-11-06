using SportsScoreboard.Models;
using SportsScoreboard.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SportsScoreboard.Services
{
    public class ScoreService
    {
        public List<Score> GetPastGames(DateTime? gameDate, string team)
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
                    scoresQuery = scoresQuery.Where(s => s.HomeTeam.Contains(team) || s.AwayTeam.Contains(team));
                }

                return scoresQuery.OrderByDescending(s => s.DateSubmitted).ToList();
            }
        }

        public void SubmitScore(string sport, string homeTeam, string awayTeam, int homeTeamScore, int awayTeamScore, DateTime dateSubmitted, string location, string gameType)
        {
            using (var context = new ScoreboardContext())
            {
                var newScore = new Score
                {
                    Sport = sport,               // Add Sport here
                    HomeTeam = homeTeam,
                    AwayTeam = awayTeam,
                    HomeTeamScore = homeTeamScore,
                    AwayTeamScore = awayTeamScore,
                    DateSubmitted = dateSubmitted,
                    Location = location,
                    GameType = gameType
                };
                context.Scores.Add(newScore);
                context.SaveChanges();
            }
        }

        public void EditScore(Score updatedScore)
        {
            using (var context = new ScoreboardContext())
            {
                var existingScore = context.Scores.FirstOrDefault(s => s.Id == updatedScore.Id);
                if (existingScore != null)
                {
                    existingScore.Sport = updatedScore.Sport;  // Ensure Sport field is updated
                    existingScore.HomeTeam = updatedScore.HomeTeam;
                    existingScore.AwayTeam = updatedScore.AwayTeam;
                    existingScore.HomeTeamScore = updatedScore.HomeTeamScore;
                    existingScore.AwayTeamScore = updatedScore.AwayTeamScore;
                    existingScore.DateSubmitted = updatedScore.DateSubmitted;
                    existingScore.Location = updatedScore.Location;
                    existingScore.GameType = updatedScore.GameType;

                    context.SaveChanges(); // Save changes to the database
                }
            }
        }

        public void DeleteScore(int id)
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
        }
    }
}