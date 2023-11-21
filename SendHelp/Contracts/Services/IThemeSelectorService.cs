using SendHelp.Models;

namespace SendHelp.Contracts.Services;

public interface IThemeSelectorService
{
    AppTheme GetCurrentTheme();

    void InitializeTheme();

    void SetTheme(AppTheme theme);
}