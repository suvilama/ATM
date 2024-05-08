
using ATM.Resources.Styles;

namespace ATM;

public partial class PreferenceSettings : ContentPage
{
    private readonly long _phoneNumber;
    public PreferenceSettings(long phoneNumber)
	{
		InitializeComponent();
        _phoneNumber = phoneNumber;

       
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Get the user's phone number from wherever it's stored (e.g., settings or login)

        // Fetch the user based on the phone number
        User existingUser = await App.Database.GetUserAsync(_phoneNumber);

        // Update the greeting label with the user's name if the user exists
        if (existingUser != null)
        {
            GreetingLabel.Text = $"{existingUser.Name}";
        }
    }

    private void Homepage(object sender, EventArgs e)
    {
        Navigation.PushAsync(new OperationSelectionPage(_phoneNumber));

    }

    private void Settingspage(object sender, EventArgs e)
    {
        Navigation.PushAsync(new PreferenceSettings(_phoneNumber));
    }

    private void ChangePinButtonClicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ChangePinPage(_phoneNumber));
    }

    private void DarkModeSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        bool isDarkMode = e.Value;
        ApplyDarkMode(isDarkMode);
    }
    private void ApplyDarkMode(bool isDarkMode)
    {
        Preferences.Set("DarkModeEnabled", isDarkMode);
        if (isDarkMode)
        {
            // Load Dark theme resource dictionary
            ResourceDictionary darkTheme = new Dark();
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(darkTheme);
        }
        else
        {
            // Load Light theme or other theme resource dictionary
            ResourceDictionary lightTheme = new Light();
            Application.Current.Resources.MergedDictionaries.Clear();
            Application.Current.Resources.MergedDictionaries.Add(lightTheme);
        }
    }
}