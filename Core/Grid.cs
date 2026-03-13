using System.Text;

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
    
    public string SerializeGrid()
    {
        var sb = new StringBuilder();

        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                sb.Append(Cells[x, y].IsAlive ? "1" : "0");
            }
            sb.AppendLine();
        }

        return sb.ToString();
    }

    public void LoadFromString(string gridData)
    {
        var lines = gridData.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

        for (var y = 0; y < Math.Min(Height, lines.Length); y++)
        {
            var line = lines[y];
            for (var x = 0; x < Math.Min(Width, line.Length); x++)
            {
                Cells[x, y].IsAlive = line[x] == '1';
            }
        }
    }
}