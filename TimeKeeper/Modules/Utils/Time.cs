namespace Utils;

public static class Time
{
    public static string CurrentDateForFile => DateTime.Now.ToString("yyyy-MM-dd");
    public static string CurrentTimeStamp => DateTime.Now.ToString("HH:mm:ss");
    public static DateTime Now => DateTime.Now;
}
