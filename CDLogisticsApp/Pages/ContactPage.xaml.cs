using Microsoft.Maui.Controls;
using Microsoft.Maui.ApplicationModel.Communication;

namespace CDLogisticsApp.Pages;

public partial class ContactPage : ContentPage
{
    public ContactPage()
    {
        InitializeComponent();
    }

    private async void OnPhoneClicked(object sender, EventArgs e)
    {
        try
        {
            if (PhoneDialer.Default.IsSupported)
                PhoneDialer.Default.Open("+224622706160");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erreur", "Impossible d'ouvrir le composeur téléphonique", "OK");
        }
    }

    private async void OnEmailClicked(object sender, EventArgs e)
    {
        try
        {
            var message = new EmailMessage
            {
                Subject = "Demande d'information",
                To = new List<string> { "info@asm-cdlogistics.com" }
            };
            await Email.Default.ComposeAsync(message);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erreur", "Impossible d'ouvrir l'application email", "OK");
        }
    }

    private async Task SendEmailAsync()
    {
        try
        {
            var message = new EmailMessage
            {
                Subject = "Demande d'information",
                To = new List<string> { "info@asm-cdlogistics.com" }
            };

            await Email.Default.ComposeAsync(message);
        }
        catch
        {
            await DisplayAlert("Erreur", "Impossible d'ouvrir l'application email", "OK");
        }
    }



    private async void OnFacebookClicked(object sender, EventArgs e)
    {
        try
        {
            await Browser.Default.OpenAsync("https://www.facebook.com/cdlogistics", BrowserLaunchMode.SystemPreferred);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erreur", "Impossible d'ouvrir le lien", "OK");
        }
    }

    private async void OnLinkedInClicked(object sender, EventArgs e)
    {
        try
        {
            await Browser.Default.OpenAsync("https://www.linkedin.com/company/cdlogistics", BrowserLaunchMode.SystemPreferred);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erreur", "Impossible d'ouvrir le lien", "OK");
        }
    }

    private async void OnSendClicked(object sender, EventArgs e)
    {
        // Validation
        if (string.IsNullOrWhiteSpace(NameEntry.Text))
        {
            await DisplayAlert("Erreur", "Veuillez entrer votre nom", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(EmailEntry.Text))
        {
            await DisplayAlert("Erreur", "Veuillez entrer votre email", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(PhoneEntry.Text))
        {
            await DisplayAlert("Erreur", "Veuillez entrer votre téléphone", "OK");
            return;
        }

        if (ServicePicker.SelectedIndex == -1)
        {
            await DisplayAlert("Erreur", "Veuillez sélectionner un service", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(MessageEditor.Text))
        {
            await DisplayAlert("Erreur", "Veuillez entrer votre message", "OK");
            return;
        }

        // Envoi du message via email
        try
        {
            var message = new EmailMessage
            {
                Subject = $"Contact depuis l'application - {ServicePicker.SelectedItem}",
                To = new List<string> { "info@asm-cdlogistics.com" },
                Body = $"Nom: {NameEntry.Text}\n" +
                       $"Email: {EmailEntry.Text}\n" +
                       $"Téléphone: {PhoneEntry.Text}\n" +
                       $"Entreprise: {CompanyEntry.Text}\n" +
                       $"Service: {ServicePicker.SelectedItem}\n\n" +
                       $"Message:\n{MessageEditor.Text}"
            };

            await Email.Default.ComposeAsync(message);

            // Réinitialiser le formulaire
            NameEntry.Text = string.Empty;
            EmailEntry.Text = string.Empty;
            PhoneEntry.Text = string.Empty;
            CompanyEntry.Text = string.Empty;
            ServicePicker.SelectedIndex = -1;
            MessageEditor.Text = string.Empty;

            await DisplayAlert("Succès", "Votre message a été préparé. Veuillez l'envoyer depuis votre application email.", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erreur", "Impossible d'envoyer le message. Veuillez réessayer.", "OK");
        }
    }
}