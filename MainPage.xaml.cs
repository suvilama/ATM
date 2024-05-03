namespace ATM
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void LogInButtonClicked(object sender, EventArgs e)
        {
            // Implement your login logic here
            string phoneNumber = phoneNumberEntry.Text;
            string pin = pinEntry.Text;

            // Validate phone number and PIN
            // If valid, navigate to the next page
            // If invalid, show an error message
        }
    }
}