using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using SendHelp.ViewModels;

namespace SendHelp.Views;

public partial class MainPage : UserControl
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void OnKeyDown(object sender, KeyEventArgs e)
    {
        switch (e.Key)
        {
            case Key.Left:
                MessageBox.Show("Test");
                break;
        }
    }
}