using System.Diagnostics;

namespace ATM;

public partial class SignUpPage : ContentPage
{
    
    public SignUpPage()
	{
		InitializeComponent();
        
    }

    private void SignUpButtonClicked(object sender, EventArgs e)
    {
        var confirmPin = confirmPinEntry.Text;
        var originalPin = pinEntry.Text; // Assuming pinEntry is the entry for the original PIN

        
        if (confirmPin != originalPin)
        {
            ErrorMessageLabel.IsVisible = true;
        }

        else
        {
            ErrorMessageLabel.IsVisible = false;

            Navigation.PushAsync(new OperationSelectionPage());
        }
    }

    

    
}