using GalaSoft.MvvmLight;

namespace SendHelp.ViewModels;

public class MainViewModel : ViewModelBase
{
    public MainViewModel()
    {
    }

    public static void Calculate(int x, int y)
    {
        var stärkeX = x + y;
    }
}