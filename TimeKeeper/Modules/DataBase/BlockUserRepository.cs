using MySql.Data.MySqlClient;

namespace TimeKeeper.Modules.DataBase;

class BlockUserRepository
{
    public void BlockSid(string sid)
    {
        try
        {
            using var conn = DatabaseConnector.GetConnection();
            conn.Open();

            string query = "INSERT INTO BlockUsers (sid) VALUES (@sid);";
            using MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@sid", sid);
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            MySqlConnection.ClearAllPools();
            throw new Exception("DB insert failed", ex);
        }
    }

    public bool IsSidBlocked(string sid)
    {
        try
        {
            using var conn = DatabaseConnector.GetConnection();
            conn.Open();

            string query = "SELECT 1 FROM BlockUsers WHERE sid = @sid LIMIT 1;";
            using MySqlCommand cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@sid", sid);
            using var reader = cmd.ExecuteReader();

            return reader.HasRows;
        }
        catch (Exception ex)
        {
            MySqlConnection.ClearAllPools();
            throw new Exception("DB query failed", ex);
        }
    }
}
