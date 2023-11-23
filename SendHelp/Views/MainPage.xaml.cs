using SendHelp.ViewModels;

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

    private void Image_OnImageFailed(object sender, ExceptionRoutedEventArgs e)
    {
        MessageBox.Show("Bild konnte nicht geladen werden. \nSorry...");
    }

    private void OnKeyDown(object sender, KeyEventArgs e)
    {
        MainViewModel help = new();
        help.Arrows(e);
    }
}