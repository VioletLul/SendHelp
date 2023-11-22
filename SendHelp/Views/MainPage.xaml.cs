<<<<<<< Updated upstream
﻿using System.Windows;
using System.Windows.Controls;
=======
﻿using System.Windows.Controls;
>>>>>>> Stashed changes
using System.Windows.Input;
using SendHelp.ViewModels;

namespace SendHelp.Views;

public partial class MainPage : UserControl
{
    public MainPage()
    {
        InitializeComponent();
        KeyDown += OnKeyDown;
    }

    private void OnKeyDown(object sender, KeyEventArgs e)
    {
<<<<<<< Updated upstream
        switch (e.Key)
        {
            case Key.Left:
                MessageBox.Show("Test");
                break;
        }
=======
        MainViewModel arrows = new MainViewModel();
        arrows.Arrows(e);
>>>>>>> Stashed changes
    }
}