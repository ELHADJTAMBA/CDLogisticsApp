using Microsoft.Maui.Controls;

namespace CDLogisticsApp.Pages;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        // Démarrer le carousel automatiquement
        Device.StartTimer(TimeSpan.FromSeconds(5), () =>
        {
            var currentIndex = HeroCarousel.Position;
            var nextIndex = (currentIndex + 1) % 6;
            HeroCarousel.Position = nextIndex;
            return true;
        });
    }

    private async void OnServicesClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//ServicesPage");
    }

    private async void OnContactClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//ContactPage");
    }

    private async void OnServiceTapped(object sender, EventArgs e)
    {
        var tappedItem = (TapGestureRecognizer)sender;
        var service = tappedItem.CommandParameter as string;

        await Shell.Current.GoToAsync("//ServicesPage");
    }
}