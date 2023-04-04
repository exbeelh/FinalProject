using FinalProject.Interfaces;
using FinalProject.Views;
using Models.FinalProject;

namespace FinalProject.Controllers;

class PokemonController
{
    private readonly IPokemonRepository _repository;

    public PokemonController(IPokemonRepository repository)
    {
        _repository = repository;
    }

    private readonly PokemonView view = new();

    public void AddPokemon()
    {
        Console.Clear();
        Console.Write("Enter pokemon name => ");
        var name = NullValidation("Name", Console.ReadLine());

        Console.Write("Enter pokemon height => ");
        var height = double.Parse(Console.ReadLine());
        
        Console.Write("Enter pokemon weight => ");
        var weight = double.Parse(Console.ReadLine());
        
        Console.Write("Enter pokemon element => ");
        var element = NullValidation("Element", Console.ReadLine());
        
        Console.Write("Enter pokemon can evolve [true | false] => ");
        var isEvolve = bool.Parse(Console.ReadLine());

        Console.Write("Enter pokemon abilities => ");
        var abilities = NullValidation("Abilities", Console.ReadLine());

        Console.Write("Enter pokemon health point => ");
        var hp = int.Parse(Console.ReadLine());
        
        Console.Write("Enter pokemon attack point => ");
        var atk = int.Parse(Console.ReadLine());
        
        Console.Write("Enter pokemon deffense point => ");
        var def = int.Parse(Console.ReadLine());
        
        Console.Write("Enter pokemon special attack => ");
        var spAtk = int.Parse(Console.ReadLine());
        
        Console.Write("Enter pokemon special deffense => ");
        var spDef = int.Parse(Console.ReadLine());
        
        Console.Write("Enter pokemon speed => ");
        var speed = int.Parse(Console.ReadLine());

        var pokemon = new Pokemon()
        {
            Name = name,
            Height = height,
            Weight = weight,
            Element = element,
            Abilities = abilities,
            IsEvolve = isEvolve,
            Hp = hp,
            AttackPoint = atk,
            DeffensePoint = def,
            SpAttack = spAtk,
            SpDeffense = spDef,
            Speed = speed
        };

        _repository.CreateData(pokemon);

        Console.WriteLine("Data has been added, press any key to continue ....");
        Console.ReadKey();

        view.MainMenu();
    }

    public void UpdatePokemon()
    {
        Console.Clear();
        Console.Write("Enter pokemon id => ");
        int id = int.Parse(Console.ReadLine());

        var pokemon = _repository.GetDataById(id);
        
        if (pokemon == null)
        {
            Console.WriteLine($"Pokemon with id {id} is not found");
            Console.ReadKey();
            UpdatePokemon();
        }

        try
        {
            Console.Write("Enter new pokemon name => ");
            var name = Console.ReadLine();
            if (!string.IsNullOrEmpty(name))
            {
                pokemon.Name = name;
            }

            Console.Write("Enter new pokemon height => ");
            var height = double.Parse(Console.ReadLine());
            if (!double.IsNaN(height))
            {
                pokemon.Height = height;
            }

            Console.Write("Enter new pokemon weight => ");
            var weight = double.Parse(Console.ReadLine());
            if (!double.IsNaN(weight))
            {
                pokemon.Weight = weight;
            }

            Console.Write("Enter new pokemon element => ");
            var element = Console.ReadLine();
            if (!string.IsNullOrEmpty(element))
            {
                pokemon.Element = element;
            }

            Console.Write("Enter new pokemon abilities => ");
            var abillities = Console.ReadLine();
            if (!string.IsNullOrEmpty(abillities))
            {
                pokemon.Abilities = abillities;
            }

            Console.Write("Enter new pokemon is evolve => ");
            var isEvolve = bool.Parse(Console.ReadLine());
            if (isEvolve)
            {
                pokemon.IsEvolve = isEvolve;
            }

            Console.Write("Enter new pokemon health point => ");
            var hp = int.Parse(Console.ReadLine());
            if (hp > 0)
            {
                pokemon.Hp = hp;
            }

            Console.Write("Enter new pokemon attack point => ");
            var atk = int.Parse(Console.ReadLine());
            if (atk > 0)
            {
                pokemon.AttackPoint = atk;
            }

            Console.Write("Enter new pokemon deffense point => ");
            var def = int.Parse(Console.ReadLine());
            if (def > 0)
            {
                pokemon.DeffensePoint = def;
            }

            Console.Write("Enter new pokemon special attack => ");
            var spAtk = int.Parse(Console.ReadLine());
            if (spAtk > 0)
            {
                pokemon.SpAttack = spAtk;
            }

            Console.Write("Enter new pokemon special deffense => ");
            var spDef = int.Parse(Console.ReadLine());
            if (spDef > 0)
            {
                pokemon.SpDeffense = spDef;
            }

            Console.Write("Enter new pokemon speed => ");
            var speed = int.Parse(Console.ReadLine());
            if (speed > 0)
            {
                pokemon.Speed = speed;
            }

            Console.WriteLine("Data has been updated.");

            _repository.UpdateData(pokemon);
        }
        catch (Exception ex) 
        {
            Console.WriteLine(ex.Message);
        }

        view.MainMenu();
    }

    public void DeletePokemon()
    {
        Console.Write("Enter ID pokemon => ");
        var id = int.Parse(Console.ReadLine());
        _repository.DeleteData(id);
        Console.WriteLine($"Pokemon with id {id} has been remove from pokedex");
        Console.ReadKey();

        view.MainMenu();
    }

    public void ShowDatabase()
    {
        var pokemon = _repository.GetAllData();
                if (pokemon == null)
        {
            Console.WriteLine("Data is empty.");
        }
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
    }

    private string NullValidation(string name, string value)
    {
        bool status;
        do
        {
            if (value.Length >= 3)
            {
                status = false;
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"{name} should not null, enter at least 3 character.");
                Console.ReadKey();
                AddPokemon();
                status = true;
            }
        } while (status);
        return value;
    }
}
