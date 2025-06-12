using Newtonsoft.Json;

namespace TimeKeeper.Modules.Utils;

class Files
{
    public static readonly string _csvPath;
    public static readonly string _jsonPath;

    static Files()
    {
        try
        {
            string projectRoot = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName;
            _csvPath = Path.Combine(projectRoot ?? ".", "csv");
            _jsonPath = Path.Combine(projectRoot ?? ".", "json");
        }
        catch (Exception ex)
        {
            ErrorNotifier.Display(ErrorMessages.DirectoryFoundError);
            _csvPath = "csv";
            _jsonPath = "json";
        }
    }

    public static void UpdateCsv(string csvMessage)
    {
        try
        {
            string dateForFile = Time.CurrentDateForFile;

            if (!Directory.Exists(_csvPath))
                Directory.CreateDirectory(_csvPath);

            string csvFilePath = Path.Combine(_csvPath, $"{dateForFile}.csv");

            using (StreamWriter output = new StreamWriter(csvFilePath, append: true))
            {
                output.WriteLine($"{csvMessage ?? "No log message!"}");
            }
        }
        catch (Exception ex)
        {
            ErrorNotifier.Display($"{ex.StackTrace} {ex.Message}");
        }
    }

    public static void UpdateJson(Person person)
    {
        try
        {
            string dateForFile = Time.CurrentDateForFile;

            if (!Directory.Exists(_jsonPath))
                Directory.CreateDirectory(_jsonPath);

            string jsonFilePath = Path.Combine(_jsonPath, $"{dateForFile}.json");

            List<Person> people = new List<Person>();

            if (File.Exists(jsonFilePath))
            {
                string existingJson = File.ReadAllText(jsonFilePath);
                people = JsonConvert.DeserializeObject<List<Person>>(existingJson) ?? new List<Person>();
            }
            else
            {
                ErrorNotifier.Display(ErrorMessages.FileNotFoundError);
            }

            people.Add(person);

            string updatedJson = JsonConvert.SerializeObject(people, Formatting.Indented);
            File.WriteAllText(jsonFilePath, updatedJson);
        }
        catch (Exception ex)
        {
            ErrorNotifier.Display($"{ex.StackTrace} {ex.Message}");
        }
    }
}
