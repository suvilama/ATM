using System.Diagnostics;

namespace ATM
{
    public partial class SignUpPage : ContentPage
    {
        public SignUpPage()
        {
            InitializeComponent();
        }

        private async void SignUpButtonClicked(object sender, EventArgs e)
        {
            var name = firstLastNameEntry.Text;
            string phoneNumberText = phoneNumberEntry.Text;
            long phoneNumber = long.Parse(phoneNumberText);
            var pin = pinEntry.Text;

            var confirmPin = confirmPinEntry.Text;
            var originalPin = pinEntry.Text; // Assuming pinEntry is the entry for the original PIN

            if (confirmPin != originalPin)
            {
                ErrorMessageLabel.IsVisible = true;
            }
            else
            {
                User newUser = new User
                {
                    Name = name,
                    PhoneNumber = phoneNumber,
                    Password = pin
                };

                await App.Database.SaveUserAsync(newUser);

                // Navigate to another page after sign-up
                await Navigation.PushAsync(new MainPage());
                ErrorMessageLabel.IsVisible = false;
            }
        }
    }
}






