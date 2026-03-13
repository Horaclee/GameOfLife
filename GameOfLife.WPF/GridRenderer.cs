using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using WpfGrid = System.Windows.Controls.Grid;

namespace GameOfLife.WPF;

public class GridRenderer
{
    private readonly int _width;
    private readonly int _height;

    private Rectangle[,] _cells = null!;

    public GridRenderer(int width, int height)
    {
        this._width = width;
        this._height = height;
    }

    public void Init(WpfGrid grid)
    {
        _cells = new Rectangle[_width, _height];

        for (var x = 0; x < _width; x++)
            grid.ColumnDefinitions.Add(new ColumnDefinition());

        for (var y = 0; y < _height; y++)
            grid.RowDefinitions.Add(new RowDefinition());

        for (var x = 0; x < _width; x++)
        for (var y = 0; y < _height; y++)
        {
            var rect = new Rectangle
            {
                Fill = Brushes.Black
            };

            WpfGrid.SetColumn(rect, x);
            WpfGrid.SetRow(rect, y);

            grid.Children.Add(rect);
            _cells[x, y] = rect;
        }
    }

    public void Draw(Game game)
    {
        for (var x = 0; x < game.Grid.Width; x++)
        for (var y = 0; y < game.Grid.Height; y++)
        {
            _cells[x, y].Fill = game.Grid.Cells[x, y].IsAlive
                ? Brushes.White
                : Brushes.Black;
        }
    }

    public Rectangle GetCell(int x, int y) => _cells[x,y];
    
}