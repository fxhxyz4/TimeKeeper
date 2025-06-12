using TimeKeeper.Modules;
using TimeKeeper.Modules.Enum;
using TimeKeeper.Modules.Utils;

namespace TimeKeeper;

public partial class MainWindow
{
    private Person GetInputData()
    {
        string firstName = NameTextBox.Text.Trim();
        string secondName = SurnameTextBox.Text.Trim();

        int year = int.TryParse(BirthYearTextBox.Text, out int y) ? y : 0;

        var rankItem = RankComboBox.SelectedItem as EnumItem<Rank>;
        var positionItem = PositionComboBox.SelectedItem as EnumItem<Position>;

        string rankDescription = rankItem?.Description.Trim() ?? "";
        string positionDescription = positionItem?.Description.Trim() ?? "";

        ClearInput();

        if (CheckStaff.IsStaff(positionItem.Value))
        {
            return new Staff(firstName, secondName, year, rankDescription, positionDescription, true);
        } else
        {
            return new Person(firstName, secondName, year, rankDescription, positionDescription);
        }
    }

    private void ClearInput()
    {
        NameTextBox.Text = "";
        SurnameTextBox.Text = "";

        BirthYearTextBox.Text = "";

        var rankToSelect = RankComboBox.Items.Cast<EnumItem<Rank>>().FirstOrDefault(x => x.Value == Rank.Rekrut);
        RankComboBox.SelectedItem = rankToSelect;

        var posToSelect = PositionComboBox.Items.Cast<EnumItem<Position>>().FirstOrDefault(x => x.Value == Position.Gosti);
        PositionComboBox.SelectedItem = posToSelect;
    }

    private async void addBtn_Click(object sender, EventArgs e)
    {
        Person person = GetInputData();

        if (!ValidatePerson(person))
        {
            ErrorNotifier.Display(ErrorMessages.InvalidArgumentError);
            return;
        }

        Logger.WriteLog(person.ToString());

        if (_bus == null)
        {
            ErrorNotifier.Display("Помилка: MassTransit шина не ініціалізована.");
            return;
        }

        await _controller.AddPerson(person);

        Files.UpdateCsv(person.ToString());
        Files.UpdateJson(person);

        _dataGridService.AddToDataGrid(person);
    }

    /// <summary>
    /// Validate input arguments
    /// </summary>
    /// <param name="person"></param>
    /// <returns>Boolean</returns>
    private bool ValidatePerson(Person person)
    {
        if (string.IsNullOrWhiteSpace(person.FirstName)
            || string.IsNullOrWhiteSpace(person.LastName)
            || person.YearOfBirth < 1890 || person.YearOfBirth > DateTime.Now.Year
            || string.IsNullOrWhiteSpace(person.Rank)
            || string.IsNullOrWhiteSpace(person.Position))
        {
            return false;
        }

        return true;
    }
}
