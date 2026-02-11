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
        await DisplayAlert(
            "Carrières",
            "Nous recherchons constamment des talents passionnés par la logistique.\n\n" +
            "Postes disponibles :\n" +
            "• Transitaire junior\n" +
            "• Agent de douane\n" +
            "• Responsable transport\n" +
            "• Coordinateur logistique\n\n" +
            "Contactez-nous pour postuler : info@asm-cdlogistics.com",
            "OK"
        );
    }
}