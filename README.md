# John Conway's Game of Life - C# WPF

A simple implementation of **John Conway's Game of Life** using **C#**, **.NET**, and **WPF**.  
This project separates the **game logic** (Core) from the **UI** (WPF) and allows interactive simulation with a grid and mouse input.

---

## Features

- Empty grid at startup  
- Click on cells to toggle alive/dead  
- Play/Pause/Step/Reset/Clear/Random buttons
- Generation counter display
- Tracks alive and dead cells per generation
- Save/load generations locally in SQLite
- Optional integration with GameStats API to save results online
- Separate architecture for Game Logic, Renderer, and Timer
- Fast, smooth WPF UI


---

## Project Structure
GameOfLife/
- Core/                 # Game logic (Game, Grid, Cell)
- GameOfLife.WPF/       # WPF UI (MainWindow, GridRenderer, GameLoop,  GameStatsService)
- Services/             # SQLite database service
- GameStatsApi/         # ASP.NET Core Web API for storing game statistics
- GameOfLife.sln        # Solution file
- .gitignore            # Ignored files for build and IDE
- README.md             # Project documentation


---

## Requirements

- .NET 9 SDK or later  
- JetBrains Rider or Visual Studio  
- Windows OS (for WPF)

---

## How to Run

1. Clone the repository:
```bash
git clone https://github.com/Horaclee/GameOfLife.git
cd GameOfLife
```
2. Open GameOfLife.sln in Rider or Visual Studio.
3. Set GameOfLife.WPF as the startup project.
4.Build and run the solution.
You should see an empty grid, ready to interact with.

---

## Controls

- Mouse click:     Toggle a cell alive/dead
- Space key:       Start / Pause simulation
- Start button:	   Start auto simulation
- Pause button:	   Pause simulation
- Step button:     Advance one generation
- Reset button:    Clear all cells and reset generation counter
- Clear button:    Clear the grid without affecting settings
- Random button:	 Fill the grid randomly with alive/dead cells
--- 

## Customization
### Adjust Cell Size

Change the size of each cell in pixels:
```bash
private const int CellSize = 20; // width and height of each cell
```

### Adjust Grid Size

Change the number of cells horizontally and vertically:
```bash
private const int GridWidth = 70; // number of columns
private const int GridHeight = 40; // number of rows
```

### Adjust Simulation Speed

Change the timer interval in GameLoop (milliseconds):
```bash
gameLoop = new GameLoop(20); // 200 ms per generation
```


## DataBase (SQLite)
Table: Generations

Column	            Type
Id	                INTEGER PRIMARY KEY AUTOINCREMENT
GenerationNumber	  INTEGER
Width	              INTEGER
Height	            INTEGER
CellsAlive	        INTEGER
CellsDead	          INTEGER
Grid	              TEXT
CreatedAt	          TEXT

- Save generations with Save button.
- Load the last generation with Load Last button.

## GameStats API

GET /api/Game – Get all results
POST /api/GameResults – Add new game result
GET /api/Game/best – Get the last result
GET /api/GameResults/{id} – Get result by ID


## Teck Stack
- Languages: C#, XAML
- Frameworks: .NET 9, WPF, Entity Framework Core
- Database: SQLite
- Tools: Visual Studio / Rider, Git/GitHub


## Future Improvements

- Add AI for automated gameplay
- Detect and highlight specific patterns
- Enhanced leaderboard via API
- Export/import grid states
- More statistics and analytics

## Screenshots
