namespace ATM
{
    public partial class App : Application
    {
        public static DatabaseService Database { get; private set; }
        // dark theme
   
        public App()
        {
            InitializeComponent();

            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.db3");
            Database = new DatabaseService(dbPath);
            bool isDarkMode = Preferences.Get("IsDarkModeEnabled", false);
            ApplyDarkMode(isDarkMode);
            Application.Current.UserAppTheme = AppTheme.Dark;
            MainPage = new AppShell();
            
        }

        protected override void OnStart()
        {
            base.OnStart();
            LoadDarkModePreference(); // Load dark mode preference when the app starts or resumes
        }

        private void LoadDarkModePreference()
        {
            bool isDarkMode = Preferences.Get("DarkModeEnabled", false); // Default to false if preference is not set
            ApplyDarkMode(isDarkMode);
        }

        private void ApplyDarkMode(bool isDarkMode)
        {
            if (isDarkMode)
            {
                // Apply dark mode styles
                App.Current.Resources["BackgroundColor"] = App.Current.Resources["DarkModeBackgroundColor"];
                App.Current.Resources["TextColor"] = App.Current.Resources["DarkModeTextColor"];
            }
            else
            {
                // Apply light mode styles
                App.Current.Resources["BackgroundColor"] = App.Current.Resources["LightModeBackgroundColor"];
                App.Current.Resources["TextColor"] = App.Current.Resources["LightModeTextColor"];
            }
        }

    }
}