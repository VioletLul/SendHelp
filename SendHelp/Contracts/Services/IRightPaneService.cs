using MahApps.Metro.Controls;
using Prism.Regions;
using System.Windows.Controls;

namespace SendHelp.Contracts.Services;

public interface IRightPaneService
{
    event EventHandler PaneClosed;

    event EventHandler PaneOpened;

    void CleanUp();

    void Initialize(SplitView splitView, ContentControl rightPaneContentControl);

    void OpenInRightPane(string pageKey, NavigationParameters navigationParameters = null);
}