using MahApps.Metro.Controls;

using Prism.Regions;

using WPFSpiel__send_help_.Constants;
using WPFSpiel__send_help_.Contracts.Services;

namespace WPFSpiel__send_help_.Views;

public partial class ShellWindow : MetroWindow
{
    public ShellWindow(IRegionManager regionManager, IRightPaneService rightPaneService)
    {
        InitializeComponent();
        RegionManager.SetRegionName(menuContentControl, Regions.Main);
        RegionManager.SetRegionManager(menuContentControl, regionManager);
        rightPaneService.Initialize(splitView, rightPaneContentControl);
    }
}
