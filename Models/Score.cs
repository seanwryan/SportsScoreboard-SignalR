using System;
using System.ComponentModel.DataAnnotations;

namespace SportsScoreboard.Models
{
    public class Score
    {
        // Primary key for the Score entity
        public int Id { get; set; }

        // Team 1 name
        [Required]
        [StringLength(100)] // Limiting the length to 100 characters
        public string Team1 { get; set; }

        // Team 2 name
        [Required]
        [StringLength(100)] // Limiting the length to 100 characters
        public string Team2 { get; set; }

        // Score of Team 1
        [Range(0, int.MaxValue, ErrorMessage = "Score must be a non-negative number")]
        public int Score1 { get; set; }

        // Score of Team 2
        [Range(0, int.MaxValue, ErrorMessage = "Score must be a non-negative number")]
        public int Score2 { get; set; }

        // Automatically store the date and time when the score was submitted
        public DateTime DateSubmitted { get; set; } = DateTime.Now;

        // Location of the game
        [StringLength(200)] // Limiting the length to 200 characters
        public string Location { get; set; }

        // Type of the game (e.g., regular season, playoff, etc.)
        [StringLength(100)] // Limiting the length to 100 characters
        public string? GameType { get; set; }  // Nullable to avoid errors

        // Player of the game (nullable)
        [StringLength(100)] // Limiting the length to 100 characters
        public string? PlayerOfTheGame { get; set; }

        // Referee of the game (nullable)
        [StringLength(100)] // Limiting the length to 100 characters
        public string? Referee { get; set; }

        // Audience count with default value of 0
        [Range(0, int.MaxValue, ErrorMessage = "Audience count must be a non-negative number")]
        public int AudienceCount { get; set; } = 0;
    }
}