namespace AerthiusConsole;
class Program
{
    private static void Main()
    {
        Console.WriteLine("Aerthius Console, Version 0.1");
        Database database = new Database();
        database.Connect();
        database.Select(["One", "Two"], "tableName");
        database.Select("tableName");
    }
}