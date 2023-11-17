using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows.Input;
using SendHelp.Models;

namespace SendHelp.ViewModels;

public abstract class MainViewModel : ViewModelBase
{
    private readonly GameModel _gameModel;

    protected MainViewModel()
    {
        _gameModel = new GameModel();
        ButtonCommand2 = new RelayCommand(ButtonAction2);
        ButtonCommand = new RelayCommand(ButtonAction);

        ThrowRectangleCommand = new RelayCommand(ThrowRectangle);
    }

    public ICommand ButtonCommand { get; }
    public ICommand ButtonCommand2 { get; set; }
    public ICommand ThrowRectangleCommand { get; }

    private void ButtonAction()
    {
    }

    private void ButtonAction2()
    {
    }

    private void ThrowRectangle()
    {
        var playerA = new Player { Points = 0 };
    }
}