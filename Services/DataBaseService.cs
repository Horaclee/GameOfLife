using System;
using Microsoft.Data.Sqlite;

namespace Services;

public class DataBaseService
{
    private const string ConnectionString = "Data Source=gameoflife.db";

    public DataBaseService()
    {
        CreateTableIfNotExists();
    }

    private static void CreateTableIfNotExists()
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        
        var command = connection.CreateCommand();
        command.CommandText = """
                              CREATE TABLE IF NOT EXISTS Generations (
                                  Id Integer PRIMARY KEY AUTOINCREMENT,
                                  GenerationNumber Integer,
                                  Grid Text,
                                  CreatedAt Text);
                              """;
        command.ExecuteNonQuery();
        connection.Close();
    }

    public static void SaveGeneration(int generationNumber, string gridData)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = """
                              INSERT INTO Generations (GenerationNumber, Grid, CreatedAt)
                              VALUES ($gen, $grid, $date);
                              """;
        
        command.Parameters.AddWithValue("$gen", generationNumber);
        command.Parameters.AddWithValue("$grid", gridData);
        command.Parameters.AddWithValue("$date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        
        command.ExecuteNonQuery();
        Console.WriteLine($"Generation {generationNumber} saved");
        connection.Close();
    }
    
    public static (int GenerationNumber, string GridData)? LoadLastGeneration()
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();
        
        var command = connection.CreateCommand();
        command.CommandText = """
                              SELECT GenerationNumber, Grid
                              From Generations
                              order by Id DESC
                              LIMIT 1
                              """;
        
        using var reader = command.ExecuteReader();
        if (!reader.Read()) return null;
        var gen = reader.GetInt32(0);
        var grid = reader.GetString(1);
        
        connection.Close(); 
        
        return (gen, grid);
    }
}
