using MySql.Data.MySqlClient;

/*
    The database that I plan on using is just the standard MariaDB connection string.
    The default route is just 127.0.0.1
    You can use any way to view the database. But for me, I just use xampp. It has MySQL built in.
*/

namespace AerthiusConsole;

public class Database
{
    string connString = "Server=localhost;Database=aerthius_world;User ID=root;SSL Mode=None;";

    // Connects you to the database found on ConnectionString
    public void Connect()
    {
        MySqlConnection conn = new MySqlConnection
        {
            ConnectionString = connString
        };

        conn.Open();
        Console.WriteLine("If you are reading this, the connection to the database is established.");
    }

    public void Select(string table)
    {
        Console.WriteLine("All the columns from" + table + " Is here.");
    }

    public void Select(string[] columns, string table)
    {
        foreach (string column in columns)
        {
            Console.WriteLine(column);
        }
    }

    public void Update(string table)
    {
        Console.WriteLine(table + " has now updated the column(s)!");
    }

    public void Delete()
    {
        Console.WriteLine("This column entry is gone!");
    }
}