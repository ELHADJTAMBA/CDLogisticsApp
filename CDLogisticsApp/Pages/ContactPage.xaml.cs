using Microsoft.Maui.Controls;
using Microsoft.Maui.ApplicationModel.Communication;
using System;

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
            {
                PhoneDialer.Default.Open("+224622706160");
            }
            else
            {
                await DisplayAlert("Téléphone", "+224 622 70 61 60", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erreur", "Impossible d'ouvrir le composeur téléphonique.", "OK");
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
            await DisplayAlert("Email", "info@asm-cdlogistics.com", "OK");
        }
    }

    private async void OnEmailSocialClicked(object sender, EventArgs e)
    {
        await OnEmailClicked(sender, e);
    }

    private async void OnFacebookClicked(object sender, EventArgs e)
    {
        try
        {
            await Browser.Default.OpenAsync("https://www.facebook.com/cdlogistics", BrowserLaunchMode.SystemPreferred);
        }
        catch
        {
            await DisplayAlert("Facebook", "Visitez notre page Facebook : @cdlogistics", "OK");
        }
    }

    private async void OnLinkedInClicked(object sender, EventArgs e)
    {
        try
        {
            await Browser.Default.OpenAsync("https://www.linkedin.com/company/cd-logistics", BrowserLaunchMode.SystemPreferred);
        }
        catch
        {
            await DisplayAlert("LinkedIn", "Suivez-nous sur LinkedIn : CD-Logistics", "OK");
        }
    }

    private async void OnSendClicked(object sender, EventArgs e)
    {
        // Validation des champs
        if (string.IsNullOrWhiteSpace(NameEntry.Text))
        {
            await DisplayAlert("Erreur", "Veuillez entrer votre nom complet", "OK");
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

        // Validation de l'email
        if (!IsValidEmail(EmailEntry.Text))
        {
            await DisplayAlert("Erreur", "Veuillez entrer une adresse email valide", "OK");
            return;
        }

        // Construire le message email
        try
        {
            var emailMessage = new EmailMessage
            {
                Subject = $"Demande de contact - {ServicePicker.Items[ServicePicker.SelectedIndex]}",
                Body = $"Nom: {NameEntry.Text}\n" +
                       $"Email: {EmailEntry.Text}\n" +
                       $"Téléphone: {PhoneEntry.Text}\n" +
                       $"Entreprise: {CompanyEntry.Text}\n" +
                       $"Service: {ServicePicker.Items[ServicePicker.SelectedIndex]}\n\n" +
                       $"Message:\n{MessageEditor.Text}",
                To = new List<string> { "info@asm-cdlogistics.com" }
            };

            await Email.Default.ComposeAsync(emailMessage);

            // Réinitialiser le formulaire
            NameEntry.Text = string.Empty;
            EmailEntry.Text = string.Empty;
            PhoneEntry.Text = string.Empty;
            CompanyEntry.Text = string.Empty;
            ServicePicker.SelectedIndex = -1;
            MessageEditor.Text = string.Empty;

            await DisplayAlert("Succès", "Votre message a été envoyé avec succès!", "OK");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erreur", "Une erreur est survenue lors de l'envoi du message. Veuillez réessayer.", "OK");
        }
    }

    private bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
}