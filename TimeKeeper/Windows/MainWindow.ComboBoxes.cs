using TimeKeeper.Modules.Enum;

namespace TimeKeeper;

public partial class MainWindow
{
    private void InitializeComboBoxes()
    {
        var ranks = RankComboBox.ItemsSource = Enum.GetValues(typeof(Rank))
            .Cast<Rank>()
            .Select(r => new EnumItem<Rank>(r))
            .ToList();

        RankComboBox.ItemsSource = ranks;
        RankComboBox.SelectedIndex = 0;

        var positions = PositionComboBox.ItemsSource = Enum.GetValues(typeof(Position))
            .Cast<Position>()
            .Select(p => new EnumItem<Position>(p))
            .ToList();

        PositionComboBox.ItemsSource = positions;
        PositionComboBox.SelectedIndex = 0;
    }
}
