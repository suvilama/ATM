namespace ATM
{
    public partial class LanguageSelectionPage : ContentPage
    {
        public LanguageSelectionPage()
        {
            InitializeComponent();
        }

        private void EnglishButtonClicked(object sender, EventArgs e)
        {
            // Navigate to the next page in English
            Navigation.PushAsync(new MainPage());
        }

        private void SpanishButtonClicked(object sender, EventArgs e)
        {
            // Navigate to the next page in Spanish
            Navigation.PushAsync(new MainPage());
        }
    }
}