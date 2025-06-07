using TimeKeeper.Modules.Utils;

namespace TimeKeeper.Modules;

class DotEnv
{
    /// <summary>
    /// Load dotenv file
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns>connectionString</returns>
    public static void Load(string filePath)
    {
        if (!File.Exists(filePath))
            ErrorNotifier.Display(ErrorMessages.FileNotFoundError);

        foreach (var line in File.ReadAllLines(filePath))
        {
            if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#"))
                continue;

            var parts = line.Split('=', 2, StringSplitOptions.TrimEntries);

            if (parts.Length == 2)
                Environment.SetEnvironmentVariable(parts[0], parts[1]);
        }
    }

    public static string CreateConnectionString()
    {
        try
        {
            string host = Environment.GetEnvironmentVariable("HOST") ?? "localhost";
            string port = Environment.GetEnvironmentVariable("PORT") ?? "3306";
            string user = Environment.GetEnvironmentVariable("USER") ?? "root";
            string pass = Environment.GetEnvironmentVariable("PASS") ?? "";
            string db = Environment.GetEnvironmentVariable("DB") ?? "timekeeper";

            return $"Server={host};Port={port};Database={db};Uid={user};Pwd={pass};SslMode=none;";
        } catch (Exception ex)
        {
            ErrorNotifier.Display(ErrorMessages.BasicErrorMsg);
            return string.Empty;
        }
    }
}
