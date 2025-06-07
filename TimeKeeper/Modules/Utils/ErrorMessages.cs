namespace Utils;

public class ErrorMessages {
    // General errors
    public static string TitleErrorMsg => "Error";
    public static string BasicErrorMsg => "An error occurred. Please try again or contact support";
    public static string PasswordErrorMsg => "Password for Admin incorrect";
    public static string LogErrorMsg => "Critical error occurred while logging an error. Skipping recursive logging";

    // SHA256 errors
    public static string Sha256ErrorMsg => "SHA256 Internal Error";
    public static string Sha256GenerateErrorMsg => "SHA256 generate Error";
    public static string Sha256ValidateErrorMsg => "SHA256 validation Error";


    // File system errors
    public static string FileNotFoundError => "File not found. Please check the file path.";
    public static string FileAccessDeniedError => "Access to the file is denied. Check the file permissions.";
    public static string FileReadError => "Failed to read the file. Please check if the file is corrupted.";
    public static string FileWriteError => "Failed to write to the file. Check the folder permissions or available disk space.";
    public static string DirectoryFoundError => "Directory not found. Please check the directory path.";

    // Internet connection errors
    public string InternetConnectionError => "No internet connection. Please check your network connection.";
    public string TimeoutError => "The request timed out. Check your connection or try again later.";
    public string InvalidUrlError => "Invalid URL. Please check the URL format.";
    public string ServerError => "Server error. Please try again later.";

    // Database errors
    public static string DbConnectionError => "Failed to connect to the database. Please check your connection settings.";
    public static string DbQueryError => "Error executing the database query.";
    public static string DbTransactionError => "Error while performing the transaction. Please try again.";
    public static string DbTimeoutError => "The database query timed out.";
    public static string DbNotFoundError => "The requested record was not found in the database.";

    // System errors
    public static string NullReferenceError => "An error occurred: Value cannot be null.";
    public static string InvalidArgumentError => "Invalid argument passed to the method. Please check the input data.";
    public static string UnhandledExceptionError => "An unexpected error occurred in the program. Please contact support.";
}
