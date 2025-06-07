namespace TimeKeeper.Modules.Data;

public class PersonList
{
    private static readonly List<Person> _collection = new();

    public int Count => _collection.Count;

    public static void Add(Person person) => _collection.Add(person);
    public static void Clear() => _collection.Clear();

    public static void Delete(int index)
    {
        if (index >= 0 && index < _collection.Count)
            _collection.RemoveAt(index);
    }

    public static List<Person> GetAll() => new(_collection);
}
