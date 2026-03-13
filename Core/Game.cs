namespace GameOfLife;

public class Game
{
    public Grid Grid { get; }
    
    public Game(int width, int height)
    {
        Grid = new Grid(width, height);
    }

    public void Randomize()
    {
        var rand = new Random();
        
        for (var x = 0; x < Grid.Width; x++)
            for (var y = 0; y < Grid.Height; y++)
                Grid.Cells[x,y].IsAlive = rand.Next(2) == 1;
    }
    
    public void Clear()
    {
        for (var x = 0; x < Grid.Width; x++)
            for (var y = 0; y < Grid.Height; y++)
                Grid.Cells[x, y].IsAlive = false;
    }
    
    private int CountNeighbors(int x, int y)
    {
        var count = 0;
        
        for (var dx = -1; dx <=  1; dx++)
        for (var dy = -1; dy <= 1; dy++)
        {
            if (dx == 0 && dy == 0) continue;
            
            var nx = x + dx;
            var ny = y + dy;

            if (nx < 0 || nx >= Grid.Width || ny < 0 || ny >= Grid.Height) continue;
            if (Grid.Cells[nx, ny].IsAlive) count++;
        }
        
        return count;
    }
    
    public void Update()
    {
        var newState = new bool[Grid.Width, Grid.Height];
        
        for (var x = 0; x < Grid.Width; x++)
        for (var y = 0; y < Grid.Height; y++)
        {
            var neighbors = CountNeighbors(x, y);
            var isAlive = Grid.Cells[x,y].IsAlive;
            
            if (isAlive)
                newState[x,y] = neighbors is 2 or 3;
            else
                newState[x,y] = neighbors is 3;
        }
        
        for (var x = 0; x < Grid.Width; x++)
            for (var y = 0; y < Grid.Height; y++)
                Grid.Cells[x,y].IsAlive = newState[x,y];
    }
}