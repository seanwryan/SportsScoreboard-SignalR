using System.ComponentModel.DataAnnotations;

namespace SportsScoreboard.Models
{
    public class Score
    {
        [Key]
        public int Id { get; set; }
        public string Team1 { get; set; } = "";
        public string Team2 { get; set; } = "";
        public int Score1 { get; set; }
        public int Score2 { get; set; }
    }
}