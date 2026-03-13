using System.Windows.Threading;

namespace GameOfLife.WPF;

public class GameLoop
{
    private readonly DispatcherTimer _timer;

    public event Action? Tick;

    protected internal GameLoop(int intervalMs)
    {
        _timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromMilliseconds(intervalMs)
        };
        _timer.Tick += OnTick;
    }

    private void OnTick(object? sender, EventArgs e) => Tick?.Invoke();
    
    public void Start() => _timer.Start();
    
    public void Stop() => _timer.Stop();
    
    public void Toggle() => _timer.IsEnabled = !_timer.IsEnabled;
    
    public bool IsRunning => _timer.IsEnabled;
    
}