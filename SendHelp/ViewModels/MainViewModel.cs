using System.ComponentModel;
using GalaSoft.MvvmLight.CommandWpf;
using Prism.Mvvm;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using SendHelp.Models;

namespace SendHelp.ViewModels;

public class MainViewModel : ViewModelBase
{
    private GameModel _gameModel;

    public MainViewModel()
    {
        _gameModel = new GameModel();
        ButtonCommand2 = new RelayCommand(ButtonAction2);
        ButtonCommand = new RelayCommand(ButtonAction);

        ThrowRectangleCommand = new RelayCommand(ThrowRectangle);
    }

    // INotifyPropertyChanged-Implementierung

    public ICommand ButtonCommand { get; }
    public ICommand ButtonCommand2 { get; set; }
    public ICommand ThrowRectangleCommand { get; }

    private void ButtonAction()
    {
        MessageBox.Show("Spieler 2", "Online");
    }

    private void ButtonAction2()
    {
        MessageBox.Show("Spieler 1", "Online");
    }

    private void ThrowRectangle()
    {
        Player playerA = new Player { Points = 0 };
        Player playerB = new Player { Points = 0 };

        _gameModel.ThrowRectangle(playerA, playerB);
    }
}