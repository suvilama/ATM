namespace ATM;

public partial class PreferenceSettings : ContentPage
{
    private readonly long _phoneNumber;
    public PreferenceSettings(long phoneNumber)
	{
		InitializeComponent();
        _phoneNumber = phoneNumber;
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