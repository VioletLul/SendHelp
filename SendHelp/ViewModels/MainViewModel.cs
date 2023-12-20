using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Prism.Commands;
using SendHelp.Models;
using Prism.Mvvm;
using ICommand = System.Windows.Input.ICommand;

namespace SendHelp.ViewModels
{
    public sealed class MainViewModel : INotifyPropertyChanged
    {
        private readonly Projectile _projectile;

        public MainViewModel()
        {//Initialisierung
            Projectile = new Projectile();
            VisualizeCommand = new DelegateCommand(VisualizeAction);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Projectile Projectile
        {
            get => _projectile;
            private init
            {
                _projectile = value;
                OnPropertyChanged();
            }
        }

        public ICommand VisualizeCommand
        {//Deklaration
            get;
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void VisualizeAction()
        {
            Projectile.CalculateDistance();
        }
    }
}