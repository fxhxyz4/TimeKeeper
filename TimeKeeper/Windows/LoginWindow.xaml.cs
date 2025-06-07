using System.Security.Principal;
using TimeKeeper.Modules.Utils;
using TimeKeeper.Windows;
using TimeKeeper.Controllers;

namespace TimeKeeper;

public partial class LoginWindow : Window
{
    private BlockUserController _controller = new BlockUserController();
    private string _sid = WindowsIdentity.GetCurrent().User?.Value;

    private int _blockCount = 0;

    /// <summary>
    /// Blocked user using SID name
    /// </summary>
    public LoginWindow()
    {
        if (_controller.IsSidBlocked(_sid))
        {
            BlockWindow window = new BlockWindow();
            window.Show();

            this.Close();
        }

        InitializeComponent();
    }

    /// <summary>
    /// Login button event with password
    /// If the password is incorrect, the program window closes
    /// </summary>
    private void Login_Click(object sender, RoutedEventArgs e)
    {
        string inputPassword = PasswordBox.Password;
        string inputHash = GenerateHash(inputPassword);

        if (_blockCount >= 2)
        {
            _controller.BlockSid(_sid);
            this.Close();
        }

        if (!ValidateHash(inputHash))
        {
            ErrorNotifier.Display(ErrorMessages.PasswordErrorMsg);
            _blockCount += 1;

            return;
        } else
        {
            new MainWindow().Show();
            this.Close();
        }
    }
}
