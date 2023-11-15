using WPFSpiel__send_help_.Models;

namespace WPFSpiel__send_help_.Contracts.Services;

public interface IThemeSelectorService
{
    void InitializeTheme();

    void SetTheme(AppTheme theme);

    AppTheme GetCurrentTheme();
}
