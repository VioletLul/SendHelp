using GalaSoft.MvvmLight;

namespace SendHelp.ViewModels;

public class MainViewModel : ViewModelBase
{
    public MainViewModel()
    {
    }

    public void Calculate(int X, int Y)
    {
        var StärkeX = X + Y;
    }
}