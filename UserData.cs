using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public long PhoneNumber { get; set; }

        public string Name { get; set; }
        public string Password { get; set; }

        public decimal AccountBalance { get; set; }
    }
}
