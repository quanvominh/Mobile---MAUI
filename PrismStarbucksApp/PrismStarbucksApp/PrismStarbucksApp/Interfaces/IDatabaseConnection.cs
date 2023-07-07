using SQLite;

namespace PrismStarbucksApp.Interfaces
{
    public interface IDatabaseConnection
    {
        SQLiteConnection SqliteConnection(string databaseName);
        long GetSize(string databaseName);
        string GetDatabasePath();
    }
}
