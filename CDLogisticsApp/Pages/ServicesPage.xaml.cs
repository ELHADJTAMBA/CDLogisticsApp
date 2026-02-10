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
        await DisplayAlert("Fret Maritime",
            "Contactez-nous au +224 622 70 61 60 pour plus d'informations sur nos services de fret maritime.",
            "OK");
    }

    private async void OnAerienClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Transport Aérien",
            "Contactez-nous au +224 622 70 61 60 pour plus d'informations sur nos services de transport aérien.",
            "OK");
    }

    private async void OnTerrestreClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Transport Terrestre",
            "Contactez-nous au +224 622 70 61 60 pour plus d'informations sur nos services de transport terrestre.",
            "OK");
    }

    private async void OnEntreposageClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Entreposage & Stockage",
            "Contactez-nous au +224 622 70 61 60 pour plus d'informations sur nos services d'entreposage.",
            "OK");
    }

    private async void OnTransitClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Transit & Douane",
            "Contactez-nous au +224 622 70 61 60 pour plus d'informations sur nos services de transit et douane.",
            "OK");
    }

    private async void OnSupportsClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Services Supports",
            "Contactez-nous au +224 622 70 61 60 pour plus d'informations sur nos services de support.",
            "OK");
    }

    private async void OnContactClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//ContactPage");
    }
}