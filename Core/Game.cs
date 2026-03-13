namespace GameOfLife;

public class Game
{
    public Grid Grid { get; }
    
    public Game(int width, int height)
    {
        Grid = new Grid(width, height);
        //Randomize();
    }

    private void Randomize()
    {
        var rand = new Random();
        
        for (var x = 0; x < Grid.Width; x++)
            for (var y = 0; y < Grid.Height; y++)
                Grid.Cells[x,y].IsAlive = rand.Next(2) == 1;
    }

    public void Update()
    {
        var newState = new bool[Grid.Width, Grid.Height];
        
        for (var x = 0; x < Grid.Width; x++)
        for (var y = 0; y < Grid.Height; y++)
        {
            var neighbors = Grid.CountNeighbors(x, y);
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