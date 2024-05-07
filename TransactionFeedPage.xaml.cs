using System.Diagnostics;

namespace ATM
{
    public partial class TransactionFeedPage : ContentPage
    {
        private readonly long _phoneNumber;
        public List<Transaction> DepositTransactions { get; set; }
        public TransactionFeedPage(long phoneNumber)
        {
            InitializeComponent();
            _phoneNumber = phoneNumber;
            BindingContext = this;
            // Call an async method to do the loading

            InitializeAsync();

        }

     
        private async void InitializeAsync()
        {
            await LoadTransactions();
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
                // Fetch transactions from the database
                List<Transaction> transactions = await App.Database.GetTransactionsForPhoneNumber(_phoneNumber);

                // Update the sign based on transaction type
                foreach (var transaction in transactions)
                {
                    transaction.Sign = (transaction.TransactionType == "Deposit") ? "+" : "-";
                }

                // Assign the updated transactions to the property
                DepositTransactions = transactions;

                // Notify the UI that the property has changed
                OnPropertyChanged(nameof(DepositTransactions));
                


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