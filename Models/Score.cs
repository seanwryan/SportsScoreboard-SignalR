using System;
using System.ComponentModel.DataAnnotations;

namespace SportsScoreboard.Models
{
    public class Score
    {
        // Primary key for the Score entity
        public int Id { get; set; }

        // Specify the sport (e.g., Football, Basketball)
        [Required]
        [StringLength(50)]
        public string Sport { get; set; } = "Unknown"; // Default to "Unknown" to avoid null

        // Home Team name
        [Required]
        [StringLength(100)]
        public string HomeTeam { get; set; } = string.Empty; // Default to an empty string

        // Away Team name
        [Required]
        [StringLength(100)]
        public string AwayTeam { get; set; } = string.Empty; // Default to an empty string

        // Score of Home Team
        [Range(0, int.MaxValue, ErrorMessage = "Score must be a non-negative number")]
        public int HomeTeamScore { get; set; }

        // Score of Away Team
        [Range(0, int.MaxValue, ErrorMessage = "Score must be a non-negative number")]
        public int AwayTeamScore { get; set; }

        // Automatically store the date and time when the score was submitted
        public DateTime DateSubmitted { get; set; } = DateTime.UtcNow; // Default to current UTC date

        // Location of the game
        [StringLength(200)]
        public string Location { get; set; } = "Unknown Location"; // Default to "Unknown Location"

        // Type of the game (e.g., regular season, playoff, etc.)
        [StringLength(100)]
        public string? GameType { get; set; } // Nullable to indicate optional

        // Referee of the game (nullable)
        [StringLength(100)]
        public string? Referee { get; set; } // Nullable to indicate optional

        // Audience count with default value of 0
        [Range(0, int.MaxValue, ErrorMessage = "Audience count must be a non-negative number")]
        public int AudienceCount { get; set; } = 0; // Default to 0
    }
}