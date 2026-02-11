using Microsoft.Maui.Controls;

namespace CDLogisticsApp.Pages;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        StartCarouselAutoPlay();
    }

    // Auto-scroll du carousel toutes les 5 secondes
    private async void StartCarouselAutoPlay()
    {
        await Task.Delay(3000); // Délai initial de 3 secondes

        while (true)
        {
            await Task.Delay(5000); // Attendre 5 secondes

            try
            {
                if (HeroCarousel != null && HeroCarousel.ItemsSource != null)
                {
                    var items = HeroCarousel.ItemsSource as string[];
                    if (items != null && items.Length > 0)
                    {
                        var currentPosition = HeroCarousel.Position;
                        var nextPosition = (currentPosition + 1) % items.Length;
                        HeroCarousel.Position = nextPosition;
                    }
                }
            }
            catch
            {
                // Ignorer les erreurs si la page est déchargée
                break;
            }
        }
    }

    private async void OnContactClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//ContactPage");
    }

    private async void OnServicesClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//ServicesPage");
    }

    private async void OnServiceTapped(object sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//ServicesPage");
    }
}