using MassTransit;
using TimeKeeper.Modules;
using TimeKeeper.Modules.DataBase;
using TimeKeeper.Modules.Queue;
using TimeKeeper.Modules.Utils;

namespace TimeKeeper.Controllers;

public class PersonController
{
    private readonly PersonRepository _repo = new();
    private readonly IBus _bus;

    public PersonController(IBus bus)
    {
        _bus = bus;
    }

    public void AddPerson(Person person)
    {
        try
        {
            _repo.Add(person);
            _bus.Publish(new DbChangedEvent("add", "ready"));
        }
        catch (Exception ex)
        {
            ErrorNotifier.Display("Помилка при додаванні користувача: " + ex.Message);
        }
    }

    public void DeletePerson(Person person)
    {
        try
        {
            _repo.Delete(person);
            _bus.Publish(new DbChangedEvent("delete", "ready"));
        }
        catch (Exception ex)
        {
            ErrorNotifier.Display("Помилка при видаленні користувача: " + ex.Message);
        }
    }

    public static List<Person> GetAllPersons()
    {
        try
        {
            var repo = new PersonRepository();
            return repo.GetAll();
        }
        catch (Exception ex)
        {
            ErrorNotifier.Display("Помилка отримання списку користувачів: " + ex.Message);
            return new List<Person>();
        }
    }
}
