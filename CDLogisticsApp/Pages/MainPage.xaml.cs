using Microsoft.Maui.Controls;

namespace CDLogisticsApp.Pages;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnContactClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//ContactPage");
    }

    private async void OnServicesClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//ServicesPage");
    }

    private async void OnServiceTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//ServicesPage");
    }
}