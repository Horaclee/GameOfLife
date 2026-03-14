namespace GameStatsApi.Models;

public class GameResult
{
    public int Id { get; set; }
    public int GridWidth { get; set; }
    public int GridHeight { get; set; }
    public int Generation { get; set; }
    public int CellsAlive { get; set; }
    public int CellsDead { get; set; }
    public DateTime Date { get; set; }
    
}