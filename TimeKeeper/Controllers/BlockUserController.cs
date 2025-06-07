using TimeKeeper.Modules.Utils;
using TimeKeeper.Modules.DataBase;

namespace TimeKeeper.Controllers;

public class BlockUserController
{
    private readonly BlockUserRepository _repository = new();

    public bool IsSidBlocked(string sid)
    {
        try
        {
            return _repository.IsSidBlocked(sid);
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
            _repository.BlockSid(sid);
        }
        catch (Exception ex)
        {
            ErrorNotifier.Display("Помилка блокування SID: " + ex.Message);
        }
    }
}

