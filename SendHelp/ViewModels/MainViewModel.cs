using System.Windows;
using GalaSoft.MvvmLight;
using SendHelp.Views;
using static SendHelp.Views.MainPage;

namespace SendHelp.ViewModels;

public class MainViewModel : ViewModelBase
{
    public MainViewModel()
    {
    }

    public void Calculate(int X, int Y)
    {
        MessageBox.Show("Test");
    }

    public void CalculateDown(int X, int Y)
    {
        MessageBox.Show("Test");
    }
}