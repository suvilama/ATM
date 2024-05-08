namespace ATM;

public partial class WithdrawAmountPage : ContentPage
{
    private readonly long _phoneNumber;
    private readonly DatabaseService _databaseService;
    public WithdrawAmountPage(long phoneNumber)
    {
        InitializeComponent();
        _phoneNumber = phoneNumber;
        _databaseService = App.Database;

    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Get the user's phone number from wherever it's stored (e.g., settings or login)

        // Fetch the user based on the phone number
        User existingUser = await App.Database.GetUserAsync(_phoneNumber);

        // Update the greeting label with the user's name if the user exists
      
    }

    private void Homepage(object sender, EventArgs e)
    {
        Navigation.PushAsync(new OperationSelectionPage(_phoneNumber));

    }

    private void Settingspage(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PreferenceSettings(_phoneNumber));
    }

    private void CancelButtonClicked(object sender, EventArgs e)
    {
        // Navigate back to the previous page
        Navigation.PopAsync();
    }

    private async void ConfirmButtonClicked(object sender, EventArgs e)
    {
        string withdrawalAmountText = withdrawAmountEntry.Text;
        if (!decimal.TryParse(withdrawalAmountText, out decimal withdrawalAmount))
        {
            // Handle invalid input
            return;
        }

        try
        {
            // Make the withdrawal using the database service
            await App.Database.MakeWithdrawal(_phoneNumber, withdrawalAmount);

            // Navigate to success page or show success message
            await Navigation.PushAsync(new TransactionSuccessPage(_phoneNumber));
        }
        catch (InvalidOperationException ex)
        {
            // Handle insufficient balance or user not found errors
            await DisplayAlert("Error", ex.Message, "OK");
        }
        catch (Exception ex)
        {
            // Handle other unexpected errors
            await DisplayAlert("Error", "An error occurred while processing your request.", "OK");
        }
    }
}


