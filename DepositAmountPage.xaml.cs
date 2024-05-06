namespace ATM
{
    public partial class DepositAmountPage : ContentPage
    {
        private readonly long _phoneNumber;
        private readonly DatabaseService _databaseService;

        public DepositAmountPage(long phoneNumber)
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
            if (existingUser != null)
            {
                GreetingLabel.Text = $"{existingUser.Name}";
            }
        }
        private async void ConfirmButtonClicked(object sender, EventArgs e)
        {
            string depositAmountText = depositAmountEntry.Text;
            if (!decimal.TryParse(depositAmountText, out decimal depositAmount))
            {
                // Handle invalid input
                return;
            }

            User user = await _databaseService.GetUserAsync(_phoneNumber);
            if (user != null)
            {
                user.AccountBalance += depositAmount; // Update account balance
                await _databaseService.SaveUserAsync(user); // Save changes to database

                // Navigate to success page or show success message
                await Navigation.PushAsync(new TransactionSuccessPage(_phoneNumber));
            }
            else
            {
                // Handle user not found
            }
        }

        private async void CancelButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OperationSelectionPage(_phoneNumber));
        }

        private void Homepage(object sender, EventArgs e)
        {
             Navigation.PushAsync(new OperationSelectionPage(_phoneNumber));
        }

        private void Settingspage(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OperationSelectionPage(_phoneNumber));
        }
    }
}
