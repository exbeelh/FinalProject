using FinalProject.Controllers;
using FinalProject.Repositories;

namespace FinalProject.Views;

class PokemonView
{
    readonly string connectionString = "Data Source=DESKTOP-GK251JV\\SQLEXPRESS;" +
                                       "Integrated Security=True;" +
                                       "Connect Timeout=30;" +
                                       "Database=db_pokemon";
    public void MainMenu()
    {
        var repository = new PokemonRepositories(connectionString);
        var controller = new PokemonController(repository);

        int menu;
        do
        {
            Console.Clear();
            Console.WriteLine("=================================================");
            Console.WriteLine("=================== Pokedex =====================");
            Console.WriteLine("=================================================");
            Console.WriteLine("1. Add pokemon to database.");
            Console.WriteLine("2. Show all pokemon data.");
            Console.WriteLine("3. Update pokemon.");
            Console.WriteLine("4. Delete pokemon.");
            Console.WriteLine("5. Exit\n");
            Console.Write("Input > ");
            menu = int.Parse(Console.ReadLine());

            switch(menu)
            {
                case 1:
                    controller.AddPokemon();
                    break;
                case 2:
                    ShowData();
                    break;
                case 3:
                    controller.UpdatePokemon();
                    break;
                case 4:
                    controller.DeletePokemon();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Pokedex has been shutdown ....");
                    Environment.Exit(1);
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Command not found!");
                    break;
            }
        }
        while (menu >= 10);
    }

    public void ShowData()
    {
        var repository = new PokemonRepositories(connectionString);
        var controller = new PokemonController(repository);

        Console.Clear();
        Console.WriteLine("=================================================");
        Console.WriteLine("=============== Show All Pokemon ================");
        Console.WriteLine("=================================================\n");

        controller.ShowDatabase();

        Console.WriteLine("\n\n");
        Console.WriteLine("Press any key to back to main menu ...");
        Console.ReadKey();
        MainMenu();
    }

}