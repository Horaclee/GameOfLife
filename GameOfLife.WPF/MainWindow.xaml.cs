using System.Windows.Input;
using WpfGrid = System.Windows.Controls.Grid;

namespace GameOfLife.WPF;


public partial class MainWindow
{
    private const int CellSize = 20; // Size of each cell in pixels
    private new const int Width = 1400 / CellSize; // Number of columns in the grid (width of the grid)
    private new const int Height = 800 / CellSize; // Number of rows in the grid (height of the grid)
    
    private readonly Game _game;
    private readonly GameLoop _gameLoop;
    private readonly GridRenderer _renderer;
    
    // Create Game, Render the grid, Attach Events, Start Game Loop, Draw game
    public MainWindow()
    {
        InitializeComponent();

        _game = new Game(Width, Height);

        _renderer = new GridRenderer(Width, Height);
        _renderer.Init(GameGrid);
        
        AttachEvents();

        _gameLoop = new GameLoop(200);
        _gameLoop.Tick += Update;
        _gameLoop.Start();
        
        _renderer.Draw(_game);
    }
    
    // Update the game, next state, every 200ms (GameLoop(intervalMs))
    private void Update()
    {
        _game.Update();
        _renderer.Draw(_game);
    }

    // Attach Event OnCellClicked to every cell
    private void AttachEvents()
    {
        for (var x = 0; x < Width; x++)
        for (var y = 0; y < Height; y++)
        {
            var rect = _renderer.GetCell(x, y);
            rect.MouseDown += OnCellClicked;
        }
    }
    
    // CREATE or KILL cells on click
    private void OnCellClicked(object sender, MouseButtonEventArgs e)
    {
        var rect = (System.Windows.Shapes.Rectangle)sender;

        var x = WpfGrid.GetColumn(rect);
        var y = WpfGrid.GetRow(rect);

        _game.Grid.Cells[x, y].IsAlive = !_game.Grid.Cells[x, y].IsAlive;

        _renderer.Draw(_game);
    }

    // PAUSE the game on SpaceBar
    protected override void OnKeyDown(KeyEventArgs e)
    {
        if (e.Key != Key.Space) return;
        if (_gameLoop.IsRunning)
            _gameLoop.Stop();
        else
            _gameLoop.Start();
    }
}