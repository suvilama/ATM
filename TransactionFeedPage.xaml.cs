namespace ATM;

public partial class TransactionFeedPage : ContentPage
{
	public TransactionFeedPage()
	{
		InitializeComponent();
        // Sample transaction data
        var transactions = new List<Transaction>
            {
                new Transaction { TransactionType = "Deposit", Amount = "$500", Date = DateTime.Now.AddDays(-3) },
                new Transaction { TransactionType = "Withdrawal", Amount = "$100", Date = DateTime.Now.AddDays(-2) },
                new Transaction { TransactionType = "Deposit", Amount = "$300", Date = DateTime.Now.AddDays(-1) },
                new Transaction { TransactionType = "Withdrawal", Amount = "$200", Date = DateTime.Now },
                new Transaction { TransactionType = "Withdrawal", Amount = "$100", Date = DateTime.Now.AddDays(-2) },
                new Transaction { TransactionType = "Deposit", Amount = "$300", Date = DateTime.Now.AddDays(-1) },
                new Transaction { TransactionType = "Withdrawal", Amount = "$200", Date = DateTime.Now }
            };

        // Bind transaction data to ListView
        TransactionListView.ItemsSource = transactions;
    }

    // Class to represent a transaction
    public class Transaction
    {
        public string TransactionType { get; set; }
        public string Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
