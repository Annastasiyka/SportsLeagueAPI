using Microsoft.EntityFrameworkCore;
using SportsLeagueAPI.Models;

namespace SportsLeagueAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}