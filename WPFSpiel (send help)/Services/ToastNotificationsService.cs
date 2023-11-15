using CommunityToolkit.WinUI.Notifications;

using Windows.UI.Notifications;

using WPFSpiel__send_help_.Contracts.Services;

namespace WPFSpiel__send_help_.Services;

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
