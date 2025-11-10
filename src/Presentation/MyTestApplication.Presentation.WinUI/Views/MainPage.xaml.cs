using Microsoft.UI.Xaml.Controls;

using MyTestApplication.Presentation.WinUI.ViewModels;

namespace MyTestApplication.Presentation.WinUI.Views;

public sealed partial class MainPage : Page
{
    public MainViewModel ViewModel
    {
        get;
    }

    public MainPage()
    {
        ViewModel = App.GetService<MainViewModel>();
        InitializeComponent();
    }
}
