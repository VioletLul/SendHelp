using System.IO;
using System.Reflection;

using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Prism.Regions;

using Unity;

using WPFSpiel__send_help_.Contracts.Services;
using WPFSpiel__send_help_.Core.Contracts.Services;
using WPFSpiel__send_help_.Core.Services;
using WPFSpiel__send_help_.Models;
using WPFSpiel__send_help_.Services;
using WPFSpiel__send_help_.ViewModels;

namespace WPFSpiel__send_help_.Tests.MSTest;

[TestClass]
public class PagesTests
{
    private readonly IUnityContainer _container;

    public PagesTests()
    {
        _container = new UnityContainer();
        _container.RegisterType<IRegionManager, RegionManager>();

        // Core Services
        _container.RegisterType<IFileService, FileService>();

        // App Services
        _container.RegisterType<IThemeSelectorService, ThemeSelectorService>();
        _container.RegisterType<IPersistAndRestoreService, PersistAndRestoreService>();

        // Configuration
        var appLocation = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location);
        var configuration = new ConfigurationBuilder()
            .SetBasePath(appLocation)
            .AddJsonFile("appsettings.json")
            .Build();
        var appConfig = configuration
            .GetSection(nameof(AppConfig))
            .Get<AppConfig>();

        // Register configurations to IoC
        _container.RegisterInstance(configuration);
        _container.RegisterInstance(appConfig);
    }

    // TODO: Add tests for functionality you add to MainViewModel.
    [TestMethod]
    public void TestMainViewModelCreation()
    {
        var vm = _container.Resolve<MainViewModel>();
        Assert.IsNotNull(vm);
    }
}
