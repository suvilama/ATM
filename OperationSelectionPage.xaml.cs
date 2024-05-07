namespace ATM
{
    public partial class OperationSelectionPage : ContentPage
    {
        private readonly long _phoneNumber;
        public OperationSelectionPage(long phoneNumber)
        {
            InitializeComponent();
            _phoneNumber = phoneNumber; 
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Get the user's phone number from wherever it's stored (e.g., settings or login)
          
            // Fetch the user based on the phone number
            User existingUser = await App.Database.GetUserAsync(_phoneNumber);

            // Update the greeting label with the user's name if the user exists
            if (existingUser != null)
            {
                GreetingLabel.Text = $"Welcome {existingUser.Name}!";
                BalanceLabel.Text = $"{existingUser.AccountBalance}";

            }


        }
        private void Homepage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OperationSelectionPage(_phoneNumber));

        }

        private void Settingspage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PreferenceSettings(_phoneNumber));
        }

        private void DepositButtonClicked(object sender, EventArgs e)
        {
            // Navigate to the Deposit page
            Navigation.PushAsync(new DepositAmountPage(_phoneNumber));
        }

        private void WithdrawalButtonClicked(object sender, EventArgs e)
        {
            // Navigate to the Withdrawal page
            Navigation.PushAsync(new WithdrawAmountPage(_phoneNumber));
        }

        private void TransactionFeedButtonClicked(object sender, EventArgs e)
        {
            // Navigate to the Transaction Feed page
            Navigation.PushAsync(new TransactionFeedPage(_phoneNumber));
        }

        private void OpenNewAccountButtonClicked(object sender, EventArgs e)
        {
            // Navigate to the Open New Account page
        }
    }
}
