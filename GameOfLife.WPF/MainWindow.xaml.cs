using System.Windows;
using System.Windows.Input;
using Services;
using WpfGrid = System.Windows.Controls.Grid;

namespace GameOfLife.WPF;


public partial class MainWindow
{
    private const int CellSize = 20; // Size of each cell in pixels
    private new const int Width = 1400 / CellSize; // Number of columns in the grid (width of the grid)
    private new const int Height = 800 / CellSize; // Number of rows in the grid (height of the grid)
    
    private Game _game;
    private readonly GameLoop _gameLoop;
    private readonly GridRenderer _renderer;
    private int _generation = 0;
    private DataBaseService _dataBase = new DataBaseService();
    
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
        
        _renderer.Draw(_game);
    }
    
    // Update the game, next state, every 200ms (GameLoop(intervalMs))
    private void Update()
    {
        _game.Update();

        _generation++;
        GenerationText.Text = $"Generation: {_generation}";
        
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
    

    private void StartClicked(object sender, RoutedEventArgs e) => _gameLoop.Start();
    

    private void PauseClicked(object sender, RoutedEventArgs e) => _gameLoop.Stop();
    
    private void StepClicked(object sender, RoutedEventArgs e)
    {
        _gameLoop.Stop();
        _game.Update();
        _generation++;
        GenerationText.Text = $"Generation: {_generation}";
        _renderer.Draw(_game);
    }
    
    private void ResetClicked(object sender, RoutedEventArgs e)
    {
        _gameLoop.Stop();
        _game.Clear();
        _generation = 0;
        GenerationText.Text = $"Generation: {_generation}";
        _renderer.Draw(_game);
    }
    
    private void RandomClicked(object sender, RoutedEventArgs e)
    {
        _game.Randomize();
        _generation = 0;
        GenerationText.Text = $"Generation: {_generation}";
        _renderer.Draw(_game);
    }
    
    private void StopClicked(object sender, RoutedEventArgs e)
    {
        _gameLoop.Stop();
        _game = new Game(Width, Height);
        _renderer.Draw(_game);
    }

    private void SaveClicked(object sender, RoutedEventArgs e)
    {
        var gridData = _game.Grid.SerializeGrid();
        DataBaseService.SaveGeneration(_generation, gridData);
    }

    private void LoadClicked(object sender, RoutedEventArgs e)
    {
        var data = DataBaseService.LoadLastGeneration();
        if (data == null) return;
        _game.Grid.LoadFromString(data.Value.GridData);
        _generation = data.Value.GenerationNumber;
        GenerationText.Text = $"Generation: {_generation}";
        _renderer.Draw(_game);
    }
}