namespace ATM;

public partial class TransactionSuccessPage : ContentPage
{
	public TransactionSuccessPage()
	{
		InitializeComponent();
	}

    private void Homepage(object sender, EventArgs e)
    {
        Navigation.PushAsync(new OperationSelectionPage());

    }

    private void Settingspage(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PreferenceSettings());
    }
}