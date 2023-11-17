using Microsoft.Data.Sqlite;
using System;
using System.IO;

public class GameModel
{
    private SqliteConnection _connection;

    public GameModel()
    {
        var databasePath = Path.Combine(Environment.CurrentDirectory, "database.db");
        _connection = new SqliteConnection($"Data Source={databasePath}");
        _connection.Open();

        using (var command = _connection.CreateCommand())
        {
            command.CommandText = "CREATE TABLE IF NOT EXISTS Players (Id INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT, Points INTEGER)";
            command.ExecuteNonQuery();
        }
    }

    // Stelle sicher, dass die Verbindung ordnungsgemäß geschlossen wird, wenn das Objekt verworfen wird
    ~GameModel()
    {
        _connection?.Dispose();
    }

    public void AimAndThrowProjectile(Player throwingPlayer, double targetX, double targetY)
    {
        // Hier implementiere die Logik für das Zielen und den Projektilwurf

        // Beispiel: Berechne den Winkel basierend auf Mausposition und Spielerposition
        double deltaX = targetX - throwingPlayer.X;
        double deltaY = targetY - throwingPlayer.Y;
        double angleRadians = Math.Atan2(deltaY, deltaX);
        double angleDegrees = angleRadians * (180 / Math.PI);

        // Beispiel: Berechne die Flugweite basierend auf dem Winkel und anderen Faktoren
        double velocity = 10; // Beispiel: Geschwindigkeit des Projektils
        double gravity = 9.81; // Beispiel: Gravitationskonstante
        double time = CalculateTime(deltaX, deltaY, velocity, gravity);
        double distance = CalculateDistance(velocity, time);

        // Beispiel: Ausführen des Projektilwurfs basierend auf der berechneten Flugweite und des Winkels
        ThrowProjectile(throwingPlayer, distance, angleDegrees);
    }

    private double CalculateDistance(double velocity, double time)
    {
        // Beispiel: Berechne die Flugweite basierend auf der Geschwindigkeit und der Zeit
        return velocity * time;
    }

    private double CalculateTime(double deltaX, double deltaY, double velocity, double gravity)
    {
        // Beispiel: Berechne die Flugzeit basierend auf der Geschwindigkeit und der Gravitation
        return Math.Sqrt((2 * deltaY) / gravity);
    }

    private void ThrowProjectile(Player throwingPlayer, double distance, double angleDegrees)
    {
        // Hier implementiere die tatsächliche Logik für den Projektilwurf
        // Beispiel: Führe den Wurf basierend auf der berechneten Flugweite und des Winkels aus
        // Möglicherweise müsstest du weitere Logik für die Projektildarstellung, Kollisionserkennung usw. hinzufügen
    }
}

public class Player
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Points { get; set; }
    public double X { get; set; }
    public double Y { get; set; }
}