namespace ATM
{
    public partial class MainPage : ContentPage
    {
        private  long phoneNumber;
        public MainPage()
        {
            InitializeComponent();
        }


        private async void LogInButtonClicked(object sender, EventArgs e)
        {
            string phoneNumberText = phoneNumberEntry.Text;
            long phoneNumber = long.Parse(phoneNumberText); // Get phone number from entry field
            string pin = pinEntry.Text;

            User existingUser = await App.Database.GetUserAsync(phoneNumber); // Fetch user by phone number

            if (existingUser != null && existingUser.Password == pin)
            {
                // Successful login, navigate to main page
                await Navigation.PushAsync(new OperationSelectionPage(phoneNumber)); // Pass phone number here
            }
            else
            {
                // Display login failed message
            }
        }



        private void OnLabelClicked(object sender, TappedEventArgs e)
        {
           
            Navigation.PushAsync(new SignUpPage());
        }
    }
}