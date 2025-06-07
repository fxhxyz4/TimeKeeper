using TimeKeeper.Modules.Enum;
using TimeKeeper.Modules.Utils;

public static class EnumExtensions
{
    public static string GetDescription(this Enum value)
    {
        try
        {
            FieldInfo field = value.GetType().GetField(value.ToString());
            if (field == null) return value.ToString();

            DescriptionAttribute? attribute = field.GetCustomAttribute<DescriptionAttribute>();
            return attribute?.Description ?? value.ToString();
        }
        catch (Exception ex)
        {
            ErrorNotifier.Display(ex.Message);
            return string.Empty;
        }
    }

    public static Position? GetPositionByDescription(string description)
    {
        foreach (Position pos in Enum.GetValues(typeof(Position)))
        {
            var desc = pos.GetDescription();
            if (desc.Equals(description, StringComparison.OrdinalIgnoreCase))
                return pos;
        }
        return null;
    }
}

public class EnumItem<T> where T : Enum
{
    public T Value { get; }
    public string Description { get; }

    public EnumItem(T value)
    {
        Value = value;
        Description = value.GetDescription();
    }

    public override string ToString() => Description;
}
