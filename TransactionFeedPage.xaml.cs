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