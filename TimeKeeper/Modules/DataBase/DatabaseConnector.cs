using MySql.Data.MySqlClient;
using TimeKeeper.Modules;
using TimeKeeper.Modules.Utils;

class DatabaseConnector
{
    private static readonly string _connectionString;

    static DatabaseConnector()
    {
        try
        {
            string root = Directory.GetCurrentDirectory();
            string dotenvPath = Path.Combine(root, "env", ".env");

            DotEnv.Load(dotenvPath);
            _connectionString = DotEnv.CreateConnectionString();
        } catch (Exception ex)
        {
            ErrorNotifier.Display(ErrorMessages.DbTimeoutError + " " + ex.Message);
        }
    }

    /// <summary>
    /// Returns a new MySqlConnection instance. Must be opened by the caller.
    /// </summary>
    /// <returns>conn</returns>
    public static MySqlConnection GetConnection()
    {
        try
        {
            return new MySqlConnection(_connectionString);
        } catch (Exception ex)
        {
            ErrorNotifier.Display(ErrorMessages.DbConnectionError + " " + ex.Message);
            return null;
        }
    }
}
