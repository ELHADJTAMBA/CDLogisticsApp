using Microsoft.Maui.Controls;

namespace CDLogisticsApp.Pages;

public partial class TeamPage : ContentPage
{
    public TeamPage()
    {
        InitializeComponent();
    }

    private async void OnCareersClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Carrières",
            "Pour postuler, envoyez votre CV à recrutement@asm-cdlogistics.com\n\nNous recrutons régulièrement :\n• Logisticiens\n• Chauffeurs\n• Transitaires\n• Service client",
            "OK");
    }
}