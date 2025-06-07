using MassTransit;
using TimeKeeper.Modules.Queue;
using TimeKeeper.Modules.Utils;
using TimeKeeper.Modules.DataBase;

public class DbUpdatedConsumer : IConsumer<DbChangedEvent>
{
    public static event Action? OnDbUpdated;

    public async Task Consume(ConsumeContext<DbChangedEvent> context)
    {
        try
        {
            await Task.Run(() => DataBaseTransaction.UpdateDB());

            Application.Current.Dispatcher.Invoke(() =>
            {
                OnDbUpdated?.Invoke();
            });
        }
        catch (Exception ex)
        {
            ErrorNotifier.Display("Error in DbUpdatedConsumer: " + ex.Message);
            throw;
        }
    }
}
