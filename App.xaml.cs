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

            Application.Current.UserAppTheme = AppTheme.Dark;
            MainPage = new AppShell();
            
        }

    }
}