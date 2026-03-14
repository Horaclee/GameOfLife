using GameStatsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStatsApi.Data;

public class GameDbContext : DbContext
{
    public GameDbContext(DbContextOptions<GameDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<GameResult> Games { get; set; }
}
