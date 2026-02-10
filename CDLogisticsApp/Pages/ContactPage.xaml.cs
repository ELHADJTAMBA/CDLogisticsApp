using Microsoft.Maui.Controls;

namespace CDLogisticsApp.Pages;

public partial class ContactPage : ContentPage
{
    public ContactPage()
    {
        InitializeComponent();
    }

    private async void OnSendClicked(object sender, EventArgs e)
    {
        string name = NameEntry.Text;
        string email = EmailEntry.Text;
        string message = MessageEditor.Text;

        if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(message))
        {
            await DisplayAlert("Erreur", "Veuillez remplir tous les champs", "OK");
            return;
        }

        // Ici tu peux intégrer l'envoi par email ou API
        await DisplayAlert("Message envoyé", "Merci pour votre message !", "OK");

        NameEntry.Text = "";
        EmailEntry.Text = "";
        MessageEditor.Text = "";
    }
}
