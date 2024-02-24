using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Styling;
using HotAvalonia;
using Material.Styles.Themes;
using MatrialAvaloniaTest.ViewModels;
using MatrialAvaloniaTest.Views;

namespace MatrialAvaloniaTest;

public partial class App : Application
{
    private static Theme LightTheme { get; } =
        Theme.Create(Theme.Light, Color.Parse("#343838"), Color.Parse("#F9A825"));

    private static Theme DarkTheme { get; } =
        Theme.Create(Theme.Dark, Color.Parse("#E8E8E8"), Color.Parse("#F9A825"));
    
    public static void SetLightTheme()
    {
        Current!.RequestedThemeVariant = ThemeVariant.Light;
        var theme = Current.LocateMaterialTheme<MaterialThemeBase>();
        theme.CurrentTheme = LightTheme;

        Current.Resources["SuccessBrush"] = new SolidColorBrush(Colors.DarkGreen);
        Current.Resources["CanceledBrush"] = new SolidColorBrush(Colors.DarkOrange);
        Current.Resources["FailedBrush"] = new SolidColorBrush(Colors.DarkRed);
    }

    public static void SetDarkTheme()
    {
        Current!.RequestedThemeVariant = ThemeVariant.Dark;
        var theme = Current.LocateMaterialTheme<MaterialThemeBase>();
        theme.CurrentTheme = DarkTheme;

        Current.Resources["SuccessBrush"] = new SolidColorBrush(Colors.LightGreen);
        Current.Resources["CanceledBrush"] = new SolidColorBrush(Colors.Orange);
        Current.Resources["FailedBrush"] = new SolidColorBrush(Colors.OrangeRed);
    }
    
    public override void Initialize()
    {
        this.EnableHotReload();
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}