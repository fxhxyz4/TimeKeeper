using MassTransit;
using TimeKeeper.Modules.DataBase;

namespace TimeKeeper;

public partial class MainWindow
{
    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        await StartBusAsync();
        _repo.UpdateDB();
    }

    private async Task StartBusAsync()
    {
        var rabbitHost = _configuration["RabbitMq:HostName"];
        var rabbitUser = _configuration["RabbitMq:UserName"];
        var rabbitPass = _configuration["RabbitMq:Password"];

        _bus = Bus.Factory.CreateUsingRabbitMq(cfg =>
        {
            cfg.Host(new Uri(rabbitHost), h =>
            {
                h.Username(rabbitUser);
                h.Password(rabbitPass);
            });

            cfg.ReceiveEndpoint("db_updates_queue", e =>
            {
                e.Consumer<DbUpdatedConsumer>();
            });
        });

        await _bus.StartAsync();
    }

    protected override async void OnClosed(EventArgs e)
    {
        await _bus.StopAsync();
        base.OnClosed(e);
    }
}
