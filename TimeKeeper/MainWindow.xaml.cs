using MassTransit;
using TimeKeeper.Modules.View;
using TimeKeeper.Modules.Utils;
using Microsoft.Extensions.Configuration;
using TimeKeeper.Modules.DataBase;

namespace TimeKeeper;

public partial class MainWindow : Window
{
    private PersonRepository _repo = new();
    private IConfiguration _configuration;
    private IBusControl _bus;

    public MainWindow()
    {
        InitializeComponent();
        InitializeComboBoxes();

        RabbitConfig rabbitConfig = new();
        _configuration = rabbitConfig.Configuration;

        _ = StartBusAsync();
        DataGridService.UpdateDataGrid(PersonDataGrid);

        PersonDataGrid.PreviewKeyDown += PersonDataGrid_PreviewKeyDown;
        DbUpdatedConsumer.OnDbUpdated += () =>
        {
            DataGridService.UpdateDataGrid(PersonDataGrid);
        };

        StartTimer();
    }
}
