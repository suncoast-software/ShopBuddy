namespace ShopBuddy.Core;
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

    }

    private void Border_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.LeftButton == MouseButtonState.Pressed)
            DragMove();
    }
}

