namespace ATM
{
    public partial class DepositAmountPage : ContentPage
    {
        public DepositAmountPage()
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
            // Get the entered deposit amount
            string depositAmount = depositAmountEntry.Text;

            // Perform deposit operation with the entered amount
            // ...

            // Navigate to the next page or show a success message
        }
    }
}
