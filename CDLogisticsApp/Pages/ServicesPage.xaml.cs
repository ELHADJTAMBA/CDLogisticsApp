using Microsoft.Maui.Controls;

namespace CDLogisticsApp.Pages;

public partial class ServicesPage : ContentPage
{
    public ServicesPage()
    {
        InitializeComponent();
    }

    private async void OnContactClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//ContactPage");
    }

    private async void OnMaritimeClicked(object sender, EventArgs e)
    {
        await DisplayAlert(
            "Fret Maritime International",
            "Notre service de fret maritime couvre tous vos besoins d'expédition par mer avec des solutions FCL et LCL vers la Guinée et au départ de celle-ci.",
            "OK"
        );
    }

    private async void OnAerienClicked(object sender, EventArgs e)
    {
        await DisplayAlert(
            "Transport Aérien Express",
            "Service de fret aérien rapide et sécurisé pour vos marchandises urgentes avec livraison 24-48h.",
            "OK"
        );
    }

    private async void OnTerrestreClicked(object sender, EventArgs e)
    {
        await DisplayAlert(
            "Transport Terrestre",
            "Flotte moderne de camions pour le transport local et régional en Guinée et dans la sous-région.",
            "OK"
        );
    }

    private async void OnEntreposageClicked(object sender, EventArgs e)
    {
        await DisplayAlert(
            "Entreposage & Stockage",
            "Entrepôts sécurisés avec gestion informatisée des stocks et services de manutention professionnels.",
            "OK"
        );
    }

    private async void OnTransitClicked(object sender, EventArgs e)
    {
        await DisplayAlert(
            "Transit & Douane",
            "Expertise complète en dédouanement import/export avec représentation agréée en douane.",
            "OK"
        );
    }

    private async void OnSupportsClicked(object sender, EventArgs e)
    {
        await DisplayAlert(
            "Services Supports",
            "Accompagnement complet : visas, hébergement, transport local VIP et services de conciergerie.",
            "OK"
        );
    }
}