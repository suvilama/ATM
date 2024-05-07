using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    
        public class Transaction
        {
            [PrimaryKey, AutoIncrement]
       
        public long PhoneNumber { get; set; }

        public string TransactionType { get; set; }
            public decimal Amount { get; set; }
            public DateTime Date { get; set; }

        public string Sign { get; set; }
            
        }
   
}
