namespace ATM
{
    public partial class TransactionFeedPage : ContentPage
    {
        private readonly long _phoneNumber;

        public TransactionFeedPage(long phoneNumber)
        {
            InitializeComponent();
            _phoneNumber = phoneNumber;
            LoadTransactions();
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
                GreetingLabel.Text = $"{existingUser.Name}";
            }
        }

        private async Task LoadTransactions()
        {
            try
            {
                List<Transaction> depositTransactions = await App.Database.GetTransactionsForPhoneNumber(_phoneNumber);
                TransactionListView.ItemsSource = depositTransactions;
            }
            catch (Exception ex)
            {
                // Handle the exception (e.g., log, display error message)
                Console.WriteLine($"Error loading transactions: {ex.Message}");
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
    }
}