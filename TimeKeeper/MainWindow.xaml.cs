using MassTransit;
using TimeKeeper.Modules.View;
using TimeKeeper.Modules.Utils;
using TimeKeeper.Modules.Controllers;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace TimeKeeper;

public partial class MainWindow : Window
{
    private IConfiguration _configuration;
    private PersonController _controller;

    private DataGridService _dataGridService;
    private IBusControl _bus;

    public MainWindow()
    {
        InitializeComponent();
        InitializeComboBoxes();

        RabbitConfig rabbitConfig = new();
        _configuration = rabbitConfig.Configuration;

        _ = StartBusAsync();
        _controller = new PersonController(_bus);

        _dataGridService = new DataGridService(PersonDataGrid);

        PersonDataGrid.PreviewKeyDown += PersonDataGrid_PreviewKeyDown;

        DbUpdatedConsumer.Initialize(_bus);
        DbUpdatedConsumer.OnDbUpdated += () =>
        {
            _dataGridService.UpdateDataGrid();
        };

        // first program start
        _dataGridService.UpdateDataGrid();

        StartTimer();
    }
}
