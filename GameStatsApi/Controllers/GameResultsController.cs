using GameStatsApi.Data;
using GameStatsApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameStatsApi.Controllers;

public class GameResultsController : ControllerBase
{
    private readonly GameDbContext _context;
    
    public GameResultsController(GameDbContext context)
    {
        _context = context;
    }
    
    // Post: api/GameResults
    [HttpPost]
    public async Task<IActionResult> PostGameResult([FromBody] GameResult result)
    {
        _context.Games.Add(result);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetGameResult), new { id = result.Id }, result);
    }

    // Get: api/GameResults/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<GameResult>> GetGameResult(int id)
    {
        var result = await _context.Games.FindAsync(id);
        if (result == null) return NotFound();
        return result;
    }
    
    // Get: api/GameResults
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GameResult>>> GetAll()
    {
        return await _context.Games.ToListAsync();
    }
}