using Avalonia.Styling;
using Material.Styles.Themes;
using Material.Styles.Themes.Base;
using ReactiveUI;

namespace MatrialAvaloniaTest.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public string Greeting => "Welcome to Avalonia!";

    public bool IsDark
    {
        get => App.Current.RequestedThemeVariant == ThemeVariant.Dark;
        set
        {
            if (value)
            {
                App.SetDarkTheme();
            }
            else
            {
                App.SetLightTheme();
            }
            this.RaisePropertyChanged();
        }
    }
}