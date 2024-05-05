namespace ATM
{
    public partial class OperationSelectionPage : ContentPage
    {
        public OperationSelectionPage()
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

        private void DepositButtonClicked(object sender, EventArgs e)
        {
            // Navigate to the Deposit page
            Navigation.PushAsync(new DepositAmountPage());
        }

        private void WithdrawalButtonClicked(object sender, EventArgs e)
        {
            // Navigate to the Withdrawal page
            Navigation.PushAsync(new WithdrawAmountPage());
        }

        private void TransactionFeedButtonClicked(object sender, EventArgs e)
        {
            // Navigate to the Transaction Feed page
            Navigation.PushAsync(new TransactionFeedPage());
        }

        private void OpenNewAccountButtonClicked(object sender, EventArgs e)
        {
            // Navigate to the Open New Account page
        }
    }
}
