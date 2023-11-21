﻿using SendHelp.ViewModels;
using System.Windows.Input;

namespace SendHelp.Views;

public partial class MainPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    public void Grid_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        MainViewModel calculationhandler = new MainViewModel();
        var mouseDownPos = Mouse.GetPosition(Grid);
        var mouseDownPosX = (int)mouseDownPos.X;
        var mouseDownPosY = (int)mouseDownPos.Y;
    }

    private void Grid_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        MainViewModel calculationhandler = new();
        var mousePos = Mouse.GetPosition(Grid);
        var mousePosX = (int)mousePos.X;
        var mousePosY = (int)mousePos.Y;
        calculationhandler.Calculate(mousePosX, mousePosY);
    }
}