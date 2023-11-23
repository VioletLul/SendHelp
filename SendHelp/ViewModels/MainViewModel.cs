using System.ComponentModel;
using Prism.Mvvm;

using System.Windows;
using System.Windows.Input;
using ABI.Windows.Foundation.Collections;

namespace SendHelp.ViewModels;

public class MainViewModel : BindableBase, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    public double Angle(double _angle)
    {
        OnPropertyChanged(nameof(Angle));
        return _angle;
    }

    public void Arrows(KeyEventArgs e)
    {
        double angle = 0;

        switch (e.Key)
        {
            case Key.RightShift:
                angle = +45;
                break;

            case Key.LeftShift:
                angle = -45;
                break;
        }

        Angle(angle);
    }

    // TODO: Data Binding richtig hinbekommen sonst Schläge uwu :3
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}