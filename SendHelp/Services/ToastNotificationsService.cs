using CommunityToolkit.WinUI.Notifications;

using SendHelp.Contracts.Services;

using Windows.UI.Notifications;

namespace SendHelp.Services;

public partial class ToastNotificationsService : IToastNotificationsService
{
    public ToastNotificationsService()
    {
    }

    public void ShowToastNotification(ToastNotification toastNotification)
    {
        ToastNotificationManagerCompat.CreateToastNotifier().Show(toastNotification);
    }
}