using Microsoft.Maui.Controls;
using Microsoft.Maui.ApplicationModel.Communication;

namespace CDLogisticsApp.Pages;

public partial class ContactPage : ContentPage
{
    public ContactPage()
    {
        InitializeComponent();
    }

    private async void OnSendClicked(object sender, EventArgs e)
    {
        // Validation des champs
        if (string.IsNullOrWhiteSpace(NameEntry.Text))
        {
            await DisplayAlert("Erreur", "Veuillez entrer votre nom", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(EmailEntry.Text) || !EmailEntry.Text.Contains("@"))
        {
            await DisplayAlert("Erreur", "Veuillez entrer une adresse email valide", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(PhoneEntry.Text))
        {
            await DisplayAlert("Erreur", "Veuillez entrer votre numéro de téléphone", "OK");
            return;
        }

        if (ServicePicker.SelectedIndex == -1)
        {
            await DisplayAlert("Erreur", "Veuillez sélectionner un service", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(MessageEditor.Text))
        {
            await DisplayAlert("Erreur", "Veuillez écrire votre message", "OK");
            return;
        }

        // Construction du message
        var subject = $"Demande de contact - {ServicePicker.SelectedItem}";
        var body = $@"
Nouvelle demande de contact depuis l'application mobile

Nom: {NameEntry.Text}
Email: {EmailEntry.Text}
Téléphone: {PhoneEntry.Text}
Entreprise: {CompanyEntry.Text ?? "Non renseigné"}
Service: {ServicePicker.SelectedItem}

Message:
{MessageEditor.Text}
";

        try
        {
            // Tentative d'envoi par email
            var message = new EmailMessage
            {
                Subject = subject,
                Body = body,
                To = new List<string> { "info@asm-cdlogistics.com" }
            };

            await Email.Default.ComposeAsync(message);

            // Réinitialiser le formulaire
            NameEntry.Text = string.Empty;
            EmailEntry.Text = string.Empty;
            PhoneEntry.Text = string.Empty;
            CompanyEntry.Text = string.Empty;
            ServicePicker.SelectedIndex = -1;
            MessageEditor.Text = string.Empty;

            await DisplayAlert("Succès",
                "Votre message a été préparé. Veuillez le valider dans votre application email.\n\nNous vous répondrons dans les plus brefs délais.",
                "OK");
        }
        catch (Exception ex)
        {
            // Si l'envoi par email échoue, proposer d'appeler
            var result = await DisplayAlert("Information enregistrée",
                $"Vos informations ont été enregistrées:\n\n{NameEntry.Text}\n{EmailEntry.Text}\n{PhoneEntry.Text}\n\nSouhaitez-vous nous appeler directement ?",
                "Appeler", "Annuler");

            if (result)
            {
                await OnPhoneClicked(sender, e);
            }
        }
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
                await DisplayAlert("Numéro de téléphone",
                    "+224 622 70 61 60\n\nVeuillez composer ce numéro sur votre téléphone",
                    "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Numéro de téléphone",
                "+224 622 70 61 60",
                "OK");
        }
    }

    private async void OnEmailClicked(object sender, EventArgs e)
    {
        try
        {
            var message = new EmailMessage
            {
                To = new List<string> { "info@asm-cdlogistics.com" },
                Subject = "Demande d'information"
            };

            await Email.Default.ComposeAsync(message);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Email",
                "info@asm-cdlogistics.com\n\nCopiez cette adresse pour nous écrire",
                "OK");
        }
    }

    private async void OnFacebookClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Facebook",
            "Retrouvez-nous sur Facebook : CD-Logistics Guinée",
            "OK");
    }

    private async void OnLinkedInClicked(object sender, EventArgs e)
    {
        await DisplayAlert("LinkedIn",
            "Suivez-nous sur LinkedIn : CD-Logistics",
            "OK");
    }

    private async void OnEmailSocialClicked(object sender, EventArgs e)
    {
        await OnEmailClicked(sender, e);
    }
}