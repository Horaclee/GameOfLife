using GameStatsApi.Data;
using GameStatsApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameStatsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    private readonly GameDbContext _context;
    
    public GameController(GameDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<GameResult>>> GetGames()
    {
        return await _context.Games.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<GameResult>> SaveGame(GameResult result)
    {
        result.Date = DateTime.Now;
        
        _context.Games.Add(result);
        await _context.SaveChangesAsync();
        
       return CreatedAtAction(nameof(GetGames), new { id = result.Id }, result);
    }

    [HttpGet("best")]
    public async Task<ActionResult<GameResult>> GetBestResult()
    {
        var best = await _context.Games
            .OrderByDescending(g => g.Generation)
            .FirstOrDefaultAsync();

        if (best == null) return NotFound();

        return best;
    }
}