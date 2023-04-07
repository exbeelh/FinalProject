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
        var repository = new PokemonRepository(connectionString);
        var controller = new PokemonController(repository);

        int menu;
        do
        {
            Console.Clear();
            Console.WriteLine("=================================================");
            Console.WriteLine("=================== Pokedex =====================");
            Console.WriteLine("=================================================");
            Console.WriteLine("1. Add pokemon to database.");
            Console.WriteLine("2. Show all pokemon.");
            Console.WriteLine("3. Show all element.");
            Console.WriteLine("4. Show all abilities.");
            Console.WriteLine("5. Update pokemon.");
            Console.WriteLine("6. Delete pokemon.");
            Console.WriteLine("7. Exit\n");
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
                    ShowElement();
                    break; 
                case 4:
                    ShowAbilities();
                    break;
                case 5:
                    controller.UpdatePokemon();
                    break;
                case 6:
                    controller.DeletePokemon();
                    break;
                case 7:
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
        var repository = new PokemonRepository(connectionString);
        var controller = new PokemonController(repository);

        Console.Clear();
        Console.WriteLine("=================================================");
        Console.WriteLine("=============== Show All Pokemon ================");
        Console.WriteLine("=================================================\n");

        var pokemon = controller.ShowDatabase();

        foreach (var item in pokemon)
        {
            Console.WriteLine("ID          : " + item.Id);
            Console.WriteLine("Name        : " + item.Name);
            Console.WriteLine("Height      : " + item.Height + "\"");
            Console.WriteLine("Weight      : " + item.Weight + " lbs");
            Console.WriteLine("Element     : " + item.Element);
            Console.WriteLine("Abilities   : " + item.Abilities);
            Console.WriteLine("HP          : " + item.Hp);
            Console.WriteLine("Attack      : " + item.AttackPoint);
            Console.WriteLine("Defense     : " + item.DeffensePoint);
            Console.WriteLine("Sp. Attack  : " + item.SpAttack);
            Console.WriteLine("Sp. Defense : " + item.SpDeffense);
            Console.WriteLine("Speed       : " + item.Speed);
            Console.WriteLine("=================================================\n");
        }

        Console.WriteLine("\n\n");
        Console.WriteLine("Press any key to back to main menu ...");
        Console.ReadKey();
        MainMenu();
    }

    public void ShowElement()
    {
        var repository = new ElementRepo(connectionString);
        var controller = new ElementController(repository);

        Console.Clear();
        Console.WriteLine("=================================================");
        Console.WriteLine("=============== Show All Element ================");
        Console.WriteLine("=================================================\n");

        controller.ShowDatabase();

        Console.WriteLine("\n\n");
        Console.WriteLine("Press any key to back to main menu ...");
        Console.ReadKey();
        MainMenu();
    }

    public void ShowAbilities()
    {
        var repository = new AbilitiesRepository(connectionString);
        var controller = new AbilitiesController(repository);

        Console.Clear();
        Console.WriteLine("=================================================");
        Console.WriteLine("=============== Show All Element ================");
        Console.WriteLine("=================================================\n");

        controller.ShowDatabase();

        Console.WriteLine("\n\n");
        Console.WriteLine("Press any key to back to main menu ...");
        Console.ReadKey();
        MainMenu();
    }

}