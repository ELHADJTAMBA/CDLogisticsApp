using Microsoft.Maui.Controls;

namespace CDLogisticsApp.Pages;

public partial class ServicesPage : ContentPage
{
    public ServicesPage()
    {
        InitializeComponent();
    }

    private async void OnMaritimeClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Fret Maritime", "Pour plus d'informations sur nos services de fret maritime, contactez-nous.", "OK");
    }

    private async void OnAerienClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Transport Aérien", "Pour plus d'informations sur nos services de transport aérien, contactez-nous.", "OK");
    }

    private async void OnTerrestreClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Transport Terrestre", "Pour plus d'informations sur nos services de transport terrestre, contactez-nous.", "OK");
    }

    private async void OnEntreposageClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Entreposage", "Pour plus d'informations sur nos services d'entreposage, contactez-nous.", "OK");
    }

    private async void OnTransitClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Transit & Douane", "Pour plus d'informations sur nos services de transit et douane, contactez-nous.", "OK");
    }

    private async void OnSupportsClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Services Supports", "Pour plus d'informations sur nos services supports, contactez-nous.", "OK");
    }

    private async void OnContactClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//ContactPage");
    }
}