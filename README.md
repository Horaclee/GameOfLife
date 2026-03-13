# John Conway's Game of Life - C# WPF

A simple implementation of **John Conway's Game of Life** using **C#**, **.NET**, and **WPF**.  
This project separates the **game logic** (Core) from the **UI** (WPF) and allows interactive simulation with a grid and mouse input.

---

## Features

- Empty grid at startup  
- Click on cells to toggle alive/dead  
- Adjustable grid size and cell size  
- Play/Pause simulation using the **Space** key  
- Separate architecture for **Game Logic**, **Renderer**, and **Timer**  

---

## Project Structure
GameOfLife/
- Core/ # Game logic (Game, Grid, Cell)
- GameOfLife.WPF/ # WPF UI (MainWindow, GridRenderer, GameLoop)
- GameOfLife.sln # Solution file
- .gitignore # Ignored files for build and IDE
- README.md # Project documentation

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

Mouse click: Toggle a cell alive/dead
Space key: Start / Pause simulation

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
gameLoop = new GameLoop(200); // 200 ms per generation
```
