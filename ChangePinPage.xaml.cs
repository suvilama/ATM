//using Contacts;
using Microsoft.Maui;
using System.Xml.Linq;

namespace ATM;

public partial class ChangePinPage : ContentPage
{
    private readonly long _phoneNumber;

    public ChangePinPage(long phoneNumber)
    {
        InitializeComponent();
        _phoneNumber = phoneNumber;
    }

    private async void ChangeButtonClicked(object sender, EventArgs e)
    {
        var pin = newPinEntry.Text;
        var confirmPin = confirmNewPinEntry.Text;

        if (confirmPin != pin)
        {
            ErrorMessageLabel.IsVisible = true;
        }
        else
        {
            // Retrieve the existing user from the database
            User existingUser = await App.Database.GetUserAsync(_phoneNumber);
            if (existingUser != null)
            {
                // Update the user's password (PIN)
                existingUser.Password = pin;

                // Save the updated user back to the database
                await App.Database.SaveUserAsync(existingUser);

                // Navigate to another page after changing the PIN
                await Navigation.PushAsync(new ChangePinSuccessPage(_phoneNumber));
                ErrorMessageLabel.IsVisible = false;
            }
            else
            {
                // Handle user not found
                ErrorMessageLabel.Text = "User not found.";
                ErrorMessageLabel.IsVisible = true;
            }
        }
    }
}