namespace ATM;

public partial class ChangePinSuccessPage : ContentPage
{
	public readonly long _phoneNumber;
	public ChangePinSuccessPage(long phoneNumber)
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