namespace TimeKeeper.Modules;

/// <summary>
/// Sealed class
/// </summary>
public sealed class Staff : Person
{
    private bool _isStaff;

    public bool IsStaff
    {
        get => _isStaff;
        set => _isStaff = value;
    }

    public Staff() : base() { }

    public Staff(string firstName, string lastName, int yearOfBirth, string rank, string position, bool isStaff)
        : base(firstName, lastName, yearOfBirth, rank, position)
    {
        _isStaff = isStaff;
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Person other)
            return false;

        return FirstName == other.FirstName &&
               LastName == other.LastName &&
               YearOfBirth == other.YearOfBirth;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(FirstName, LastName, YearOfBirth);
    }

    public override string ToString()
    {
        string baseInfo = base.ToString();
        return $"{baseInfo}, Staff: {IsStaff}";
    }
}
