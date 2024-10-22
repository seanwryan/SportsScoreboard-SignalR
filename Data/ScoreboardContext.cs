using Microsoft.EntityFrameworkCore;
using SportsScoreboard.Models;

namespace SportsScoreboard.Data
{
    public class ScoreboardContext : DbContext
    {
        public DbSet<Score> Scores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=scoreboard.db");
        }
    }
}