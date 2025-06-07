namespace TimeKeeper.Modules.Utils;

public static class Logger
{
    private static bool _isLoggingError = false;

    public static readonly string _logPath;

    static Logger()
    {
        try
        {
            string projectRoot = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName;
            _logPath = Path.Combine(projectRoot ?? ".", "logs");
        }
        catch (Exception ex)
        {
            ErrorNotifier.Display(ErrorMessages.DirectoryFoundError);
            _logPath = "logs";
        }
    }

    public static void WriteLog(string logMessage)
    {
        try
        {
            DateTime dateAndTime = Time.Now;
            string dateForFile = Time.CurrentDateForFile;

            if (!Directory.Exists(_logPath))
                Directory.CreateDirectory(_logPath);

            string logFilePath = Path.Combine(_logPath, $"{dateForFile}.log");

            using (StreamWriter output = new StreamWriter(logFilePath, append: true))
            {
                output.WriteLine($"[{dateAndTime.ToString().Replace("_", ":")}]: {logMessage ?? "No log message!"}");
            }
        }
        catch (Exception ex)
        {
            if (!_isLoggingError)
            {
                _isLoggingError = true;

                try
                {
                    File.AppendAllText("logger_internal_error.log", $"{DateTime.Now}: {ex}\n");
                }
                catch {  }

                ErrorNotifier.Display($"Logger error: {ex.Message}");
            }
        }

    }
}
