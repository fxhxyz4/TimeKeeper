using System.Windows.Controls;
using TimeKeeper.Controllers;
using TimeKeeper.Modules.Data;
using TimeKeeper.Modules.Utils;

namespace TimeKeeper.Modules.View;

class DataGridService
{
    public static void AddToDataGrid(DataGrid dataGrid, Person person)
    {
        bool exists = PersonList.GetAll().Any(p => p.Equals(person));

        if (exists)
        {
            ErrorNotifier.Display("Such an object already exists");
            return;
        }

        PersonList.Add(person);
        UpdateDataGrid(dataGrid);
    }

    public static void ClearDataGrid(DataGrid dataGrid)
    {
        dataGrid.ItemsSource = null;
    }

    public static void UpdateDataGrid(DataGrid dataGrid, List<Person> people = null)
    {
        dataGrid.ItemsSource = null;
        dataGrid.ItemsSource = people ?? PersonController.GetAllPersons();
    }
}
