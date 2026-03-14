using System.Net.Http;
using System.Net.Http.Json;

namespace GameOfLife.WPF;

public class GameStatsService
{
    private readonly HttpClient _httpClient;

    public GameStatsService()
    {
        _httpClient = new HttpClient(
            new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            });
        _httpClient.BaseAddress = new Uri("http://localhost:5053/");
    }

    public async Task SendResultAsync(int gridWidth, int gridHeight, int cellsAlive, int cellsDead, int generation)
    {
        var result = new GameResult
        {
            Generation = generation,
            GridWidth = gridWidth,
            GridHeight = gridHeight,
            CellsAlive = cellsAlive,
            CellsDead = cellsDead,
            Date = DateTime.Now
        };

        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/Game", result);
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException e)
        {
            System.Windows.MessageBox.Show(
                $"Impossible d'envoyer les donnees : {e.Message}", "Erreur API",
                System.Windows.MessageBoxButton.OK,
                System.Windows.MessageBoxImage.Error
                );
        }
    }

    public async Task<List<GameResult>> GetResultsAsync()
    {
        try
        {
            var results = await _httpClient.GetFromJsonAsync<List<GameResult>>("api/Game");
            return results ?? new List<GameResult>();
        }
        catch
        {
            return new List<GameResult>();
        }
    }
}

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