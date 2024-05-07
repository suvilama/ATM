using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class DatabaseService
    {
        readonly SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
            _database.CreateTableAsync<Transaction>().Wait();
        }

        public Task<List<User>> GetUsersAsync()
        {
            return _database.Table<User>().ToListAsync();
        }

        public Task<User> GetUserAsync(long phoneNumber)
        {
            return _database.Table<User>().Where(u => u.PhoneNumber == phoneNumber).FirstOrDefaultAsync();
        }

        public Task<int> SaveUserAsync(User user)
        {
            return _database.InsertOrReplaceAsync(user);
        }

        public Task<int> DeleteUserAsync(User user)
        {
            return _database.DeleteAsync(user);
        }


        public Task<int> SaveTransactionAsync(Transaction transaction)

        {
           
            return _database.InsertAsync(transaction);
        }

        public async Task<List<Transaction>> GetTransactionsForPhoneNumber(long phoneNumber)
        {
            try
            {
              
                return await _database.Table<Transaction>().ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception
               
                throw; // Rethrow the exception to handle it in the calling code if needed
            }
        }
        public async Task MakeWithdrawal(long phoneNumber, decimal amount)
        {
            // Fetch the user based on phone number
            User user = await GetUserAsync(phoneNumber);

            if (user != null)
            {
                // Check if the user has sufficient balance for withdrawal
                if (user.AccountBalance >= amount)
                {
                    // Create a new withdrawal transaction
                    Transaction withdrawalTransaction = new Transaction
                    {
                        PhoneNumber = phoneNumber,
                        TransactionType = "Withdrawal",
                        Amount = amount,
                        Date = DateTime.UtcNow
                    };

                    // Save the withdrawal transaction
                    await SaveTransactionAsync(withdrawalTransaction);

                    // Update the user's account balance
                    user.AccountBalance -= amount;
                    await SaveUserAsync(user);
                }
                else
                {
                    // Handle insufficient balance error (throw exception, show message, etc.)
                    throw new InvalidOperationException("Insufficient balance for withdrawal.");
                }
            }
            else
            {
                // Handle user not found error (throw exception, show message, etc.)
                throw new InvalidOperationException("User not found.");
            }
        }

        public async Task MakeDeposit(long phoneNumber, decimal amount)
        {
            // Fetch the user based on phone number
            User user = await GetUserAsync(phoneNumber);

            if (user != null)
            {
                // Create a new deposit transaction
                Transaction depositTransaction = new Transaction
                {
                    PhoneNumber = phoneNumber,
                    TransactionType = "Deposit",
                    Amount = amount,
                    Date = DateTime.UtcNow
                };

                // Save the deposit transaction
                await SaveTransactionAsync(depositTransaction);

                // Update the user's account balance
                user.AccountBalance += amount;
                await SaveUserAsync(user);
            }
        }
        public async Task<bool> CheckTransactionsForPhoneNumber(long phoneNumber)
        {
            var transactions = await _database.Table<Transaction>()
                .Where(t => t.PhoneNumber == phoneNumber)
                .ToListAsync();

            return transactions.Any(); // Returns true if there are transactions, false otherwise
        }
    }
}