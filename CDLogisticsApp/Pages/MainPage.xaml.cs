using Microsoft.Maui.Controls;

namespace CDLogisticsApp.Pages;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnServicesClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//ServicesPage");
    }
}
