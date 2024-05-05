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
           
            string phoneNumber = phoneNumberEntry.Text;
            
            string pin = pinEntry.Text;
            bool isAuthenticated = AuthenticateUser(phoneNumber, pin);
            if (isAuthenticated)
            {
                Navigation.PushAsync(new OperationSelectionPage());
            }
            else
            {
                // Show error message
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            //This is just some dummy data that i used to login before i get any sort of database to store user values
            if (username == "demo" && password == "password")
            {
                return true;
            }
            return false;
        }

        private void OnLabelClicked(object sender, TappedEventArgs e)
        {
            Navigation.PushAsync(new SignUpPage());
        }
    }
}