using Prism.Mvvm;
using System.Windows;
using System.Windows.Input;
using GalaSoft;

namespace SendHelp.ViewModels;

public class MainViewModel : BindableBase
{
    private var mousePos = Mouse.GetPosition(Button);

    private var mousePosX = mousePos.X;

    private var mousePosY = mousePos.Y;

    public MainViewModel()
    {
        Grid_OnMouseLeftButtonUp = new RelayCommand();
    }

    public ICommand Grid_OnMouseLeftButtonUp { get; set; }

    private void //Grid_OnMouseLeftButtonUp//(object sender, MouseButtonEventArgs e)
    {
        MessageBox.Show(Convert.ToString("Y= " + mousePosY));
        MessageBox.Show(Convert.ToString("X= " + mousePosX));
    }
}