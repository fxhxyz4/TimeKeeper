using TimeKeeper.Modules.Enum;

namespace TimeKeeper.Modules.Utils;
public static class CheckStaff
{
    private static readonly HashSet<Position> _staffPositions = new()
    {
        Position.Asistent,
        Position.Vykladach,
        Position.StarshyiVykladach,
        Position.KursoviyOfficer,
        Position.NachalnykKursu,
        Position.ZastupnykNachalnyka,
        Position.Nachalnyk
    };

    public static bool IsStaff(Position position)
    {
        return _staffPositions.Contains(position);
    }
}
