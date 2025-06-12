using TimeKeeper.Modules.Utils;
using TimeKeeper.Modules.DataBase;

namespace TimeKeeper.Modules.Controllers;

public class BlockUserController
{
    private readonly BlockUserRepository _repo = new();

    public bool IsSidBlocked(string sid)
    {
        try
        {
            return _repo.IsSidBlocked(sid);
        }
        catch (Exception ex)
        {
            ErrorNotifier.Display("Помилка перевірки SID: " + ex.Message);
            return false;
        }
    }

    public void BlockSid(string sid)
    {
        try
        {
            _repo.BlockSid(sid);
        }
        catch (Exception ex)
        {
            ErrorNotifier.Display("Помилка блокування SID: " + ex.Message);
        }
    }
}

