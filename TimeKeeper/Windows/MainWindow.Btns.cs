using System.Diagnostics;
using System.Windows.Controls;
using MySql.Data.MySqlClient;
using TimeKeeper.Modules.Utils;

namespace TimeKeeper;

public partial class MainWindow
{
    private void logsBtn_Click(object sender, EventArgs e)
    {
        string folderPath = Logger._logPath;
        Process.Start("explorer.exe", folderPath);
    }

    private void csvBtn_Click(object sender, EventArgs e)
    {
        string folderPath = Files._csvPath;
        Process.Start("explorer.exe", folderPath);
    }

    private void jsonBtn_Click(object sender, EventArgs e)
    {
        string folderPath = Files._jsonPath;
        Process.Start("explorer.exe", folderPath);
    }

    private void button_Click(object sender, EventArgs e)
    {
        Button clickedButton = sender as Button;

        if (clickedButton != null)
        {
            MySqlConnection.ClearAllPools();
            this.Close();
        }
    }
}
