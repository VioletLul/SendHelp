using System.IO;
using System.Linq.Expressions;
using Microsoft.Data.Sqlite;

namespace SendHelp.Models;

public class GameModel
{
    private readonly SqliteConnection _connection;

    public GameModel()
    {
        var databasePath = Path.Combine(Environment.CurrentDirectory, "database.db");
        _connection = new SqliteConnection($"Data Source={databasePath}");
        _connection.Open();

        using var command = _connection.CreateCommand();
        command.CommandText = "CREATE TABLE IF NOT EXISTS Players (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Points INTEGER)";
        command.ExecuteNonQuery();
    }

    // Stelle sicher, dass die Verbindung ordnungsgemäß geschlossen wird, wenn das Objekt verworfen wird
    ~GameModel()
    {
        _connection?.Dispose();
    }
}

public class Player
{
    public int Points { get; set; }
}