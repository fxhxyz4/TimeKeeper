using MassTransit;
using TimeKeeper.Modules.Utils;
using TimeKeeper.Modules.DataBase;
using TimeKeeper.Modules.Queue;

namespace TimeKeeper.Modules.Controllers;

public class PersonController
{
    private readonly PersonRepository _repo = new();
    private readonly IBus _bus;

    public PersonController(IBus bus)
    {
        _bus = bus;
    }

    public async Task AddPerson(Person person)
    {
        try
        {
            await _repo.Add(person);
            await _bus.Publish(new DbChangedEvent("add", "ready"));
        }
        catch (Exception ex)
        {
            ErrorNotifier.Display("Помилка при додаванні користувача: " + ex.Message);
        }
    }

    public async Task UpdateDb()
    {
        try
        {
            await _repo.UpdateDB();
        }
        catch (Exception ex)
        {
            ErrorNotifier.Display("Помилка при додаванні користувача: " + ex.Message);
        }
    }

    public async Task DeletePerson(Person person)
    {
        try
        {
            await _repo.Delete(person);
            await _bus.Publish(new DbChangedEvent("delete", "ready"));
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
            return new PersonRepository().GetAll();
        }
        catch (Exception ex)
        {
            ErrorNotifier.Display("Помилка отримання списку користувачів: " + ex.Message);
            return new List<Person>();
        }
    }
}
