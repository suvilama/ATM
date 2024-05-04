namespace ATM;

public partial class PreferenceSettings : ContentPage
{
	public PreferenceSettings()
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