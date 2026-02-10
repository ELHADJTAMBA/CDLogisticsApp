using Microsoft.Maui.Controls;

namespace CDLogisticsApp.Pages;

public partial class ExpertisePage : ContentPage
{
    public ExpertisePage()
    {
        InitializeComponent();
    }

    private async void OnContactClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//ContactPage");
    }
}