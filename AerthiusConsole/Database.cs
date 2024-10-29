using System.Data.Common;
using System.Reflection.Metadata.Ecma335;
using MySql.Data.MySqlClient;

/*
    The database that I plan on using is just the standard MariaDB connection string.
    The default route is just 127.0.0.1
    You can use any way to view the database. But for me, I just use xampp. It has MySQL built in.
*/

namespace AerthiusConsole;

public class Database
{
    // Connects you to the database found on ConnectionString
    public MySqlConnection Connect(string connectionString)
    {
        MySqlConnection conn = new MySqlConnection
        {
            ConnectionString = connectionString
        };

        conn.Open();
        Console.WriteLine("If you are reading this, the connection to the database is established.");

        return conn;
    }

    // Select one column from a table
    public string Select(string table, string column)
    {
        return "SELECT " + column + " FROM " + table;
    }

    // Select all from the following table
    public string Select(string table)
    {
        return "SELECT * FROM " + table;
    }

    // Select from the following columns
    public string Select(string table, string[] columns)
    {
        string columnString = "SELECT ";

        for (int i = 0; i < columns.Count(); i++)
        {
            columnString += columns[i];

            if (i != columns.Count() - 1)
            {
                columnString += ", ";
            }
        }

        return columnString + " FROM " + table;
    }

    public string SelectWhere(string table, string condition, string[] columns)
    {
        string selectColumnsQuery = Select(table, columns);
        return selectColumnsQuery + " WHERE " + condition;
    }

    // Select all from a table with this condition
    public string SelectWhere(string table, string condition)
    {
        string selectAllQuery = Select(table);

        return selectAllQuery + " WHERE " + condition;
    }

    // Insert a single group of values based on the parameters
    public string Insert(string table, Dictionary<string, string> dict)
    {
        // Dictionary for this case is <column, value>.

        string insertString = "INSERT INTO " + table;

        insertString += "(";

        // If the ID is always an auto_increment, it should be fine to not include the id column
        for (int i = 0; i < dict.Count(); i++)
        {
            insertString += dict.ElementAt(i).Key;
            if (i != dict.Count() - 1)
            {
                insertString += ", ";
            }
        }

        insertString += ") VALUES (";
        // With this dictionary, it's unlikely we'll have an OutOfBounds error here
        for (int i = 0; i < dict.Count(); i++)
        {
            insertString += "'" + dict.ElementAt(i).Value + "'";
            if (i != dict.Count() - 1)
            {
                insertString += ", ";
            }
        }

        insertString += ")";

        return insertString;
    }

    public MySqlDataReader ExecuteRead(string query, MySqlConnection conn)
    {
        MySqlCommand command = new MySqlCommand(query, conn);
        MySqlDataReader reader = command.ExecuteReader();
        return reader;
    }

    // Updates the table with the following conditions
    public string Update(string table, Dictionary<string, string> dict, string condition)
    {
        string updateString = "UPDATE " + table + " SET ";

        // Same as in the Insert method, Dictionary<string,string> is <column, value>.
        for (int i = 0; i < dict.Count(); i++)
        {
            updateString += dict.ElementAt(i).Key + " = " + "'" + dict.ElementAt(i).Value + "'";

            if (i != dict.Count() - 1)
            {
                updateString += ", ";
            }
        }

        return updateString + " WHERE " + condition;
    }

    // Deletes column(s) from the table based on the condition provided
    public string Delete(string table, string condition)
    {
        return "DELETE FROM " + table + " WHERE " + condition;
    }
}