using MahApps.Metro.Controls;

using Prism.Regions;

using SendHelp.Constants;
using SendHelp.Contracts.Services;

namespace SendHelp.Views;

public partial class ShellWindow : MetroWindow
{
    public ShellWindow(IRegionManager regionManager, IRightPaneService rightPaneService)
    {
        InitializeComponent();
        RegionManager.SetRegionName(MenuContentControl, Regions.Main);
        RegionManager.SetRegionManager(MenuContentControl, regionManager);
        rightPaneService.Initialize(SplitView, RightPaneContentControl);
    }
}