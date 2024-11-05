using MySql.Data.MySqlClient;

namespace AerthiusConsole;

public class Menu
{
    private MySqlConnection _conn { get; set; }

    private Database _database { get; set; }

    public Menu(string connectionString)
    {
        _database = new Database();
        _conn = _database.Connect(connectionString);
    }

    public void MenuLaunch()
    {
        Console.WriteLine("World of Ærthius");
        Console.WriteLine("Select the following from the database tables:");

        categoryCreate();

        string query = _database.Select("players");
        MySqlDataReader reader = _database.ExecuteRead(query, _conn);

        List<Player> players = new List<Player>();

        while (reader.Read())
        {
            Player player = new Player
            {
                Alignment = reader.GetString("alignment"),
                Race = reader.GetString("race"),
                Name = reader.GetString("name"),
                PlayerClass = reader.GetString("class"),
                Level = reader.GetInt32("level")
            };
            string[] specialRulings = reader.GetString("special_rulings").Split(", ");

            foreach (string ruling in specialRulings)
            {
                player.SpecialRulings.Add(ruling);
            }
            players.Add(player);
        }

        reader.Close();
    }

    // Creates the categories based on the tables present in the database.
    private void categoryCreate()
    {
        List<string> tableNames = _database.TableNames("aerthius_world", _conn);

        for (int i = 1; i <= tableNames.Count(); i++)
        {
            Console.WriteLine($"{i}. {tableNames[0]}");
        }
    }

}