using TimeKeeper.Modules;
using System.Windows.Input;
using TimeKeeper.Modules.Data;
using TimeKeeper.Modules.Enum;
using TimeKeeper.Modules.Utils;

namespace TimeKeeper;

public partial class MainWindow
{
    private async void PersonDataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        try
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
                            ErrorNotifier.Display("Курсант може покинути територію тільки після 14:00");
                            return;
                        }

                        await HandleDelete(selectedPerson);

                        List<Person> people = PersonList.GetAll();
                        people.Remove(selectedPerson);

                        _dataGridService.UpdateDataGrid();
                        Logger.WriteLog($"{selectedPerson.FirstName} {selectedPerson.LastName} {selectedPerson.YearOfBirth} ({selectedPerson.Rank}, {selectedPerson.Position}) покинув територію частини\n\n");
                    }

                    e.Handled = true;
                }
            }
        } catch (Exception ex)
        {
            ErrorNotifier.Display(ex.Message);       
        }
    }

    private async Task HandleDelete(Person selectedPerson)
    {
        await _controller.DeletePerson(selectedPerson);
    }

}
