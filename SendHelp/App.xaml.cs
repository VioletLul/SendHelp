using CommunityToolkit.WinUI.Notifications;
using Microsoft.Extensions.Configuration;
using Prism.Ioc;
using Prism.Unity;
using SendHelp.Constants;
using SendHelp.Contracts.Services;
using SendHelp.Core.Contracts.Services;
using SendHelp.Core.Services;
using SendHelp.Models;
using SendHelp.Services;
using SendHelp.ViewModels;
using SendHelp.Views;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Threading;

namespace SendHelp;

// For more information about application lifecycle events see https://docs.microsoft.com/dotnet/framework/wpf/app-development/application-management-overview
// For docs about using Prism in WPF see https://prismlibrary.com/docs/wpf/introduction.html

// WPF UI elements use language en-US by default.
// If you need to support other cultures make sure you add converters and review dates and numbers in your UI to ensure everything adapts correctly.
// Tracking issue for improving this is https://github.com/dotnet/wpf/issues/1946
public partial class App : PrismApplication
{
    public const string ToastNotificationActivationArguments = "ToastNotificationActivationArguments";

    private string[] _startUpArgs;

    public App()
    {
    }

    protected override Window CreateShell()
        => Container.Resolve<ShellWindow>();

    protected override async void OnInitialized()
    {
        var themeSelectorService = Container.Resolve<IThemeSelectorService>();
        themeSelectorService.InitializeTheme();

        var persistAndRestoreService = Container.Resolve<IPersistAndRestoreService>();
        persistAndRestoreService.RestoreData();

        // https://docs.microsoft.com/windows/apps/design/shell/tiles-and-notifications/send-local-toast?tabs=desktop
        ToastNotificationManagerCompat.OnActivated += (toastArgs) =>
        {
            Current.Dispatcher.Invoke(async () =>
            {
                var config = Container.Resolve<IConfiguration>();

                // Store ToastNotification arguments in configuration, so you can use them from any point in the app
                config[App.ToastNotificationActivationArguments] = toastArgs.Argument;

                App.Current.MainWindow.Show();
                App.Current.MainWindow.Activate();
                if (App.Current.MainWindow.WindowState == WindowState.Minimized)
                {
                    App.Current.MainWindow.WindowState = WindowState.Normal;
                }

                await Task.CompletedTask;
            });
        };

        /*var toastNotificationsService = Container.Resolve<IToastNotificationsService>();*/
        /*toastNotificationsService.ShowToastNotificationSample();*/

        if (ToastNotificationManagerCompat.WasCurrentProcessToastActivated())
        {
            // ToastNotificationActivator code will run after this completes and will show a window if necessary.
            return;
        }

        base.OnInitialized();
        await Task.CompletedTask;
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        _startUpArgs = e.Args;
        base.OnStartup(e);
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        // Core Services
        containerRegistry.Register<IFileService, FileService>();

        // App Services
        containerRegistry.Register<IThemeSelectorService, ThemeSelectorService>();
        /*containerRegistry.RegisterSingleton<IToastNotificationsService, ToastNotificationsService>();*/
        containerRegistry.Register<IPersistAndRestoreService, PersistAndRestoreService>();
        containerRegistry.RegisterSingleton<IRightPaneService, RightPaneService>();

        // Views
        containerRegistry.RegisterForNavigation<MainPage, MainViewModel>(PageKeys.Main);
        containerRegistry.RegisterForNavigation<ShellWindow, ShellViewModel>();

        // Configuration
        var configuration = BuildConfiguration();
        var appConfig = configuration
            .GetSection(nameof(AppConfig))
            .Get<AppConfig>();

        // Register configurations to IoC
        containerRegistry.RegisterInstance<IConfiguration>(configuration);
        containerRegistry.RegisterInstance<AppConfig>(appConfig);
    }

    private IConfiguration BuildConfiguration()
    {
        // TODO: Register arguments you want to use on App initialization
        var activationArgs = new Dictionary<string, string>
        {
            { ToastNotificationActivationArguments, string.Empty }
        };

        var appLocation = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        return new ConfigurationBuilder()
            .SetBasePath(appLocation)
            .AddJsonFile("appsettings.json")
            .AddCommandLine(_startUpArgs)
            .AddInMemoryCollection(activationArgs)
            .Build();
    }

    private void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
    {
        // TODO: Please log and handle the exception as appropriate to your scenario
        // For more info see https://docs.microsoft.com/dotnet/api/system.windows.application.dispatcherunhandledexception?view=netcore-3.0
    }

    private void OnExit(object sender, ExitEventArgs e)
    {
        var persistAndRestoreService = Container.Resolve<IPersistAndRestoreService>();
        persistAndRestoreService.PersistData();
    }
}