<<<<<<< Updated upstream
﻿using System.Windows;
=======
﻿using System.Security.Cryptography.Xml;
using System.Windows;
using System.Windows.Controls;
>>>>>>> Stashed changes
using System.Windows.Input;
using Prism.Mvvm;

namespace SendHelp.ViewModels;

public class MainViewModel : BindableBase
{
    public MainViewModel()
    {
    }

<<<<<<< Updated upstream
    public static void Arrows(KeyEventArgs e)
    {
        switch (e.Key)
        {
            case Key.Right:
                MessageBox.Show("TestRight");
                break;

            case Key.Left:
                MessageBox.Show("TestLeft");
                break;
=======
    public void Arrows(KeyEventArgs e)
    {
        switch (e.Key)
        {
            case Key.Left:
                MessageBox.Show("TestLeft");
                break;

            case Key.Right:
                MessageBox.Show("TestRight");
                break;
>>>>>>> Stashed changes
        }
    }
}