using Prism.Mvvm;
using System.ComponentModel;
using System.Windows.Input;

namespace SendHelp.ViewModels;

public class MainViewModel : BindableBase, INotifyPropertyChanged
{
    public new event PropertyChangedEventHandler PropertyChanged;

    public double Angle(double angle)
    {
        OnPropertyChanged(nameof(Angle));
        return angle;
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