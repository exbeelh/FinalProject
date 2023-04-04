using FinalProject.Interfaces;

namespace FinalProject.Controllers;

class AbilitiesController
{
    private readonly IAbilitiesRepository _repository;

    public AbilitiesController(IAbilitiesRepository repository)
    {
        _repository = repository;
    }

    public void ShowDatabase()
    {
        var elements = _repository.GetAbilities();
        if (elements == null)
        {
            Console.WriteLine("Data is empty.");
        }
        foreach (var item in elements)
        {
            Console.WriteLine("Name            : " + item.Name);
            Console.WriteLine("Element         : " + item.Element);
            Console.WriteLine("Make Effect     : " + item.Effect);
            Console.WriteLine("Damagable       : " + item.Damagable);
            Console.WriteLine("=================================================\n");
        }
    }
}