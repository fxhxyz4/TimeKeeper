using MassTransit;
using MySql.Data.MySqlClient;
using TimeKeeper.Modules.Data;
using TimeKeeper.Modules.Queue;
using TimeKeeper.Modules.Utils;

namespace TimeKeeper.Modules.DataBase;

class DataBaseTransaction
{
    public static async Task AddToDB(Person person, IBus bus)
    {
        try
        {
            using MySqlConnection conn = DatabaseConnector.GetConnection();
            conn.Open();

            string query = "INSERT INTO Persons (`first_name`, `last_name`, `year_of_birth`, `rank`, `position`, `date_time`) " +
                           "VALUES (@FirstName, @SecondName, @Year, @Rank, @Position, @Date)";

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@FirstName", person.FirstName);
                cmd.Parameters.AddWithValue("@SecondName", person.LastName);
                cmd.Parameters.AddWithValue("@Year", person.YearOfBirth);
                cmd.Parameters.AddWithValue("@Rank", person.Rank);
                cmd.Parameters.AddWithValue("@Position", person.Position);
                cmd.Parameters.AddWithValue("@Date", $"{Time.CurrentDateForFile} {Time.CurrentTimeStamp}");

                cmd.ExecuteNonQuery();
            }

            await bus.Publish(new DbChangedEvent("add", "ready"));
        }
        catch (Exception ex)
        {
            ErrorNotifier.Display(ErrorMessages.DbTransactionError + " " + ex.Message);
        }
    }

    public static void UpdateDB()
    {
        try
        {
            using MySqlConnection conn = DatabaseConnector.GetConnection();
            conn.Open();

            string query = "SELECT `first_name`, `last_name`, `year_of_birth`, `rank`, `position`, `date_time` FROM Persons";

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                PersonList.Clear();

                while (reader.Read())
                {
                    string firstName = reader.GetString("first_name");
                    string secondName = reader.GetString("last_name");

                    int year = reader.GetInt32("year_of_birth");
                    string rank = reader.GetString("rank");

                    string position = reader.GetString("position");
                    DateTime date = reader.GetDateTime("date_time");

                    Person person = new Person(firstName, secondName, year, rank, position);
                    PersonList.Add(person);
                }
            }
        }
        catch (Exception ex)
        {
            ErrorNotifier.Display(ErrorMessages.DbTransactionError + " " + ex.Message);
        }
    }



    public static async Task DelToDB(Person person, IBus bus)
    {
        try
        {
            using MySqlConnection conn = DatabaseConnector.GetConnection();
            conn.Open();

            string query = "DELETE FROM Persons WHERE `first_name` = @FirstName AND `last_name` = @SecondName " +
                           "AND `year_of_birth` = @Year AND `rank` = @Rank AND `position` = @Position";

            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@FirstName", person.FirstName);
                cmd.Parameters.AddWithValue("@SecondName", person.LastName);
                cmd.Parameters.AddWithValue("@Year", person.YearOfBirth);
                cmd.Parameters.AddWithValue("@Rank", person.Rank);
                cmd.Parameters.AddWithValue("@Position", person.Position);

                cmd.ExecuteNonQuery();
            }

            await bus.Publish(new DbChangedEvent("delete", "ready"));
        }
        catch (Exception ex)
        {
            ErrorNotifier.Display(ErrorMessages.DbTransactionError + " " + ex.Message);
        }
    }
}
