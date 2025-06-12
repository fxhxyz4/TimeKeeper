using MassTransit;
using TimeKeeper.Modules.Queue;
using TimeKeeper.Modules.Utils;
using TimeKeeper.Modules.Controllers;

public class DbUpdatedConsumer : IConsumer<DbChangedEvent>
{
    private readonly PersonController _controller;
    public static event Action? OnDbUpdated;

    private static IBus _bus;

    public static void Initialize(IBus bus)
    {
        _bus = bus;
    }

    public async Task Consume(ConsumeContext<DbChangedEvent> context)
    {
        try
        {
            PersonController controller = new PersonController(_bus);
            await controller.UpdateDb();

            Application.Current.Dispatcher.Invoke(() => OnDbUpdated?.Invoke());
        }
        catch (Exception ex)
        {
            ErrorNotifier.Display("Error in DbUpdatedConsumer: " + ex.Message);
            throw;
        }
    }
}
