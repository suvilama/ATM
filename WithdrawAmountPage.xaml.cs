namespace ATM;

public partial class WithdrawAmountPage : ContentPage
{
    private readonly long _phoneNumber;
    public WithdrawAmountPage(long phoneNumber)
    {
        InitializeComponent();
        _phoneNumber = phoneNumber;
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

    private void ConfirmButtonClicked(object sender, EventArgs e)
    {
        // Get the entered deposit amount
        string withdrawAmount = withdrawAmountEntry.Text;

        // Perform deposit operation with the entered amount
        // ...
        Navigation.PushAsync(new TransactionSuccessPage(_phoneNumber));
        // Navigate to the next page or show a success message
    }
}

