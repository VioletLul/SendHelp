using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SendHelp.Views;

public partial class MainPage : UserControl
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void Grid_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        var mousePos = Mouse.GetPosition(grid);
        var mousePosX = mousePos.X;
        var mousePosY = mousePos.Y;
        MessageBox.Show(Convert.ToString("Y: " + mousePosY));
        MessageBox.Show(Convert.ToString("X: " + mousePosX));
    }
}