namespace TimeKeeper;

public partial class MainWindow
{
    private DispatcherTimer _timer;
    private int interval = 1; // (1s)

    private void timer1_Tick(object sender, EventArgs e)
    {
        TimeTracker();
    }

    public void TimeTracker()
    {
        DateTimeTextBlock.Text = Time.Now.ToString();
    }

    public void StartTimer()
    {
        _timer = new DispatcherTimer();
        _timer.Interval = TimeSpan.FromSeconds(interval);

        _timer.Tick += timer1_Tick;
        _timer.Start();

        TimeTracker();
    }
}
