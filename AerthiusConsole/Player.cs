using System.Reflection;
using MySql.Data.MySqlClient;

namespace AerthiusConsole;

public class Player
{
    public string Name;

    public string Race;

    public string Alignment;

    public string PlayerClass;

    public int Level;

    public List<string> SpecialRulings = new List<string>();

    public Player()
    {
        // SetData(data, connection);
    }

    public void SetData(Database data, MySqlConnection connection)
    {
        string query = data.Select("players");
        MySqlDataReader reader = data.ExecuteRead(query, connection);

        while (reader.Read())
        {
            Name = reader.GetString("name");
            Race = reader.GetString("race");
            Alignment = reader.GetString("alignment");
            PlayerClass = reader.GetString("class");
            Level = reader.GetInt32("level");
            string[] specialRulings = reader.GetString("special_rulings").Split(", ");

            foreach (string ruling in specialRulings)
            {
                SpecialRulings.Add(ruling);
            }
        }

    }

    public void WritePlayerInfo()
    {
        foreach (FieldInfo fieldInfo in GetType().GetFields())
        {
            Console.WriteLine(fieldInfo.Name + ": " + fieldInfo.GetValue(this));
        }
    }

}