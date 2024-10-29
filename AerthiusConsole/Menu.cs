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
        Console.WriteLine("Welcome to the World of Ærthius!");
        Console.WriteLine("This is a database console.");
        Console.WriteLine("There's currently nothing here. Stay tuned for categories!");

        Console.WriteLine("So hey, here's a few player entries."); // Remember to fill in the table known as `players`.
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

        foreach (Player player in players)
        {
            player.WritePlayerInfo();
        }
    }

}