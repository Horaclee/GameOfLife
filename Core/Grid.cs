namespace GameOfLife;

public class Grid
{
    public int Width { get; set; }
    public int Height { get; set; }
    
    public Cell[,] Cells { get; set; }

    public Grid(int width, int height)
    {
        Width = width;
        Height = height;
        
        Cells = new Cell[Width, Height];
        
        for (var x = 0; x < Width; x++)
            for (var y = 0; y < Height; y++)
                Cells[x, y] = new Cell();
    }

    public int CountNeighbors(int x, int y)
    {
        var count = 0;
        
        for (var dx = -1; dx <=  1; dx++)
        for (var dy = -1; dy <= 1; dy++)
        {
            if (dx == 0 && dy == 0) continue;
            
            var nx = x + dx;
            var ny = y + dy;

            if (nx < 0 || nx >= Width || ny < 0 || ny >= Height) continue;
            if (Cells[nx, ny].IsAlive) count++;
        }
        
        return count;
    }
}