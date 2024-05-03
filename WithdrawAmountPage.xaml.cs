namespace ATM;

public partial class WithdrawAmountPage : ContentPage
{
    public WithdrawAmountPage()
    {
        InitializeComponent();
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

        // Navigate to the next page or show a success message
    }
}

