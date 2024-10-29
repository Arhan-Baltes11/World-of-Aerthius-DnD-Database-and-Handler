using MySql.Data.MySqlClient;

namespace AerthiusConsole;

public class Testqueries
{
    public static void Testrun()
    {
        // Connect Database and create a connection
        Database database = new Database();
        // Connection will later be transfered to an instance as a field.
        MySqlConnection conn = database.Connect("Server=localhost;Database=aerthius_world;User ID=root;SSL Mode=None;");

        // Testing the DataReader based on an array of columns
        string query = database.Select("tableone", ["id", "Name"]);
        database.Select("tableName");
        MySqlCommand command = new MySqlCommand(query, conn);
        MySqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            int id = reader.GetInt32("id");
            string name = reader.GetString("name");

            Console.WriteLine(id + ": " + name);
        }

        Console.WriteLine("Select array complete!");
        reader.Close();

        // Testing insertions
        Dictionary<string, string> dictIns = new Dictionary<string, string>
        {
            {"name", "Tom"},
            {"description", "Hello I am Tom"},
            {"status", "alive"}
        };
        string queryIns = database.Insert("tableone", dictIns);
        command = new MySqlCommand(queryIns, conn);
        command.ExecuteNonQuery();
        Console.WriteLine("Insertion Complete");


        // Testing updates

        Dictionary<string, string> dictUpt = new Dictionary<string, string>
        {
            {"name", "Tom"},
            {"description", "Actually, I am Richard"},
            {"status", "alive"}
        };

        string queryUpt = database.Update("tableone", dictUpt, "name = 'Tom'");
        Console.WriteLine(queryUpt);
        command = new MySqlCommand(queryUpt, conn);
        command.ExecuteNonQuery();
        Console.WriteLine("Update Complete");

        // Testing deletion

        string queryDel = database.Delete("tableone", "name = 'Tom'");
        command = new MySqlCommand(queryDel, conn);
        command.ExecuteNonQuery();
        Console.WriteLine("Deletion complete");
    }
}