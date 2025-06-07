using TimeKeeper.Modules;
using System.Windows.Input;
using TimeKeeper.Modules.Data;
using TimeKeeper.Modules.View;
using TimeKeeper.Modules.Enum;
using TimeKeeper.Modules.Utils;
using TimeKeeper.Modules.DataBase;

namespace TimeKeeper;

public partial class MainWindow
{
    private void PersonDataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Delete)
        {
            if (PersonDataGrid.SelectedItem is Person selectedPerson)
            {
                MessageBoxResult result = MessageBox.Show(
                    $"Ви точно хочете видалити {selectedPerson.FirstName} {selectedPerson.LastName}?",
                    "Підтвердження видалення",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning
                );

                if (result == MessageBoxResult.Yes)
                {
                    Position? pos = EnumExtensions.GetPositionByDescription(selectedPerson.Position);

                    if (pos == null)
                    {
                        ErrorNotifier.Display("Некоректна позиція користувача");
                        return;
                    }

                    if (!CheckStaff.IsStaff(pos.Value) && Time.Now.Hour < 14)
                    {
                        ErrorNotifier.Display("Курсант може покинути територію після 14:00");
                        return;
                    }

                    List<Person> people = PersonList.GetAll();
                    people.Remove(selectedPerson);

                    DataGridService.UpdateDataGrid(PersonDataGrid);

                    DataBaseTransaction.DelToDB(selectedPerson, _bus);
                    Logger.WriteLog($"{selectedPerson.FirstName} {selectedPerson.LastName} покинув територію частини\n\n");
                }

                e.Handled = true;
            }
        }
    }
}
