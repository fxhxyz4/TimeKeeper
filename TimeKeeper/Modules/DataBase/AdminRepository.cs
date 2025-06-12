using MySql.Data.MySqlClient;
using TimeKeeper.Modules.Utils;

namespace TimeKeeper.Modules.DataBase;

class AdminRepository
{
    public static string GetAdminHash()
    {
       try
        {
            using MySqlConnection conn = DatabaseConnector.GetConnection();
            conn.Open();

            string query = "SELECT pass FROM Admin;";
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return reader.GetString(0);
                    }

                    ErrorNotifier.Display(ErrorMessages.DbQueryError);
                    return "";
                }
            }
        } catch (Exception ex)
        {
            ErrorNotifier.Display(ErrorMessages.DbTransactionError + " " + ex.Message);
            MySqlConnection.ClearAllPools();

            return "";
        }
    }
}
