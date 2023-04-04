using FinalProject.Interfaces;

namespace FinalProject.Controllers;

class ElementController
{
    private readonly IElementRepository _repository;

    public ElementController(IElementRepository repository)
    {
        _repository = repository;
    }
    
    public void ShowDatabase()
    {
        var elements = _repository.GetElements();
        if (elements == null)
        {
            Console.WriteLine("Data is empty.");
        }
        foreach (var item in elements)
        {
            Console.WriteLine("ID              : " + item.Id);
            Console.WriteLine("Name            : " + item.Name);
            Console.WriteLine("Average HP      : " + item.AvgHp);
            Console.WriteLine("Avg Attack      : " + item.AvgAtk);
            Console.WriteLine("Avg Defense     : " + item.AvgDeff);
            Console.WriteLine("Avg Sp.Attack   : " + item.AvgSpAtk);
            Console.WriteLine("Avg Sp.Defense  : " + item.AvgSpDeff);
            Console.WriteLine("Average Speed   : " + item.AvgSpeed);
            Console.WriteLine("=================================================\n");
        }
    }
}