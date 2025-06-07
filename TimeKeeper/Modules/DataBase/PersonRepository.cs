using MySql.Data.MySqlClient;

namespace TimeKeeper.Modules.DataBase;

public class PersonRepository
{
    public void Add(Person person)
    {
        using var conn = DatabaseConnector.GetConnection();
        conn.Open();

        string query = "INSERT INTO Persons (`first_name`, `last_name`, `year_of_birth`, `rank`, `position`, `date_time`) " +
                       "VALUES (@FirstName, @SecondName, @Year, @Rank, @Position, @Date)";

        using var cmd = new MySqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@FirstName", person.FirstName);

        cmd.Parameters.AddWithValue("@SecondName", person.LastName);
        cmd.Parameters.AddWithValue("@Year", person.YearOfBirth);

        cmd.Parameters.AddWithValue("@Rank", person.Rank);
        cmd.Parameters.AddWithValue("@Position", person.Position);

        cmd.Parameters.AddWithValue("@Date", $"{Time.CurrentDateForFile} {Time.CurrentTimeStamp}");
        cmd.ExecuteNonQuery();
    }

    public List<Person> GetAll()
    {
        List<Person> people = new List<Person>();

        using var conn = DatabaseConnector.GetConnection();
        conn.Open();

        string query = "SELECT * FROM Persons";
        using var cmd = new MySqlCommand(query, conn);

        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            people.Add(new Person(
                reader.GetString("first_name"),
                reader.GetString("last_name"),
                reader.GetInt32("year_of_birth"),
                reader.GetString("rank"),
                reader.GetString("position")
            ));
        }

        return people;
    }

    public void Delete(Person person)
    {
        using var conn = DatabaseConnector.GetConnection();
        conn.Open();

        string query = "DELETE FROM Persons WHERE `first_name` = @FirstName AND `last_name` = @SecondName " +
                       "AND `year_of_birth` = @Year AND `rank` = @Rank AND `position` = @Position";

        using var cmd = new MySqlCommand(query, conn);
        cmd.Parameters.AddWithValue("@FirstName", person.FirstName);

        cmd.Parameters.AddWithValue("@SecondName", person.LastName);
        cmd.Parameters.AddWithValue("@Year", person.YearOfBirth);

        cmd.Parameters.AddWithValue("@Rank", person.Rank);
        cmd.Parameters.AddWithValue("@Position", person.Position);

        cmd.ExecuteNonQuery();
    }
}
