using System.Windows.Controls;
using TimeKeeper.Modules.Controllers;
using TimeKeeper.Modules.Data;
using TimeKeeper.Modules.Utils;

namespace TimeKeeper.Modules.View;

public class DataGridService
{
    private readonly DataGrid _dataGrid;

    public DataGridService(DataGrid personDataGrid)
    {
        _dataGrid = personDataGrid;
    }

    public void AddToDataGrid(Person person)
    {
        bool exists = PersonList.GetAll().Any(p => p.Equals(person));

        if (exists)
        {
            ErrorNotifier.Display("Such an object already exists");
            return;
        }

        UpdateDataGrid();
    }

    public void ClearDataGrid()
    {
        _dataGrid.ItemsSource = null;
    }

    public void UpdateDataGrid(List<Person> people = null)
    {
        _dataGrid.ItemsSource = null;
        _dataGrid.ItemsSource = people ?? PersonController.GetAllPersons();
    }
}
