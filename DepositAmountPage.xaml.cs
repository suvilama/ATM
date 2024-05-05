namespace ATM
{
    public partial class DepositAmountPage : ContentPage
    {
        public DepositAmountPage()
        {
            InitializeComponent();
        }
        private void Homepage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OperationSelectionPage());

        }

        private void Settingspage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PreferenceSettings());
        }
        private void CancelButtonClicked(object sender, EventArgs e)
        {
            // Navigate back to the previous page
            Navigation.PopAsync();
        }

        private void ConfirmButtonClicked(object sender, EventArgs e)
        {
            // Get the entered deposit amount
            string depositAmount = depositAmountEntry.Text;

            // Perform deposit operation with the entered amount
            // ...
            Navigation.PushAsync(new TransactionSuccessPage());

            // Navigate to the next page or show a success message
        }
    }
}
