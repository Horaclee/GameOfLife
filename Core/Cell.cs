namespace GameOfLife;

public class Cell(bool isAlive = false)
{
    public bool IsAlive { get; set; } = isAlive;
}