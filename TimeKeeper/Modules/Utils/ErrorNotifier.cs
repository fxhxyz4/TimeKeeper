namespace TimeKeeper.Modules.Utils;

class ErrorNotifier
{
    public static void Display(string msg)
    {
        MessageBox.Show(msg, ErrorMessages.TitleErrorMsg, MessageBoxButton.OK, MessageBoxImage.Error);
    }
}
