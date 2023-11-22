
using System.Windows;

using System.Security.Cryptography.Xml;
using System.Windows;
using System.Windows.Controls;

using System.Windows.Input;
using Prism.Mvvm;

namespace SendHelp.ViewModels;

public class MainViewModel : BindableBase
{
    public MainViewModel()
    {
    }

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

        }
    }
}    