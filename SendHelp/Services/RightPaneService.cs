using MahApps.Metro.Controls;
using Prism.Regions;
using SendHelp.Constants;
using SendHelp.Contracts.Services;
using SendHelp.Helpers;
using System.Windows.Controls;

namespace SendHelp.Services;

public abstract class RightPaneService : IRightPaneService
{
    private readonly IRegionManager _regionManager;
    private IRegionNavigationService _rightPaneNavigationService;
    private SplitView _splitView;

    public RightPaneService(IRegionManager regionManager)
    {
        _regionManager = regionManager;
    }

    public event EventHandler PaneClosed;

    public event EventHandler PaneOpened;

    public void CleanUp()
    {
        _splitView.PaneClosed -= OnPaneClosed;
        _regionManager.Regions.Remove(Regions.RightPane);
    }

    public void Initialize(SplitView splitView, ContentControl rightPaneContentControl)
    {
        _splitView = splitView;
        RegionManager.SetRegionName(rightPaneContentControl, Regions.RightPane);
        RegionManager.SetRegionManager(rightPaneContentControl, _regionManager);
        _rightPaneNavigationService = _regionManager.Regions[Regions.RightPane].NavigationService;
        _splitView.PaneClosed += OnPaneClosed;
    }

    public void OpenInRightPane(string pageKey, NavigationParameters navigationParameters = null)
    {
        if (_rightPaneNavigationService.CanNavigate(pageKey))
        {
            _rightPaneNavigationService.RequestNavigate(pageKey, navigationParameters);
        }

        _splitView.IsPaneOpen = true;
        PaneOpened?.Invoke(_splitView, EventArgs.Empty);
    }

    private void OnPaneClosed(object sender, EventArgs e)
       => PaneClosed?.Invoke(sender, e);
}