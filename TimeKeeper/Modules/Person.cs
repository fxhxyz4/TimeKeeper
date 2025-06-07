namespace TimeKeeper.Modules;

public class Person
{
    private string _firstName;
    private string _lastName;

    private int _yearOfBirth;
    private string _rank;

    private string _position;
    private string _date;

    public string FirstName
    {
        get => _firstName;
        set => _firstName = value;
    }

    public string LastName
    {
        get => _lastName;
        set => _lastName = value;
    }

    public int YearOfBirth
    {
        get => _yearOfBirth;
        set => _yearOfBirth = value;
    }

    public string Rank
    {
        get => _rank;
        set => _rank = value;
    }

    public string Position
    {
        get => _position;
        set => _position = value;
    }

    public string Date
    {
        get => _date;
        set => _date = value;
    }

    public Person() { }

    public Person(string firstName, string lastName, int yearOfBirth, string rank, string position)
    {
        _firstName = firstName;
        _lastName = lastName;
        _yearOfBirth = yearOfBirth;
        _rank = rank;
        _position = position;
        _date = $"{Time.CurrentDateForFile} {Time.CurrentTimeStamp}";
    }

    public virtual bool Equals(object? obj)
    {
        if (obj is not Person other)
            return false;

        return FirstName == other.FirstName &&
               LastName == other.LastName &&
               YearOfBirth == other.YearOfBirth;
    }

    public virtual int GetHashCode()
    {
        return HashCode.Combine(FirstName, LastName, YearOfBirth);
    }

    public virtual string ToString()
    {
        return $"{FirstName} {LastName}, {YearOfBirth}, {Rank}, {Position}";
    }
}
