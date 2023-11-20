using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SendHelp.Views;

public partial class MainPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void Grid_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        var mousePos = Mouse.GetPosition(Button);
        var mousePosX = mousePos.X;
        var mousePosY = mousePos.Y;
        MessageBox.Show(Convert.ToString("Y: " + (int)mousePosY) + "\n" + Convert.ToString("X: " + (int)mousePosX));
    }
}