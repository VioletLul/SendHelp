using System.Reflection;

using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Prism.Regions;

using SendHelp.Contracts.Services;
using SendHelp.Core.Contracts.Services;
using SendHelp.Core.Services;
using SendHelp.Models;
using SendHelp.Services;
using SendHelp.ViewModels;

using Unity;

namespace SendHelp.Tests.MSTest;

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