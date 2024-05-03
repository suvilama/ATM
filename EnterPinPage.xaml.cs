namespace ATM
{
    public partial class EnterPinPage : ContentPage
    {
        public EnterPinPage()
        {
            InitializeComponent();
        }

        private void CancelButtonClicked(object sender, EventArgs e)
        {
            // Navigate back to the previous page
            Navigation.PopAsync();
        }

        private void ConfirmButtonClicked(object sender, EventArgs e)
        {
            // Get the entered PIN
            string PIN = pinEntry.Text;

            // Perform PIN confirmation
            // ...

            // Navigate to the next page or show a success message
        }
    }
}
