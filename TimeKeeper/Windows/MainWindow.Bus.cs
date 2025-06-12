using MassTransit;
using MySql.Data.MySqlClient;

namespace TimeKeeper;

public partial class MainWindow
{
    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        await StartBusAsync();
    }

    private async Task StartBusAsync()
    {
        string rabbitHost = _configuration["RabbitMq:HostName"];
        string rabbitUser = _configuration["RabbitMq:UserName"];
        string rabbitPass = _configuration["RabbitMq:Password"];

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
        MySqlConnection.ClearAllPools();

        await _bus.StopAsync();
        base.OnClosed(e);
    }
}
