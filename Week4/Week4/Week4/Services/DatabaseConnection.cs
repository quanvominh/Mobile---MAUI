using SQLite;
using Week4.Interfaces;

namespace Week4.Services
{
    public class DatabaseConnection : IDatabaseConnection
    {
        string GetPath(string fileName)
        {
            var path = Path.Combine(GetDatabasePath(), fileName);

            if (!File.Exists(path)) File.Create(path);

            return path;
        }

        public string GetDatabasePath()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        }

        public SQLiteConnection SqliteConnection(string databaseName)
        {
            return new SQLiteConnection(GetPath(databaseName));
        }

        public long GetSize(string databaseName)
        {
            var fileInfo = new FileInfo(GetPath(databaseName));
            return fileInfo.Length;
        }
    }
}
