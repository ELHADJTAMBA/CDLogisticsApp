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
        await DisplayAlert("Carrières", "Pour consulter nos opportunités de carrière, veuillez nous contacter par email à info@asm-cdlogistics.com", "OK");
    }
}