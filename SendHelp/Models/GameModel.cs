using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendHelp.Models
{
    public class GameModel
    {
        private SqliteConnection _connection;

        public GameModel()
        {
            var databasePath = Path.Combine(Environment.CurrentDirectory, "database.db");
            _connection = new SqliteConnection($"Data Source={databasePath}");
            _connection.Open();

            using var command = _connection.CreateCommand();
            command.CommandText =
                "CREATE TABLE IF NOT EXISTS Players (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Points INTEGER)";
            command.ExecuteNonQuery();
        }

        // Stelle sicher, dass die Verbindung ordnungsgemäß geschlossen wird, wenn das Objekt verworfen wird
        ~GameModel()
        {
            _connection?.Dispose();
        }

        public void ThrowRectangle(Player throwingPlayer, Player receivingPlayer)
        {
            // Hier die Logik für den Rechteck-Wurf und den Treffer implementieren

            // Beispiel: Wenn ein Treffer erfolgt
            receivingPlayer.Points++;
            using var command = _connection.CreateCommand();
            command.CommandText = "UPDATE Players SET Points = @Points WHERE Id = @Id";
            command.Parameters.AddWithValue("@Points", receivingPlayer.Points);
            command.Parameters.AddWithValue("@Id", receivingPlayer.Id);
            command.ExecuteNonQuery();
        }
    }

    public class Player
    {
        public int Id { get; }
        public int Points { get; set; }
    }
}