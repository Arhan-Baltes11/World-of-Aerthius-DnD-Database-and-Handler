namespace AerthiusConsole;

class Program
{
    private static void Main()
    {
        Console.WriteLine("Aerthius Console, Version 0.1");
        // Testqueries.Testrun(); // Test queries to see if the database is functional
        Menu mainMenu = new Menu("Server=localhost;Database=aerthius_world;User ID=root;SSL Mode=None;");
        mainMenu.MenuLaunch();
    }
}